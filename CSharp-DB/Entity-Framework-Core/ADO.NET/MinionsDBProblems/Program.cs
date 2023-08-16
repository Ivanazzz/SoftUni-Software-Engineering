namespace VillainNames
{
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Data.SqlClient;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();

            // Problem 02
            string problem2 = await GetAllVillainsWithTheirMinionsAsync(sqlConnection);
            Console.WriteLine(problem2);

            // Problem 03
            int villianId = int.Parse(Console.ReadLine());
            string problem3 = await GetVillainWithAllMinionsByIdAsync(sqlConnection, villianId);
            Console.WriteLine(problem3);

            // Problem 04
            string[] minionArgs = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] villainArgs = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string problem4 = await AddNewMinionAsync(sqlConnection, minionArgs[1], villainArgs[1]);
            Console.WriteLine(problem4);

            // Problem 05
            string countryName = Console.ReadLine();
            string problem5 = await ChangeTownNamesToUpperAsync(sqlConnection, countryName);
            Console.WriteLine(problem5);

            // Problem 06
            int villainId = int.Parse(Console.ReadLine());
            string problem6 = await DeleteVillainByIdAsync(sqlConnection, villainId);
            Console.WriteLine(problem6);

            // Problem 07
            string problem7 = await GetAllMinionsNamesAsync(sqlConnection);
            Console.WriteLine(problem7);

            // Problem 08
            int[] ids = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string problem8 = await UpdateAndGetAllMinionsNameAndAgeAsync(sqlConnection, ids);
            Console.WriteLine(problem8);

            // Problem 09
            int id = int.Parse(Console.ReadLine());
            string problem9 = await UpdateMinionsAgeWithStoredProcAsync(sqlConnection, id);
            Console.WriteLine(problem9);
        }

        // Problem 02
        static async Task<string> GetAllVillainsWithTheirMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand = new SqlCommand(SqlQueries.GetAllVillainsAndCountOfTheirMinions, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                string villainName = (string) reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString();
        }

        // Problem 03
        static async Task<string> GetVillainWithAllMinionsByIdAsync(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand getVillainNameCmd = new SqlCommand(SqlQueries.GetVillainNameById, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();
            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string) villainNameObj;

            SqlCommand getAllMinionsCmd = new SqlCommand(SqlQueries.GetAllMinionByVillianId, sqlConnection);
            getAllMinionsCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader minionsReader = await getAllMinionsCmd.ExecuteReaderAsync();

            sb.AppendLine($"Villain: {villainName}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNumber = (long) minionsReader["RowNum"];
                    string minionName = (string) minionsReader["Name"];
                    int minionAge = (int) minionsReader["Age"];
                    sb.AppendLine($"{rowNumber}. {minionName} {minionAge}");
                }
            }

            return sb.ToString();
        }

        // Problem 04
        static async Task<string> AddNewMinionAsync(SqlConnection sqlConnection, string minionInfo, string villainName)
        {
            StringBuilder sb = new StringBuilder();

            string[] minionArgs = minionInfo
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string minionName = minionArgs[0];
            int minionAge = int.Parse(minionArgs[1]);
            string townName = minionArgs[2];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                int townId = await GetTownIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, townName);
                int villainId = await GetVillainIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, villainName);
                int minionId = await AddNewMinionAndReturnIdAsync(sqlConnection, sqlTransaction, minionName, minionAge, townId);

                await SetMinionToBeServentOfVillainAsync(sqlConnection, sqlTransaction, minionId, villainId);
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                await sqlTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await sqlTransaction.RollbackAsync();
                sb.AppendLine($"Transaction Failed!");
            }

            return sb.ToString();
        }

        private static async Task<int> GetTownIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string townName)
        {
            SqlCommand getTownIdCmd = new SqlCommand(SqlQueries.GetTownIdByName, sqlConnection, transaction);
            getTownIdCmd.Parameters.AddWithValue("@townName", townName);

            int? townId = (int?) await getTownIdCmd.ExecuteScalarAsync();
            if (!townId.HasValue)
            {
                SqlCommand addNewTownCmd = new SqlCommand(SqlQueries.AddNewTown, sqlConnection, transaction);
                addNewTownCmd.Parameters.AddWithValue("@townName", townName);

                await addNewTownCmd.ExecuteNonQueryAsync();
                townId = (int?) await getTownIdCmd.ExecuteScalarAsync();
                sb.AppendLine($"Town {townName} was added to the database.");
            }

            return townId.Value;
        }

        private static async Task<int> GetVillainIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string villainName)
        {
            SqlCommand getVillainIdCmd = new SqlCommand(SqlQueries.GetVillainIdByName, sqlConnection, transaction);
            getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?) await getVillainIdCmd.ExecuteScalarAsync();
            if (!villainId.HasValue)
            {
                SqlCommand addVillainCmd = new SqlCommand(SqlQueries.AddVillainWithDefaultEvilnessFactor, sqlConnection, transaction);
                addVillainCmd.Parameters.AddWithValue("@villainName", villainName);

                await addVillainCmd.ExecuteNonQueryAsync();
                villainId = (int?)await getVillainIdCmd.ExecuteScalarAsync();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId.Value;
        }

        private static async Task<int> AddNewMinionAndReturnIdAsync(SqlConnection sqlConnection, SqlTransaction transaction, string minionName, int minionAge, int townId)
        {
            SqlCommand addMinionCmd = new SqlCommand(SqlQueries.AddNewMinion, sqlConnection, transaction);
            addMinionCmd.Parameters.AddWithValue("@name", minionName);
            addMinionCmd.Parameters.AddWithValue("@age", minionAge);
            addMinionCmd.Parameters.AddWithValue("@townId", townId);

            await addMinionCmd.ExecuteNonQueryAsync();

            SqlCommand getMinionIdCmd = new SqlCommand(SqlQueries.GetMinionIdByName, sqlConnection, transaction);
            getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);

            int minionId = (int) await getMinionIdCmd.ExecuteScalarAsync();

            return minionId;
        }

        private static async Task SetMinionToBeServentOfVillainAsync(SqlConnection sqlConnection, SqlTransaction transaction, int minionId, int villainId)
        {
            SqlCommand addMinionVillainCmd = new SqlCommand(SqlQueries.SetMinionToBeServentOfVillain, sqlConnection, transaction);
            addMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            addMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await addMinionVillainCmd.ExecuteNonQueryAsync();
        }

        // Problem 05
        private static async Task<string> ChangeTownNamesToUpperAsync(SqlConnection sqlConnection, string countryName)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand updateTownsByCountryNameCmd = new SqlCommand(SqlQueries.UpdateTownsToUpperByCountryName, sqlConnection);
            updateTownsByCountryNameCmd.Parameters.AddWithValue("@countryName", countryName);

            int changedTownNamesCount = await updateTownsByCountryNameCmd.ExecuteNonQueryAsync();
            if (changedTownNamesCount == 0)
            {
                sb.AppendLine("No town names were affected.");
            }
            else
            {
                sb.AppendLine($"{changedTownNamesCount} town names were affected.");

                List<string> townNames = new List<string>();

                SqlCommand getTownsByCountryName = new SqlCommand(SqlQueries.GetTownsByCountryName, sqlConnection);
                getTownsByCountryName.Parameters.AddWithValue("@countryName", countryName);
                SqlDataReader townsReader = await getTownsByCountryName.ExecuteReaderAsync();

                while (townsReader.Read())
                {
                    string currentTownName = (string) townsReader["Name"];
                    townNames.Add(currentTownName);
                }

                sb.AppendLine($"[{string.Join(", ", townNames)}]");
            }

            return sb.ToString();
        }

        // Problem 06
        static async Task<string> DeleteVillainByIdAsync(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand getVillainNameById = new SqlCommand(SqlQueries.GetVillainNameById, sqlConnection);
            getVillainNameById.Parameters.AddWithValue("@Id", villainId);

            string? villainName = (string?)await getVillainNameById.ExecuteScalarAsync();
            if (villainName == null)
            {
                return "No such villain was found.";
            }

            sb.AppendLine($"{villainName} was deleted.");

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                SqlCommand deleteVillainFromMinionsVillains = new SqlCommand(SqlQueries.DeleteFromMinionsVillainsByVillainId, sqlConnection, sqlTransaction);
                deleteVillainFromMinionsVillains.Parameters.AddWithValue("@villainId", villainId);

                int removedMinionsConnectionsCount = await deleteVillainFromMinionsVillains.ExecuteNonQueryAsync();

                SqlCommand deleteVillainFromVillains = new SqlCommand(SqlQueries.DeleteFromVillainsByVillainId, sqlConnection, sqlTransaction);
                deleteVillainFromVillains.Parameters.AddWithValue("@villainId", villainId);

                await deleteVillainFromVillains.ExecuteNonQueryAsync();

                sb.AppendLine($"{removedMinionsConnectionsCount} minions were released.");
            }
            catch (Exception ex)
            {
                await sqlTransaction.RollbackAsync();
                sb.AppendLine($"Transaction Failed!");
            }

            return sb.ToString();
        }

        // Problem 07
        static async Task<string> GetAllMinionsNamesAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();
            List<string> minionNames = new List<string>();

            SqlCommand getMinions = new SqlCommand(SqlQueries.GetAllMinionsNames, sqlConnection);
            SqlDataReader namesRaeder = await getMinions.ExecuteReaderAsync();

            while (namesRaeder.Read())
            {
                minionNames.Add((string) namesRaeder["Name"]);
            }

            int halfLength = minionNames.Count() / 2;
            for (int first = 0; first < halfLength + 1; first++)
            {
                int last = minionNames.Count() - first - 1;

                if (first == last)
                {
                    sb.AppendLine(minionNames[first]);
                    break;
                }
                else if (first > last)
                {
                    break;
                }

                sb.AppendLine(minionNames[first]);
                sb.AppendLine(minionNames[last]);
            }

            return sb.ToString();
        }

        // Problem 8
        static async Task<string> UpdateAndGetAllMinionsNameAndAgeAsync(SqlConnection sqlConnection, int[] ids)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ids.Length; i++) 
            {
                int id = ids[i];
                
                SqlCommand updateMinions = new SqlCommand(SqlQueries.UpdateMinionsNameAndAge, sqlConnection);
                updateMinions.Parameters.AddWithValue("@Id", id);
                await updateMinions.ExecuteNonQueryAsync();
            }

            SqlCommand getMinions = new SqlCommand(SqlQueries.GetAllMinionsNameAndAge, sqlConnection);
            SqlDataReader minionsReader = await getMinions.ExecuteReaderAsync();

            while (minionsReader.Read())
            {
                sb.AppendLine($"{minionsReader["Name"]} {minionsReader["Age"]}");
            }

            return sb.ToString();
        }

        // Problem 9
        static async Task<string> UpdateMinionsAgeWithStoredProcAsync(SqlConnection sqlConnection, int id)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand updateMinionsAge = new SqlCommand("usp_GetOlder", sqlConnection);
            updateMinionsAge.CommandType = CommandType.StoredProcedure;
            updateMinionsAge.Parameters.AddWithValue("@Id", id);
            await updateMinionsAge.ExecuteNonQueryAsync();

            SqlCommand getMinion = new SqlCommand(SqlQueries.GetMinionNameAndAgeById, sqlConnection);
            getMinion.Parameters.AddWithValue("@Id", id);
            SqlDataReader minionReader = await getMinion.ExecuteReaderAsync();

            while (minionReader.Read())
            {
                sb.AppendLine($"{minionReader["Name"]} - {minionReader["Age"]} years old");
            }

            return sb.ToString();
        }
    }
}