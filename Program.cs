using System;
using CsvHelper;
using CsvHelper.Configuration;
using System.Xml.Serialization;
using System.Formats.Asn1;
using System.Globalization;
using ClassLibrary2;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
          using var reader = new StreamReader("../../../ConsumAigua.csv");
          using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ConsumAiguaMap>();
            var records = csv.GetRecords<ConsumAigua>().ToList();
            Console.WriteLine("Accio a realitzar: ");
            Console.WriteLine("1. Mostrar les comarques amb una població superior a 200000 habitants");    
            Console.WriteLine("2. Calcular la mitjana del consum domestic per comarca");
            Console.WriteLine("3. Mostrar les 5 comarques amb el consum domèstic per capita més gran");
            Console.WriteLine("4. Mostrar les 5 comarques amb el consum domèstic per capita més baix");
            Console.WriteLine("5. Filtrar les dades per nom o codi");

            switch (Console.ReadLine()) {                 
                case "1":
                    foreach (var record in records)
                    {
                        if (record.Poblacio > 200000)
                        {
                            Console.WriteLine(record.Comarca);
                        }
                    }
                    break;
                case "2":
                    foreach (var record in records)
                    {
                        Console.WriteLine(record.Comarca + " " + record.ConsumDomesticPerCapita);
                    }
                    break;
                case "3":
                    records = records.OrderByDescending(x => x.ConsumDomesticPerCapita).ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(records[i].Comarca + " " + records[i].ConsumDomesticPerCapita);
                    }
                    break;
                case "4":
                    records = records.OrderBy(x => x.ConsumDomesticPerCapita).ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(records[i].Comarca + " " + records[i].ConsumDomesticPerCapita);
                    }
                    break;
                case "5":
                    Console.WriteLine("Introdueix el nom o codi de la comarca");
                    string filter = Console.ReadLine();
                    foreach (var record in records)
                    {
                        if (record.Comarca == filter || record.CodiComarca.ToString() == filter)
                        {
                            Console.WriteLine(record.Comarca + " " + record.CodiComarca);
                        }
                    }
                    break;
            }


            csv.Dispose();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ConsumAigua>));
            using (TextWriter writer = new StreamWriter("../../../ConsumAigua.xml"))
            {
                serializer.Serialize(writer, records);
            }



        }
    }
}
