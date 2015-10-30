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
        protected string line;
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
            Organism builtOrganism=new Organism();//factory goes here
            return builtOrganism;
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
