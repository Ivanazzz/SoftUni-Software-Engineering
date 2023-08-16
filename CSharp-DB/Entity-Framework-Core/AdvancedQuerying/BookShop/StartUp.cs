namespace BookShop
{
    using System.Text;

    using Microsoft.EntityFrameworkCore;

    using Data;
    using Initializer;
    using Models;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            // EF 6:
            // AsNoTracking() -> Detach collection/entity from the ChangeTracker
            // Any changes made will not be saved
            // ToArray()/ToList() -> Materialize the query
            // Any code that we write later it will not be executed in the DB as SQL
            // The code after materialization is executed locally on the machine in RAM

            using var dbContext = new BookShopContext();
            DbInitializer.ResetDatabase(dbContext);

            // Problem 02
            string ageRestrictionInput = Console.ReadLine();
            string p2 = GetBooksByAgeRestriction(dbContext, ageRestrictionInput);
            Console.WriteLine(p2);

            // Problem 03
            string p3 = GetGoldenBooks(dbContext);
            Console.WriteLine(p3);

            // Problem 04
            string p4 = GetBooksByPrice(dbContext);
            Console.WriteLine(p4);

            // Problem 05
            int year = int.Parse(Console.ReadLine());
            string p5 = GetBooksNotReleasedIn(dbContext, year);
            Console.WriteLine(p5);

            // Problem 06
            string category = Console.ReadLine();
            string p6 = GetBooksByCategory(dbContext, category);
            Console.WriteLine(p6);

            // Problem 07
            string date = Console.ReadLine();
            string p7 = GetBooksReleasedBefore(dbContext, date);
            Console.WriteLine(p7);

            // Problem 08
            string authorChars = Console.ReadLine();
            string p8 = GetAuthorNamesEndingIn(dbContext, authorChars);
            Console.WriteLine(p8);

            // Problem 09
            string bookChars = Console.ReadLine();
            string p9 = GetBookTitlesContaining(dbContext, bookChars);
            Console.WriteLine(p9);

            // Problem 10
            string authorLastNameChars = Console.ReadLine();
            string p10 = GetBooksByAuthor(dbContext, authorLastNameChars);
            Console.WriteLine(p10);

            // Problem 11
            int titleLength = int.Parse(Console.ReadLine());
            int p11 = CountBooks(dbContext, titleLength);
            Console.WriteLine(p11);

            // Problem 12
            string p12 = CountCopiesByAuthor(dbContext);
            Console.WriteLine(p12);

            // Problem 13
            string p13 = GetTotalProfitByCategory(dbContext);
            Console.WriteLine(p13);

            // Problem 14
            string p14 = GetMostRecentBooks(dbContext);
            Console.WriteLine(p14);

            // Problem 15
            IncreasePrices(dbContext);

            // Problem 16
            int p16 = RemoveBooks(dbContext);
            Console.WriteLine(p16);
        }

        // Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext dbContext, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                string[] bookTitles = dbContext.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 03
        public static string GetGoldenBooks(BookShopContext dbContext)
        {
            try
            {
                string[] bookTitles = dbContext.Books
                    .Where(b => b.EditionType == EditionType.Gold && 
                                b.Copies < 5000)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 04
        public static string GetBooksByPrice(BookShopContext dbContext)
        {
            StringBuilder sb = new StringBuilder();

            var books = dbContext.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    Price = b.Price.ToString("f2")
                })
                .ToArray();

            foreach ( var book in books )
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext dbContext, int year)
        {
            try
            {
                var bookTitles = dbContext.Books
                    .Where(b => b.ReleaseDate.Value.Year != year)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 06
        public static string GetBooksByCategory(BookShopContext dbContext, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            string[] bookTitles = dbContext.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories
                        .Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 07
        public static string GetBooksReleasedBefore(BookShopContext dbContext, string date)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

                var books = dbContext.Books
                    .Where(b => b.ReleaseDate < dateTime)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Select(b => new
                    {
                        b.Title,
                        b.EditionType,
                        Price = b.Price.ToString("f2"),
                    })
                    .ToArray();

                foreach (var book in books)
                {
                    sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
                }

                return sb.ToString().TrimEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext dbContext, string input)
        {
            string[] authorNames = dbContext.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return string.Join(Environment.NewLine, authorNames);
        }

        // Problem 09
        public static string GetBookTitlesContaining(BookShopContext dbContext, string input)
        {
            string[] bookTitles = dbContext.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext dbContext, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksAuthors = dbContext.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();

            foreach (var book in booksAuthors )
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 11
        public static int CountBooks(BookShopContext dbContext, int lengthCheck)
        {
            int booksCount = dbContext.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext dbContext)
        {
            StringBuilder sb = new StringBuilder();

            var authorsWithBookCopies = dbContext.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + ' ' + a.LastName,
                    TotalCopies = a.Books
                        .Sum(b => b.Copies)
                })
                .ToArray()
                .OrderByDescending(b => b.TotalCopies);

            foreach (var author in authorsWithBookCopies)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext dbContext)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesWithProfit = dbContext.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .ToArray()
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName);

            foreach (var category in categoriesWithProfit)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext dbContext)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesWithMostRecentBooks = dbContext.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate.Value.Year
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var category in categoriesWithMostRecentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext dbContext)
        {
            Book[] booksReleasedBefore2010 = dbContext.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010)
                .ToArray(); // Materializing the query does not detach entities from Change Tracker

            foreach (var book in booksReleasedBefore2010)
            {
                book.Price += 5;
            }

            // Using SaveChanges() -> 4544ms
            // Using BulkUpdate() -> 3677ms

            dbContext.SaveChanges();

            //dbContext.BulkUpdate(booksReleasedBefore2010);
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext dbContext)
        {
            var booksToRemove = dbContext.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            foreach (var book in booksToRemove)
            {
                dbContext.Books.Remove(book);
            }

            dbContext.SaveChanges();

            return booksToRemove.Length;
        }
    }
}


