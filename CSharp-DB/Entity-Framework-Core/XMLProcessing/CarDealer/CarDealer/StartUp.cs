namespace CarDealer
{
    using System.IO;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using DTOs.Export;
    using DTOs.Import;
    using Models;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            string inputXmlSuppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            string inputXmlParts = File.ReadAllText("../../../Datasets/parts.xml");
            string inputXmlCars  = File.ReadAllText("../../../Datasets/cars.xml");
            string inputXmlCustomers  = File.ReadAllText("../../../Datasets/customers.xml");
            string inputXmlSales  = File.ReadAllText("../../../Datasets/sales.xml");

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Problem 01
            string p1 = ImportSuppliers(context, inputXmlSuppliers);
            Console.WriteLine(p1);

            // Problem 02
            string p2 = ImportParts(context, inputXmlParts);
            Console.WriteLine(p2);

            // Problem 03
            string p3 = ImportCars(context, inputXmlCars);
            Console.WriteLine(p3);

            // Problem 04
            string p4 = ImportCustomers(context, inputXmlCustomers);
            Console.WriteLine(p4);

            // Problem 05
            string p5 = ImportSales(context, inputXmlSales);
            Console.WriteLine(p5);

            // Problem 06
            string p6 = GetCarsWithDistance(context);
            Console.WriteLine(p6);

            // Problem 07
            string p7 = GetCarsFromMakeBmw(context);
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
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            // Create IMapper if we use AutoMapper
            // For Manual Mapping IMapper in unnecessary
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportSupplierDto[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
            foreach (ImportSupplierDto supplierDto in supplierDtos)
            {
                if (!string.IsNullOrEmpty(supplierDto.Name))
                {
                    // Manual Mapping without AutoMapper
                    //Supplier supplier = new Supplier()
                    //{
                    //    Name = supplierDto.Name ,
                    //    IsImporter = supplierDto.IsImporter
                    //};

                    Supplier supplier = mapper.Map<Supplier>(supplierDto);

                    validSuppliers.Add(supplier);
                }
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        // Problem 02
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] partDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (ImportPartDto partDto in partDtos)
            {
                if (!string.IsNullOrEmpty(partDto.Name) && 
                    partDto.SupplierId.HasValue && 
                    context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    Part part = mapper.Map<Part>(partDto);
                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        // Problem 03
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();
            foreach (ImportCarDto carDto in carDtos)
            {
                if (!string.IsNullOrEmpty(carDto.Make) && 
                    !string.IsNullOrEmpty(carDto.Model))
                {
                    Car car = mapper.Map<Car>(carDto);

                    foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                    {
                        if (context.Parts.Any(p => p.Id == partDto.PartId))
                        {
                            PartCar carPart = new PartCar()
                            {
                                Car = car,
                                PartId = partDto.PartId,
                            };

                            car.PartsCars.Add(carPart);
                        }
                    }

                    validCars.Add(car);
                }
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        // Problem 04
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();
            foreach (ImportCustomerDto customerDto in customerDtos)
            {
                if (!string.IsNullOrEmpty(customerDto.Name) &&
                    !string.IsNullOrEmpty(customerDto.BirthDate))
                {
                    Customer customer = mapper.Map<Customer>(customerDto);
                    validCustomers.Add(customer);
                }
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        // Problem 05
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSaleDto[] saleDtos = xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            // Optimization
            ICollection<int> dbCarIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            ICollection<Sale> validSales = new HashSet<Sale>();
            foreach (ImportSaleDto saleDto in saleDtos)
            {
                if (saleDto.CarId.HasValue &&
                   dbCarIds.Any(id => id == saleDto.CarId.Value))
                {
                    Sale sale = mapper.Map<Sale>(saleDto);
                    validSales.Add(sale);
                }
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        // Problem 06
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarDto[]>(cars, "cars").ToString().TrimEnd();
        }

        // Problem 07
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarBmwDto[] cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportCarBmwDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarBmwDto[]>(cars, "cars").ToString().TrimEnd();
        }

        // Problem 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportLocalSupplierDto[] suppliersDtos = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return xmlHelper.Serialize(suppliersDtos, "suppliers");
        }

        // Problem 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarWithPartsDto[] carsWithParts = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(carsWithParts, "cars");
        }

        // Problem 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var tempDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    }).ToArray(),
                })
                .ToArray();

            ExportCustomerSalesDto[] totalSalesDtos = tempDto
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Prices))
                .Select(t => new ExportCustomerSalesDto()
                {
                    FullName = t.FullName,
                    BoughtCars  = t.BoughtCars,
                    SpentMoney = t.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return xmlHelper.Serialize<ExportCustomerSalesDto[]>(totalSalesDtos, "customers");
        }

        // Problem 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportSaleDto[] salesDtos = context.Sales
                .Select(s => new ExportSaleDto()
                {
                    Car = new ExportCarToSaleDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Select(p => p.Part.Price).Sum(),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)

                })
                .ToArray();

            return xmlHelper.Serialize(salesDtos, "sales");
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}