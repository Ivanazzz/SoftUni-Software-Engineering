namespace Logger.Layouts
{
    public class XMLLayout : Layout
    {
        private const string XmlLayoutFormat =
@"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

        public XMLLayout() 
            : base(XmlLayoutFormat)
        {
        }
    }
}
