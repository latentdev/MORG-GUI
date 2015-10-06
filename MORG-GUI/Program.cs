using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MORG
{
    class Program
    {
        static void Main(string[] args)
        {
            Organism a = new ORG_A();
            Organism b = new ORG_B();
            Organism c = new ORG_C();

            Field field = new Field(10,10);
            for (int i = 0; i< 10; i++)
            {
                a.PerformMove(a, field);
                b.PerformMove(b, field);
                c.PerformMove(c, field);
                Console.WriteLine();
            }
        }
    }
}
