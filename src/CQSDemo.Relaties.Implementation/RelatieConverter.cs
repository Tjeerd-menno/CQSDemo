using System.Xml.Linq;
using CQSDemo.Relaties.Models;

namespace CQSDemo.Relaties.Implementation
{
    public class RelatieConverter : IRelatieConverter
    {
        public Relatie Convert(string input)
        {
            XElement relatieElement = XElement.Parse(input);

            return new Relatie
            {
                Naam = relatieElement.Element("naam")?.Value,
                Bsn = int.Parse(relatieElement.Element("bsn")?.Value),
                Nummer = int.Parse(relatieElement.Element("nrrelatie")?.Value)

            };
        }
    }
}