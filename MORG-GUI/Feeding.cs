using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORG_GUI
{
    interface FeedBehavior
    {
        void feed(Organism h, Field m);
        string get_description();
    }
    class Feeding
    {
        protected string description;
        public void setdescription(string m)
        {
            description = m;
        }
        public string Getdescription()
        {
            return description;
        }

        public void feeding_stuff(Organism h, Field m)
        {
            int i = 0;
            while (h.getPrey()[i].target != true)
                i++;
            h.Setx(h.getPrey()[i].x);
            h.Sety(h.getPrey()[i].y);
            h.getPrey()[i].target = false;
            h.getPrey()[i].alive = false;
            m.getOrganism(h.getPrey()[i].type).Die();
            h.setFull(true);
            setdescription(h.getPrey()[i].type+" at ("+h.Getx()+","+h.Gety()+")");
        }

    }

    class Absorbs :Feeding,FeedBehavior
    {
        public void feed(Organism h,Field m)
        {
            string tempname = h.Getname();
            feeding_stuff(h, m);
            setdescription(tempname + " Absorbs "+get_description());
        }
        public string get_description()
        {
            return Getdescription();
        }
    }

    class Envelopes : Feeding,FeedBehavior
    {
        public void feed(Organism h, Field m)
        {
            string tempname = h.Getname();
            feeding_stuff(h, m);
            setdescription(tempname + " Envelopes "+get_description());
        }
        public string get_description()
        {
            return Getdescription();
        }
    }
}
