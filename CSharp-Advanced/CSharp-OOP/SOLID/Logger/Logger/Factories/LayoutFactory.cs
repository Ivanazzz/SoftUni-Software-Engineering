namespace Logger.Factories
{
    using System;

    using Layouts;

    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XMLLayout();
                default:
                    throw new InvalidOperationException("Missing type");
            }
        }
    }
}
