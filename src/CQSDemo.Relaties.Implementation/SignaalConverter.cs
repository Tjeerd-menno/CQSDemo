using System.Xml.Linq;
using CQSDemo.Relaties.Models;

namespace CQSDemo.Relaties.Implementation
{
    public class SignaalConverter : ISignaalConverter
    {
        public XElement Convert(Signaal signaal)
        {
            return new XElement("signaal", 
                new XElement("cdsignaal", signaal.Code), 
                new XElement("datingang", signaal.Ingangsdatum.ToString("yyyyMMdd")), 
                new XElement("dateinde", signaal.Einddatum?.ToString("yyyyMMdd")));
        }
    }
}