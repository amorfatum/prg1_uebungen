using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text;

namespace prg1_uebungen
{
    class FileHandler
    {
        //Auswahl der Optionen
        public void SelectOption(string option)
        {
            switch (option){
                case "1":
                    CreateFile();
                    break;
                case "2":
                    RemoveFile();
                    break;
                case "3":
                    RecreateFile();
                    break;
                case "4":
                    CreateAndWrite();
                    break;
                case "5":
                    CreateAndRead();
                    break;
                case "6":
                    CreateAndWriteArrayOfStrings();
                    break;
                case "7":
                    CreateAndWriteIfNotContains();
                    break;
                case "8":
                    AppendToExistingFile();
                    break;
                case "9":
                    CreateAndCopyToOtherName();
                    break;
                case "10":
                    CreateAndMove();
                    break;
                case "11":
                    CreateAndReadFirstLine();
                    break;
                case "12":
                    CreateAndReadLastLine();
                    break;
                case "13":
                    CreateAndReadSpecificLine();
                    break;
                case "14":
                    CreateAndReadnNumbersOfLines();
                    break;
                case "15":
                    CreateAndCountNumbersOfLines();
                    break;
                default:
                    break;
            }
        }

        //File erstellen wenn noch nicht existiert
        public void CreateFile()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";

            try
            {
                if (!File.Exists(path))
                {
                    using (FileStream fs = File.Create(path));
                    Console.WriteLine("File was created: " + path);
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        //File entfernen wenn existiert
        public void RemoveFile()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("File was deleted: " + path);
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        //File löschen wenn existiert und neues file mit selben namen erstellen
        public void RecreateFile()
        {
            RemoveFile();
            CreateFile();
        }

        //File erstellen und mit Text befüllen
        public void CreateAndWrite()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            RemoveFile();
            try
            {
                using (StreamWriter fileStr = File.CreateText(path))
                {
                    fileStr.WriteLine(" Hello and Welcome \n");
                    fileStr.WriteLine(" It is the first content \n");
                    fileStr.WriteLine(" of the text file mytest.txt \n");
                    Console.WriteLine(" A file created with content name mytest.txt\n\n");
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        //File erstellen, mit text befüllen und text auslesen
        private void CreateAndRead()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";

            CreateAndWrite();
            try
            {
                ReadFileContent(path);
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        //File erstellen und String Array schreiben
        private int CreateAndWriteArrayOfStrings()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            string[] ArrLines;
            int n, i;

            RemoveFile();

            Console.Write(" Input number of lines to write in the file  :");
            n = Convert.ToInt32(Console.ReadLine());
            ArrLines = new string[n];

            Console.Write(" Input {0} strings below :\n", n);

            for (i = 0; i < n; i++)
            {
                Console.Write(" Input line {0} : ", i + 1);
                ArrLines[i] = Console.ReadLine();
            }
            System.IO.File.WriteAllLines(path, ArrLines);

            ReadFileContent(path);

            return n;
        }

        
        private void CreateAndWriteIfNotContains()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            string[] ArrLines;
            string str;
            int n, i;

            RemoveFile();

            Console.Write(" Input the string to ignore the line : ");
            str = Console.ReadLine();

            Console.Write(" Input number of lines to write in the file  : ");
            n = Convert.ToInt32(Console.ReadLine());

            ArrLines = new string[n];

            Console.Write(" Input {0} strings below :\n", n);
            for (i = 0; i < n; i++)
            {
                Console.Write(" Input line {0} : ", i + 1);
                ArrLines[i] = Console.ReadLine();
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path))
            {
                foreach (string line in ArrLines)
                {
                    if (!line.Contains(str)) // write the line to the file If it doesn't contain the string in str
                    {
                        file.WriteLine(line);
                    }
                }
            }

            ReadFileContent(path);
        }


        private void AppendToExistingFile()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            CreateAndWrite();

            ReadFileContent(path);

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(" This is the line appended at last line.");
                }

                ReadFileContent(path);
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public void CreateAndCopyToOtherName()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            string newPath = @"D:\hf21b_prg\crawled_pages\mytest_copy.txt";

            CreateAndWrite();

            ReadFileContent(path);

            /* 
             * string sourcefolder = "path";  // you can mention the path of source folder
             * string targetfolder =  "path"; // you can mention the path of target folder 
             * string sourceFile = System.IO.Path.Combine(sourcefolder, sfileName); // combine the source file with path
             * string targetFile = System.IO.Path.Combine(targetfolder, tfileName);   // combine the target file with path
             * 
             * Create a new target folder if not exists
             
                    if (!System.IO.Directory.Exists(targetfolder))
                    {
                        System.IO.Directory.CreateDirectory(targetfolder);
                    }
                    System.IO.File.Copy(sourceFile, destFile, true); // overwrite the target file if it already exists. 
            */

            System.IO.File.Copy(path, newPath, true);
            Console.WriteLine(" The file {0} successfully copied to the name {1} in the same directory.", path, newPath);

            ReadFileContent(newPath);
        }

        public void CreateAndMove()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            string newPath = @"D:\hf21b_prg\crawled_pages\mytest_copy.txt";

            CreateAndWrite();
            ReadFileContent(path); 
            
            System.IO.File.Move(path, newPath); // move a file to another name in same location:
            Console.WriteLine(" The file {0} successfully moved to the name {1} in the same directory.", path, newPath);

            ReadFileContent(newPath);

            Console.ReadKey();
        }

        public void CreateAndReadFirstLine()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            CreateAndWrite();
            ReadFileContent(path);

            try
            {
                Console.Write("\n The content of the first line of the file is :\n");
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    Console.Write(lines[0]);
                }
                Console.WriteLine();
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }
        public void CreateAndReadLastLine()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";

            int n = CreateAndWriteArrayOfStrings();

            Console.Write("\n The content of the last line of the file {0} is  :\n", path);
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                Console.WriteLine(" {0}", lines[n - 1]);
            }
            Console.WriteLine();
        }

        public void CreateAndReadSpecificLine()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            int n = CreateAndWriteArrayOfStrings();
            Console.Write("\n Input which line you want to display  :");
            int l = Convert.ToInt32(Console.ReadLine());

            if (l >= 1 && l <= n)
            {
                Console.Write("\n The content of the line {0} of the file {1} is : \n", l, path);
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    Console.WriteLine(" {0}", lines[l - 1]);
                }
            }
            else
            {
                Console.WriteLine(" Please input the correct line no.");
            }

            Console.WriteLine();
        }

        public void CreateAndReadnNumbersOfLines()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            int n = CreateAndWriteArrayOfStrings();

            Console.Write("\n Input last how many numbers of lines you want to display  :");
            int l = Convert.ToInt32(Console.ReadLine());
            int m = l;
            if (l >= 1 && l <= n)
            {
                Console.Write("\n The content of the last {0} lines of the file {1} is : \n", l, path);
                if (File.Exists(path))
                {
                    for (int i = n - l; i < n; i++)
                    {
                        string[] lines = File.ReadAllLines(path);
                        Console.Write(" The last no {0} line is : {1} \n", m, lines[i]);
                        m--;
                    }
                }
            }
            else
            {
                Console.WriteLine(" Please input the correct line no.");
            }

            Console.WriteLine();
        }

        public void CreateAndCountNumbersOfLines()
        {
            string path = @"D:\hf21b_prg\crawled_pages\mytest.txt";
            int count;
            CreateAndWriteArrayOfStrings();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    count = 0;
                    Console.WriteLine(" Here is the content of the file mytest.txt : ");
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                        count++;
                    }
                    Console.WriteLine("");
                }
                Console.Write(" The number of lines in  the file {0} is : {1} \n\n", path, count);
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        private void ReadFileContent(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                Console.WriteLine(" Here is the content of the file {0} : ", path);
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }
        }
    }
}
