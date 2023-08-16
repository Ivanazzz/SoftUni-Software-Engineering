namespace CollectionHierarchy.Core
{
    using IO.Contracts;
    using Contracts;
    using CollectionHierarchy.Models.Contracts;
    using CollectionHierarchy.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAddCollection<string> addCollection;
        private readonly IAddRemoveCollection<string> addRemoveCollection;
        private readonly IMyList<string> myList;

        private Engine()
        {
            addCollection = new AddCollection<string>();
            addRemoveCollection = new AddRemoveCollection<string>();
            myList = new MyList<string>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        
        public void Run()
        {
            string[] words = reader
                .ReadLine()
                .Split();
            int removeOperationCount = int.Parse(reader.ReadLine());

            AddToAnyCollection(addCollection, words);
            AddToAnyCollection(addRemoveCollection, words);
            AddToAnyCollection(myList, words);

            RemoveFromAnyCollection(addRemoveCollection, removeOperationCount);
            RemoveFromAnyCollection(myList, removeOperationCount);
        }

        private void AddToAnyCollection(IAddCollection<string> collection, string[] words)
        {
            foreach (string word in words)
            {
                writer.Write(collection.Add(word) + " ");

            }

            writer.WriteLine();
        }

        private void RemoveFromAnyCollection(IAddRemoveCollection<string> collection, int removeOperationCount)
        {
            for (int i = 0; i < removeOperationCount; i++)
            {
                writer.Write(collection.Remove() + " ");
            }

            writer.WriteLine();
        }
    }
}
