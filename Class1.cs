using CsvHelper.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary2
{
    public class ConsumAigua
    {
        public int Any { get; set; } 
        public int CodiComarca { get; set; }

        public string Comarca { get; set; }

        public int Poblacio { get; set; } 

        public int DomesticXarxa { get; set; }

        public int ActivitatsEconomiquesIFontsPropies { get; set; }

        public int Total { get; set; }

        public float ConsumDomesticPerCapita { get; set; }

    }

    public class ConsumAiguaMap : ClassMap<ConsumAigua>
    {
        public ConsumAiguaMap()
        {
            Map(m => m.Any).Name("Any");
            Map(m => m.CodiComarca).Name("Codi comarca");
            Map(m => m.Comarca).Name("Comarca");
            Map(m => m.Poblacio).Name("Població");
            Map(m => m.DomesticXarxa).Name("Domèstic xarxa");
            Map(m => m.ActivitatsEconomiquesIFontsPropies).Name("Activitats econòmiques i fonts pròpies");
            Map(m => m.Total).Name("Total");
            Map(m => m.ConsumDomesticPerCapita).Name("Consum domèstic per càpita");
        }
    }   
}
