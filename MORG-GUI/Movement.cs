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
        string description;
        public void movement_stuff(Organism h, Field m)
        {
            int tempx = h.Getx();
            int tempy = h.Gety();
            int tempx_size = m.Getx_size();
            int tempy_size = m.Gety_size();
            string text_direction = null;

            direction = m.n.Next(1, 5); // 1=up, 2=right, 3=down, 4=left
            if (direction == 1)
            {
                if (tempy > tempy_size)//checking to make sure we are still in bounds
                {
                    h.Sety(tempy - 1);
                    tempy -= 1;
                    Console.Write(" moves up to ");
                    text_direction = " up to ";
                }
                else
                {
                    Console.Write(" stays at ");
                    text_direction = " nowhere at ";
                }
            }
            else if (direction == 2)
            {
                if (tempx < tempx_size - 1)
                {
                    h.Setx(tempx + 1);
                    tempx += 1;
                    Console.Write(" moves right to ");
                    text_direction = " right to ";
                }
                else
                {
                    Console.Write(" stays at ");
                    text_direction = " nowhere at ";
                }
            }
            else if (direction == 3)
            {
                if (tempy < tempy_size - 1)//checking to make sure we are still in bounds
                {
                    h.Sety(tempy + 1);
                    tempy += 1;
                    Console.Write(" moves down to ");
                    text_direction = " down to ";
                }
                else
                {
                    Console.Write(" stays at ");
                    text_direction = " nowhere at ";
                }
            }
            else if (direction == 4)
            {
                if (tempx > tempx_size)
                {
                    h.Setx(tempx - 1);
                    tempx -= 1;
                    Console.Write(" moves left to ");
                    text_direction = " left to ";
                }
                else
                {
                    Console.Write(" stays at ");
                    text_direction = " nowhere at ";
                }

            }
            Console.Write(tempx);
            Console.Write(",");
            Console.WriteLine(tempy);
        
            description = text_direction + "(" + tempx + "," + tempy + ")";
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
            Console.Write(temp_name);
            Console.Write(" Oozes");


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
            Console.Write(temp_name);
            Console.Write(" Paddles");
            movement_stuff(h,m);

            Setdescription(temp_name + " Paddles" + Getdescription());
        }

        public string get_description()
        {
            return Getdescription();
        }
    }


}
