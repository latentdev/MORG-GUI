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


    abstract class ReaderDectorator : Reader
    {
        protected Reader wrappedReader;
        public ReaderDectorator(Reader r) { wrappedReader = r; }
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
