using System;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ");
            Article newArticle = new Article(article[0], article[1], article[2]);

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ");
                string action = tokens[0];

                switch (action)
                {
                    case "Edit":
                        string newContent = tokens[1];
                        newArticle.Edit(newContent);
                        break;
                    case "ChangeAuthor":
                        string newAuthor = tokens[1];
                        newArticle.ChangeAuthor(newAuthor);
                        break;
                    case "Rename":
                        string newTitle = tokens[1];
                        newArticle.Rename(newTitle);
                        break;
                }
            }

            Console.WriteLine(newArticle);
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content) => this.Content = content;

        public void ChangeAuthor(string author) => this.Author = author;

        public void Rename(string title) => this.Title = title;

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
