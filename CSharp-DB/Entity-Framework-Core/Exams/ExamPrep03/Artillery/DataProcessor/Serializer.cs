namespace Artillery.DataProcessor
{
    using Newtonsoft.Json;

    using Data;
    using Data.Models.Enums;
    using DataProcessor.ExportDto;
    using Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            ExportShellDto[] shells = context.Shells
                .ToArray()
                .Where(s => s.ShellWeight > shellWeight)
                .OrderBy(s => s.ShellWeight)
                .Select(s => new ExportShellDto()
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType == GunType.AntiAircraftGun)
                        .OrderByDescending(g => g.GunWeight)
                        .Select(g => new ExportGunForShell()
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3_000 
                                ? "Long-range" 
                                : "Regular range"
                        })
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);

            //var shells = context.Shells
            //    .ToArray()
            //    .Where(s => s.ShellWeight > shellWeight)
            //    .Select(s => new
            //    {
            //        ShellWeight = Math.Round(s.ShellWeight, 1),
            //        Caliber = s.Caliber,
            //        Guns = s.Guns
            //            .Where(g => g.GunType == GunType.AntiAircraftGun)
            //            .OrderByDescending(g => g.GunWeight)
            //            .Select(g => new
            //            {
            //                GunType = g.GunType.ToString(),
            //                GunWeight = g.GunWeight,
            //                BarrelLength = Math.Round(g.BarrelLength, 2),
            //                Range = g.Range > 3000 ? "Long-range" : "Regular range"
            //            })
            //            .ToArray()
            //    })
            //    .OrderBy(s => s.ShellWeight)
            //    .ToArray();

            //return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            xmlHelper = new XmlHelper();

            ExportGunDto[] guns = context.Guns
                .ToArray()
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(g => new ExportGunDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight.ToString(),
                    BarrelLength = g.BarrelLength.ToString(),
                    Range = g.Range.ToString(),
                    Countries = g.CountriesGuns
                    .ToArray()
                    .Where(cg => cg.Country.ArmySize > 4_500_000)
                    .OrderBy(c => c.Country.ArmySize)
                    .Select(c => new ExportCountryForGun()
                    {
                        CountryName = c.Country.CountryName,
                        ArmySize = c.Country.ArmySize.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            return xmlHelper.Serialize(guns, "Guns");
        }
    }
}
