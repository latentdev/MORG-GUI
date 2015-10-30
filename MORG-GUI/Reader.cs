using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORG_GUI
{
    abstract class Reader
    {
        abstract public string ReadLine();
        abstract public void Close();
    }


    abstract class ReaderDecorator : Reader
    {
        protected Reader wrappedReader;
        public ReaderDecorator(Reader r) { wrappedReader = r; }
    }

    class MorgReader:ReaderDecorator
    {
        //override protected Reader wrappedReader;
        protected string line= "empty";
        string type;
        //string name;
        string moveBehavior;
        string feedBehavior;
        string[] Prey;
        int x;
        int y;

        public MorgReader(Reader r): base(r)
        {
        }
        override public string ReadLine()
        {
            line = wrappedReader.ReadLine();
            return line;
        }
        override public void Close()
        {
            wrappedReader.Close();
        }
        public Organism BuildOrganism()
        {
            Factory morgFactory=new Factory();
            CSV();
            Organism builtOrganism = morgFactory.BuildMorg(type, x, y, moveBehavior, feedBehavior, Prey);
            return builtOrganism;
        }
        public void CSV()
        {
            //ReadLine();
            string[] values = line.Split(',');
            type = values[0];
            int.TryParse(values[1], out x);
            int.TryParse(values[2], out y);
            moveBehavior = values[3];
            feedBehavior = values[4];
            string[] prey = feedBehavior.Split(' ');
            feedBehavior = prey[0];
            Prey = new string[prey.Length - 1];
            for (int i=1; i<prey.Length; i++)
            {
                Prey[i - 1] = prey[i];
            }

        }

    }
    class FileReader : Reader
    {
        private System.IO.StreamReader stream;

        public FileReader(string filename)
        {
            stream = System.IO.File.OpenText(filename);
        }

        override public string ReadLine()
        {
            return stream.ReadLine();
        }

        override public void Close()
        {
            stream.Close();
        }
    }
}
