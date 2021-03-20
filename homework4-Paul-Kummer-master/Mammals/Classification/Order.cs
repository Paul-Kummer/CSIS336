using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mammals.Classification
{
    
    public class Order : IClassificationItem
    {
        private static List<Order> orders = new List<Order>();
        public string Name { get; set; }
        public List<Family> Families { get; set; }

        public IEnumerable<IClassificationItem> Children => Families;

        public static void ReadCsv(string csvFile)
        {
            var fileLines = File.ReadAllLines(csvFile);
            var columnNames = fileLines.First();
            CsvFileLine.SetColumnHeaders(columnNames);

            var allSpecies = from line in fileLines.Skip(1)
                             let csvLine = new CsvFileLine(line)
                             where csvLine["TaxonLevel"] == "SPECIES"
                             select csvLine;

            foreach (var line in allSpecies)
            {
                var order = orders.SingleOrDefault(o => o.Name == line["Order"]);
                if (order == null)
                {
                    order = new Order(line["Order"]);
                    orders.Add(order);
                }
                var family = order.Families.SingleOrDefault(f => f.Name == line["Family"]);
                if (family == null)
                {
                    family = new Family(line["Family"]);
                    order.Families.Add(family);
                }
                var genus = family.Genera.SingleOrDefault(g => g.Name == line["Genus"]);
                if (genus == null)
                {
                    genus = new Genus(line["Genus"]);
                    family.Genera.Add(genus);
                }
                genus.Species.Add(new Species
                {
                    Name = line["Species"],
                    Author = line["Author"],
                    Date = line["Date"],
                    CommonName = line["CommonName"]
                });
            }
        }

        public Order(string name)
        {
            this.Name = name;
            this.Families = new List<Family>();
        }

        public static List<Order> GetOrders()
        {
            return orders;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
