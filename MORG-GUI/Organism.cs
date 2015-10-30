using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORG_GUI
{
    interface ObserverMorg
    {
        void locationUpdate();
        void preyUpdate(Organism m);
    }
    struct prey
    {
        public int x;
        public int y;
        public string type;
        public Boolean target;
        public Boolean alive;
    }
    class Organism : ObserverMorg
    {
        protected MoveBehavior movebehavior;
        protected FeedBehavior feedbehavior;
        protected string type;
        protected int x;
        protected int y;
        protected Boolean hunting = false;
        protected Boolean alive = true;
        protected Boolean full = false;
        protected string name;
        protected string final_script;
        protected prey[] Prey;
        protected int sight;
        protected List<ObserverMorg> observers = new List<ObserverMorg>();

        public void PerformMove(Organism h, Field m)
        {
            movebehavior.move(h,m);
            if (full == false)
                setFinal_script(movebehavior.get_description());
            else
                full = false;
        }

        public void PerformFeed(Organism h,Field m)
        {
            feedbehavior.feed(h, m);
            setFinal_script(feedbehavior.get_description());
        }

        public void look()
        {
            Boolean found = false;
            int i = 0;

            while (found == false&&i<Prey.Length)
            {
                int xdiff = (Prey[i].x - x);
                int ydiff = (Prey[i].y - y);
                if (Math.Sqrt((xdiff*xdiff) + (ydiff*ydiff)) < sight && Prey[i].alive == true)
                {
                    Prey[i].target = true;
                    found = true;
                    hunting = true;
                }
                else
                    hunting = false;
                //maybe add an out of sight else statement
                i++;
            }
        }
        public void Die()
        {
            alive = false;
            x = -1;
            y = -1;
        }
        public void RegisterObserver(ObserverMorg m)
        {
            observers.Add(m);
        }

        public void RemoveObserver(ObserverMorg m)
        {
            observers.Remove(m);
        }

        public void locationUpdate()
        {
            foreach(ObserverMorg m in observers)
            {
                m.preyUpdate(this);
            }
        }
        public void preyUpdate(Organism m)
        {
            for(int i=0;i<Prey.Length;i++)
                if(m.type==Prey[i].type)
                {
                    Prey[i].x = m.x;
                    Prey[i].y = m.y;
                    Prey[i].alive = m.alive;
                    if (Prey[i].alive == false)
                        Prey[i].target = false;
                }
        }
        public void setFull(Boolean x)
        {
            full = x;
        }
        public Boolean getAlive()
        {
            return alive;
        }
        public Boolean getHunting()
        {
            return hunting;
        }

        public prey[] getPrey()
        {
            return Prey;
        }
        public void SetType(string in_type)
        {
            type = in_type;
        }
        public void SetName(string in_name)
        {
            name = in_name;
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

        public void SetMoveBehavior(string in_move)
        {
            switch(in_move)
            {
                case "Paddles":
                    {
                        movebehavior = new Paddles();
                        break;
                    }
                case "Oozes":
                    {
                        movebehavior = new Oozes();
                        break;
                    }
            }
        }

        public void SetFeedBehavior(string in_feed)
        {
            switch (in_feed)
            {
                case "Absorbs":
                    {
                        feedbehavior = new Absorbs();
                        break;
                    }
                case "Envelops":
                    {
                        feedbehavior = new Envelopes();
                        break;
                    }
            }
        }
        public void SetPrey(string[] in_prey)
        {
            Prey = new prey[in_prey.Length];
            for (int i=0;i<in_prey.Length;i++)
            {
                Prey[i].type = in_prey[i];
                Prey[i].target = false;
                Prey[i].alive = true;
            }
        }
        public void SetSight(int x)
        {
            sight = x;
        }
        public string Getname()
        {
            return name;
        }

        public string Gettype()
        {
            return type;
        }

        public void setFinal_script(string s)
        {
            final_script = s;
        }

        public string getFinal_script()
        {
            return final_script;
        }
    }

    /*class ORG_A : Organism
    {

        public ORG_A(Field m)
        {
            type = "A";
            x = 0;
            y = 0;
            name = "Organism A";
            Prey = new prey[2];
            Prey[0].type = "B";
            Prey[1].type = "C";
            Prey[0].target = false;
            Prey[1].target = false;
            sight = 4;
            //locationUpdate();
            movebehavior = new Paddles();
            feedbehavior = new Absorbs();
        }
    }

    class ORG_B : Organism
    {
        public ORG_B(Field m)
        {
            type = "B";
            x = m.Getx_size() - 1;
            y = m.Gety_size() - 1;
            name = "Organism B";
            Prey = new prey[1];
            Prey[0].type = "A";
            Prey[0].target = false;
            sight = 4;
            //locationUpdate();
            movebehavior = new Oozes();
            feedbehavior = new Envelopes();
        }
    }

    class ORG_C : Organism
    {
        public ORG_C(Field m)
        {
            type = "C";
            x = m.Getx_size() / 2;
            y = m.Gety_size() / 2;
            name = "Organism C";
            Prey = new prey[2];
            Prey[0].type = "A";
            Prey[1].type = "B";
            Prey[0].target = false;
            Prey[1].target = false;
            sight = 4;
            //locationUpdate();
            movebehavior = new Paddles();
            feedbehavior = new Envelopes();
        }
    }*/

}
