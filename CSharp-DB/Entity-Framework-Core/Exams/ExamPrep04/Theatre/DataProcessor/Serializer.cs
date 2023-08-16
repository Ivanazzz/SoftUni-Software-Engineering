namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;

    using Data;
    using DataProcessor.ExportDto;
    using Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new ExportTheatreDto()
                {
                    Name = t.Name,
                    NumberOfHalls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Sum(t => t.Price),
                    Tickets = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Select(ti => new ExportTicketDto()
                        {
                            Price = ti.Price,
                            RowNumber = ti.RowNumber
                        })
                        .OrderByDescending(ti => ti.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.NumberOfHalls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            xmlHelper = new XmlHelper();

            var plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= raiting)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0
                        ? "Premier"
                        : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Casts = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportCastDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            return xmlHelper.Serialize(plays, "Plays");
        }
    }
}
