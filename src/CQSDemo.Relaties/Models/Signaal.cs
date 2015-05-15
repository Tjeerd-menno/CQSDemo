using System;

namespace CQSDemo.Relaties.Models
{
    public class Signaal
    {
        public string Code { get; set; }
        public DateTime Ingangsdatum { get; set; }
        public DateTime? Einddatum { get; set; }
    }
}