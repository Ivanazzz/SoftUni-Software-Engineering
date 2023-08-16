namespace ProductShop
{
    using Data;
    using DTOs.Export;
    using DTOs.Import;
    using Models;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputXmlUsers = File.ReadAllText("../../../Datasets/users.xml");
            string inputXmlProducts = File.ReadAllText("../../../Datasets/products.xml");
            string inputXmlCategories = File.ReadAllText("../../../Datasets/categories.xml");
            string inputXmlCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.xml");

            // Problem 01
            string p1 = ImportUsers(context, inputXmlUsers);
            Console.WriteLine(p1);

            // Problem 02
            string p2 = ImportProducts(context, inputXmlProducts);
            Console.WriteLine(p2);

            // Problem 03
            string p3 = ImportCategories(context, inputXmlCategories);
            Console.WriteLine(p3);

            // Problem 04
            string p4 = ImportCategoryProducts(context, inputXmlCategoryProducts);
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
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportUserDto[] userDtos = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> validUsers = new HashSet<User>();
            foreach (ImportUserDto userDto in userDtos)
            {
                if (!string.IsNullOrEmpty(userDto.FirstName) &&
                    !string.IsNullOrEmpty(userDto.LastName))
                {
                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userDto.Age
                    };

                    validUsers.Add(user);
                }
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductDto[] productDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            ICollection<Product> validProducts = new HashSet<Product>();
            foreach (ImportProductDto productDto in productDtos)
            {
                if (!string.IsNullOrEmpty(productDto.Name))
                {
                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = productDto.Price,
                        SellerId = productDto.SellerId,
                        BuyerId = productDto.BuyerId
                    };

                    validProducts.Add(product);
                }
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryDto[] categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (ImportCategoryDto categoryDto in categoryDtos)
            {
                if (!string.IsNullOrEmpty(categoryDto.Name))
                {
                    Category category = new Category()
                    {
                        Name = categoryDto.Name
                    };

                    validCategories.Add(category);
                }
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryProductDto[] categoryProductDtos = xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            List<Category> categories = context.Categories
                .ToList();
            List<Product> products = context.Products
                .ToList();

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();
            foreach (ImportCategoryProductDto categoryProductDto in categoryProductDtos)
            {
                if (products.Any(cp => cp.Id == categoryProductDto.ProductId) &&
                    categories.Any(cp => cp.Id == categoryProductDto.CategoryId))
                {
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        ProductId = categoryProductDto.ProductId,
                        CategoryId = categoryProductDto.CategoryId
                    };

                    validCategoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            return xmlHelper.Serialize<List<ExportProductsInRangeDto>>(products, "Products");
        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportSoldProductsUserDto[] usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportSoldProductsUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ExportSoldProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .ToArray();

            return xmlHelper.Serialize<ExportSoldProductsUserDto[]>(usersWithProducts, "Users");
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportCategoryByProductsCountDto[] categories = context.Categories
                .Select(c => new ExportCategoryByProductsCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            return xmlHelper.Serialize<ExportCategoryByProductsCountDto[]>(categories, "Categories");
        }

        // Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportUserDto[] users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            ExportUsersCountDto usersCount = new ExportUsersCountDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            return xmlHelper.Serialize<ExportUsersCountDto>(usersCount, "Users");
        }
    }
}