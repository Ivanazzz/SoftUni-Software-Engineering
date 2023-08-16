namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string inputJsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
            string inputJsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
            string inputJsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
            string inputJsonCategoriesProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Problem 01
            string p1 = ImportUsers(context, inputJsonUsers);
            Console.WriteLine(p1);

            // Problem 02
            string p2 = ImportProducts(context, inputJsonProducts);
            Console.WriteLine(p2);

            // Problem 03
            string p3 = ImportCategories(context, inputJsonCategories);
            Console.WriteLine(p3);

            // Problem 04
            string p4 = ImportCategoryProducts(context, inputJsonCategoriesProducts);
            Console.WriteLine(p4);

            // Problem 05
            string p5 = GetProductsInRange(context);
            Console.WriteLine(p5);

            // Problem 06
            string p6 = GetSoldProducts(context);
            Console.WriteLine(p6);

            // Problem 07
            string p7 = GetCategoriesByProductsCount(context);
            Console.WriteLine(p7);

            // Problem 08
            string p8 = GetUsersWithProducts(context);
            Console.WriteLine(p8);
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDTO[] userDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);

            // AutoMapper can map collections also
            // In case of no validation you can:
            //User[] users = mapper.Map<User[]>(userDtos);

            // This way allows you additional validations
            ICollection<User> validUsers = new HashSet<User>(); 
            foreach (ImportUserDTO userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            // Here we have all valid users ready for the DB
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDTO[] productDtos = JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);

            Product[] products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDTO[] categorieDtos = JsonConvert.DeserializeObject<ImportCategoryDTO[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (ImportCategoryDTO categoryDto in categorieDtos)
            {
                if (!String.IsNullOrEmpty(categoryDto.Name))
                {
                    Category category = mapper.Map<Category>(categoryDto);

                    validCategories.Add(category);
                }
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryProductDTO[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDTO[]>(inputJson);

            ICollection<CategoryProduct> validEntries = new HashSet<CategoryProduct>();
            foreach (ImportCategoryProductDTO cpDto in categoryProductDtos)
            {
                if (context.Categories.Any(c => c.Id == cpDto.CategoryId) &&
                    context.Products.Any(p => p.Id == cpDto.ProductId))
                {
                    CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(cpDto);

                    validEntries.Add(categoryProduct);
                }
            }

            context.CategoriesProducts.AddRange(validEntries);
            context.SaveChanges();

            return $"Successfully imported {validEntries.Count}";
        }

        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            // #Anonymous object + Manual Mapping
            //var products = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new
            //    {
            //        Name = p.Name,
            //        Price = p.Price,
            //        Seller = p.Seller.FirstName + ' ' + p.Seller.LastName
            //    })
            //    .AsNoTracking()
            //    .ToArray();

            //return JsonConvert.SerializeObject(products, Formatting.Indented);


            // DTO + AutoMapper
            IMapper mapper = CreateMapper();

            ExportProductInRangeDTO[] productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductInRangeDTO>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count())
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count(),
                    AveragePrice = (c.CategoriesProducts.Sum(p => p.Product.Price) / c.CategoriesProducts.Count()).ToString("f2"),
                    TotalRevenue = c.CategoriesProducts.Sum(p => p.Product.Price).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });
        }

        // Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                { // UserDTO
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    { // ProductWrapperDTO
                        Count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            { // ProductDTO
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                UsersCount = users.Length,
                Users = users
            };

            return JsonConvert.SerializeObject(userWrapperDto, Formatting.Indented, new JsonSerializerSettings(){ 
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }
    }
}