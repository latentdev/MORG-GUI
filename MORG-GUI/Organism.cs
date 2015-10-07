using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORG_GUI
{
    class Organism
    {
        protected MoveBehavior movebehavior;
        protected char type;
        protected int x;
        protected int y;
        protected string name;

        public string PerformMove(Organism h, Field m)
        {
            //movebehavior.move(h,m);
            return movebehavior.move(h, m);
        }

        public int Getx()
        {
            return x;
        }

        public void Setx(int coord)
        {
            x = coord;
        }

        public int Gety()
        {
            return y;
        }

        public void Sety(int coord)
        {
            y = coord;
        }

        public string Getname()
        {
            return name;
        }
    }

    class ORG_A : Organism
    {

        public ORG_A()
        {
            type = 'a';
            x = 1;
            y = 1;
            name = "Organism A";
            //Console.Write("Organism A ");
            movebehavior = new Paddles();
        }
    }

    class ORG_B : Organism
    {
        public ORG_B()
        {
            type = 'b';
            x = 3;
            y = 3;
            name = "Organism B";
            //Console.Write("Organism B ");
            movebehavior = new Oozes();
        }
    }

    class ORG_C : Organism
    {
        public ORG_C()
        {
            type = 'c';
            x = 2;
            y = 2;
            name = "Organism C";
            //Console.Write("Organism C ");
            movebehavior = new Paddles();
        }
    }

}
