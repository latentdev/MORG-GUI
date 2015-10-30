using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MORG_GUI
{
    class Field
    {
        protected int x_size;
        protected int y_size;
        public Random n = new Random();
        public List<Organism> orgs = new List<Organism>();
        //public Organism[] orgs = new Organism[3];
        protected int full = 0;
        


        public Field()
        {
            x_size = 10;
            y_size = 10;
            orgs[0] = null;
            orgs[1] = null;
            orgs[2] = null;

        }

        public Field(int x,int y)
        {
            x_size = x;
            y_size = y;
            orgs.Add(new ORG_A(this));
            orgs.Add(new ORG_B(this));
            orgs.Add(new ORG_C(this));
            orgs[0].RegisterObserver(orgs[1]);
            orgs[0].RegisterObserver(orgs[2]);
            orgs[1].RegisterObserver(orgs[0]);
            orgs[1].RegisterObserver(orgs[2]);
            orgs[2].RegisterObserver(orgs[0]);

            for (int i = 0; i < 3; i++)
                orgs[i].locationUpdate();
        }

        public Organism getOrganism(string type)
        {
            Boolean found = false;
            int index=0;
            for(int i=0;i<orgs.Count;i++)
            {
                if (type == orgs[i].Gettype())
                {
                    found = true;
                    index = i;
                }
            }
            if (found == true)
                return orgs[index];
            else
                return null;
        }

        public void draw_Field()
        {
            Console.Write("[ ]");
            for (int u =0;u<x_size;u++)
                Console.Write("[{0}]", u);
            Console.WriteLine();
            for (int i=0;i< y_size;i++)
            {
                Console.Write("[{0}]", i);
                for (int m=0;m< x_size;m++)
                {
                    
                    for(int z=0;z < 3;z++)
                    {
                        
                        if (m == orgs[z].Getx() && i==orgs[z].Gety())
                        {
                            Console.Write("[{0}]", orgs[z].Gettype());
                            full = 1;
                        }
                    }
                    if (full != 1)
                    {
                        Console.Write("[ ]");
                        
                    }
                    full = 0;
                }
                Console.WriteLine();
            }
        }

        public void sim_field()
        {
            int step = 0;
            for (int m = 0; m < 3; m++)
                orgs[m].PerformMove(orgs[m], this);
            draw_Field();
            for (int z = 0; z < 3; z++)
                Console.WriteLine(orgs[z].getFinal_script());
            Console.WriteLine("step={0}", step);
            Console.Write("Hit Enter to continue:");
                //Console.ReadKey();
            //Console.Clear();
            step++;
        }
        public int Getx_size()
        {
            return x_size;
        }

        public int Gety_size()
        {
            return y_size;
        }
    }
}
