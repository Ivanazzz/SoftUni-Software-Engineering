namespace AuthorProblem
{
    using System;

    [AuthorAttribute("Victor")]
    public class StartUp
    {
        [AuthorAttribute("George")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [AuthorAttribute("Ivana")]
        public void Test()
        {

        }
    }
}
