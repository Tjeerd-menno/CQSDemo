using System.Xml.Linq;
using CQSDemo.Core;
using CQSDemo.Relaties.Models;

namespace CQSDemo.Relaties
{
    public interface ISignaalConverter : IObjectConverter<XElement, Signaal>
    {
    }
}