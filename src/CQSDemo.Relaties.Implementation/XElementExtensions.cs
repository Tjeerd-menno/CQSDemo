using System.Xml.Linq;

namespace CQSDemo.Relaties.Implementation
{
    public static class XElementExtensions
    {
        public static string InnerXml(this XNode node)
        {
            using (var reader = node.CreateReader())
            {
                reader.MoveToContent();
                return reader.ReadInnerXml();
            }
        }
    }
}