using System;
using System.Collections.Generic;

namespace Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentArticle = Console.ReadLine().Split(", ");
                Article newArticle = new Article(currentArticle[0], currentArticle[1], currentArticle[2]);
                articles.Add(newArticle);
            }

            string command = Console.ReadLine();

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
