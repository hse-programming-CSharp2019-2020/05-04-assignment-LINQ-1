using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<ComputerInfo> computerInfoList = new List<ComputerInfo>();
            for (int i = 0; i < N; i++)
            {
                string[] s = Console.ReadLine().Trim().Split();
                computerInfoList.Add(new ComputerInfo {
                    Owner = s[0],
                    ProductionYear = int.Parse(s[1]),
                    ComputerManufacturer = (Manufacturer)int.Parse(s[2])
                });
            }
            
            var computerInfoQuery = from x in computerInfoList
                        orderby x.Owner descending, 
                                x.ComputerManufacturer descending, 
                                x.ProductionYear descending
                        select x;
            PrintCollectionInOneLine(computerInfoQuery);

            Console.WriteLine();

            var computerInfoMethods = computerInfoList.OrderByDescending(x => x.Owner)
                .ThenByDescending(x => x.ComputerManufacturer)
                .ThenByDescending(x => x.ProductionYear);
            PrintCollectionInOneLine(computerInfoMethods);

            Console.Read();
        }

        public static void PrintCollectionInOneLine(IEnumerable<ComputerInfo> collection)
        {
            collection.ToList().ForEach(computerInfo => Console.WriteLine(computerInfo));
        }
    }

    enum Manufacturer
    {
        Apple,
        Asus,
        Dell,
        Microsoft 
    }

    class ComputerInfo
    {
        public String Owner { get; set; }
        public Manufacturer ComputerManufacturer { get; set; }
        public int ProductionYear { get; set; }

        public override string ToString()
        {
            return $"{Owner}: {ComputerManufacturer} [{ProductionYear}]";
        }
    }
}
