using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORG_GUI
{
    interface MoveBehavior
    {
        void move(Organism h, Field m);
        string get_description();
    }

    class Movement
    {
        int direction;
        protected string description;

        public void hunt(Organism h, Field x)
        {
            int tempx = h.Getx();
            int tempy = h.Gety();

            
            
            int i = 0;
            while (h.getPrey()[i].target != true)
                i++;
            var prey = h.getPrey()[i];
            int xdiff = (h.getPrey()[i].x - h.Getx());
            int ydiff = (h.getPrey()[i].y - h.Gety());
            if (Math.Abs(xdiff) <= 1 && Math.Abs(ydiff) <= 1)//checking to make sure the prey is close enough to eat using the distance formula
            {
                h.PerformFeed(h, x);
            }
            else
            {
                if (prey.x < h.Getx())
                {
                    h.Setx(tempx - 1);
                }
                else if (prey.x > h.Getx())
                {
                    h.Setx(tempx + 1);
                }

                if (prey.y < h.Gety())
                {
                    h.Sety(tempy - 1);
                }
                else if (prey.y > h.Gety())
                {
                    h.Sety(tempy + 1);
                }

                Setdescription(xdiff != 0 ? (ydiff != 0 ? " diagonally to " : " horizontally to ") : (ydiff != 0 ? " vertically to " : ""));
                description += "(" + h.Getx() + "," + h.Gety() + ")" + " hunting " + h.getPrey()[i].type;
            }
        }

        public void random_movement(Organism h,Field m)
        {
            int tempx = h.Getx();
            int tempy = h.Gety();
            int tempx_size = m.Getx_size();
            int tempy_size = m.Gety_size();
            direction = m.n.Next(1, 5); // 1=up, 2=right, 3=down, 4=left
            if (direction == 1)
            {
                if (tempy > 0)//checking to make sure we are still in bounds
                {
                    h.Sety(tempy - 1);
                    tempy -= 1;
                    Setdescription(" up to ");
                }
                else
                {
                    Setdescription(" nowhere at ");
                }
            }

            else if (direction == 2)
            {
                if (tempx < tempx_size - 1)
                {
                    h.Setx(tempx + 1);
                    tempx += 1;
                    Setdescription(" right to ");
                }
                else
                {
                    Setdescription(" nowhere at ");
                }
            }

            else if (direction == 3)
            {
                if (tempy < tempy_size - 1)
                {
                    h.Sety(tempy + 1);
                    tempy += 1;
                    Setdescription(" down to ");
                }
                else
                {
                    Setdescription(" nowhere at ");
                }
            }

            else if (direction == 4)
            {
                if (tempx > 0)
                {
                    h.Setx(tempx - 1);
                    tempx -= 1;
                    Setdescription(" left to ");
                }
                else
                {
                    Setdescription(" nowhere at ");
                }
            }
            description += "(" + h.Getx() + "," + h.Gety() + ")";

        }
        public void movement_stuff(Organism h, Field m)
        {
            description = null;
            if (h.getAlive() == true)
            {
                h.look();
                if (h.getHunting() == true)
                    hunt(h, m);
                else
                {
                    random_movement(h, m);
                }

                h.locationUpdate();
            }
            else
                Setdescription(" nowhere because it is dead!");
        }

        public void Setdescription(string s)
        {
            description = s;
        }

        public string Getdescription()
        {
            return description;
        }
    }

    class Oozes : Movement , MoveBehavior
    {
        public void move(Organism h, Field m)
        {
            string temp_name = h.Getname();
            movement_stuff(h, m);
            Setdescription(temp_name + " Oozes" + Getdescription());
        }

        public string get_description()
        {
            return Getdescription();
        }

    }

    class Paddles : Movement , MoveBehavior
    {
        public void move(Organism h, Field m)
        {
            string temp_name = h.Getname();
            movement_stuff(h,m);
            Setdescription(temp_name + " Paddles" + Getdescription());
        }

        public string get_description()
        {
            return Getdescription();
        }
    }


}
