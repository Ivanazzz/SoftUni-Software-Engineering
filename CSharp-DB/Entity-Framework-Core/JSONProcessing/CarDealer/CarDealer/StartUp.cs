namespace CarDealer
{
    using System.IO;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using Data;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string inputJsonSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string inputJsonParts = File.ReadAllText(@"../../../Datasets/parts.json");
            string inputJsonCars = File.ReadAllText(@"../../../Datasets/cars.json");
            string inputJsonCustomers = File.ReadAllText(@"../../../Datasets/customers.json");
            string inputJsonSales = File.ReadAllText(@"../../../Datasets/sales.json");

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Problem 01
            string p1 = ImportSuppliers(context, inputJsonSuppliers);
            Console.WriteLine(p1);

            // Problem 02
            string p2 = ImportParts(context, inputJsonParts);
            Console.WriteLine(p2);

            // Problem 03
            string p3 = ImportCars(context, inputJsonCars);
            Console.WriteLine(p3);

            // Problem 04
            string p4 = ImportCustomers(context, inputJsonCustomers);
            Console.WriteLine(p4);

            // Problem 05
            string p5 = ImportSales(context, inputJsonSales);
            Console.WriteLine(p5);

            // Problem 06
            string p6 = GetOrderedCustomers(context);
            Console.WriteLine(p6);

            // Problem 07
            string p7 = GetCarsFromMakeToyota(context);
            Console.WriteLine(p7);

            // Problem 08
            string p8 = GetLocalSuppliers(context);
            Console.WriteLine(p8);

            // Problem 09
            string p9 = GetCarsWithTheirListOfParts(context);
            Console.WriteLine(p9);

            // Problem 10
            string p10 = GetTotalSalesByCustomer(context);
            Console.WriteLine(p10);

            // Problem 11
            string p11 = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(p11);
        }

        // Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDTO[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDTO[]>(inputJson)!;

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // Problem 02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartDTO[] partsDto = JsonConvert.DeserializeObject<ImportPartDTO[]>(inputJson)!;

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (ImportPartDTO partDto in partsDto)
            {
                if (context.Suppliers.Any(s => s.Id == partDto.SuplierId))
                {
                    Part part = mapper.Map<Part>(partDto);

                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        // Problem 03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCarDTO[] carDtos = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson)!;

            List<PartCar> parts = new List<PartCar>();
            List<Car> cars = new List<Car>();

            foreach (ImportCarDTO carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TravelledDistance
                };

                cars.Add(car);

                foreach (var part in carDto.PartsId)
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };

                    parts.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // Problem 04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDTO[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDTO[]>(inputJson)!;

            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // Problem 05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDTO[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDTO[]>(inputJson)!;

            Sale[] sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // Problem 06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count,
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(p => new
                        {
                            p.Part.Name,
                            Price = $"{p.Part.Price:f2}"
                        })
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
        }

        // Problem 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersSales = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price))
                })
                .ToList();

            var totalSales = customersSales.Select(c => new
            {
                c.fullName,
                c.boughtCars,
                spentMoney = c.spentMoney.Sum()
            })
                .OrderByDescending(t => t.spentMoney)
                .ThenByDescending(t => t.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(totalSales, Formatting.Indented);
        }

        // Problem 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100):f2}"
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}