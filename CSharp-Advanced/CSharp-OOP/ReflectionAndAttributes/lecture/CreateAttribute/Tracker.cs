namespace AuthorProblem
{
    using System;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            foreach (var method in type.GetMethods((BindingFlags)60))
            {
                object[] attributes = method.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    AuthorAttribute authorAttribute = attribute as AuthorAttribute;
                    if (authorAttribute != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                    }
                }
            }
        }
    }
}
