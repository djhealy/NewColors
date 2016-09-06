using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Collections;

namespace NewColors
{
    class Program
    {
        static void Main(string[] args)
        {
            string colors = @"d:\\colors.txt";
            string light = @"d:\\light.txt";
            string dark = @"d:\\dark.txt";
            // open the output file
            System.IO.StreamWriter lightFile = new System.IO.StreamWriter(light);
            System.IO.StreamWriter darkFile = new System.IO.StreamWriter(dark);
            // read the file
            System.IO.StreamReader inFile = new System.IO.StreamReader(colors);
            string line = "";
            while ((line = inFile.ReadLine()) != null)
            {
                generateCSS(line, lightFile, darkFile);
            }
            Console.WriteLine("Press any key to end");
            Console.ReadKey(true);
        }

        private static void generateCSS(string line, StreamWriter lightFile, StreamWriter darkFile)
        {
            // split the line
            string[] pieces = line.Split(',');

            if (pieces.Length != 3)
            {
                Console.WriteLine("Not three " + line);
            }
            string title = cleanUp(pieces[0]);
            string outp = ".aw-theme-" + title + " {";
            Console.WriteLine(outp);
            darkFile.WriteLine(outp);
            outp = "    fill: " + pieces[1];
            Console.WriteLine(outp);
            outp = "    fill: " + pieces[2];
            darkFile.WriteLine(outp);
            outp = "}";
            Console.WriteLine(outp);
            outp = "";
            Console.WriteLine(outp);
            darkFile.WriteLine(outp);

            //.aw-widgets-draghandle {
            //    background-color: #ababab;
            //}

        }

        private static string cleanUp(string name)
        {
            // get the dcolor, and make the first character lowercase
            int ix = name.IndexOf('_');
            if (ix < 0)
            {
                Console.WriteLine("Not _ " + name);
            }
            string firstChar = name.Substring(ix+1,1);
            firstChar = firstChar.ToLower();
            string newName = firstChar+name.Substring(ix+2);
            return newName;
        }
    }
}
