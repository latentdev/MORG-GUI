using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORG_GUI
{
    class Factory
    {
        Organism temp = new Organism();
        public Organism BuildMorg(string type,int x,int y,string moveBehavior, string feedBehavior, string [] prey)
        {
            temp.SetType(type);
            temp.SetName("Organism " + type);
            temp.Setx(x);
            temp.Sety(y);
            temp.SetMoveBehavior(moveBehavior);
            temp.SetFeedBehavior(feedBehavior);
            temp.SetPrey(prey);
            temp.SetSight(12);
            return temp;
        }

    }
}
