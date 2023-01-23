using System;
using System.IO;
using System.Text;

namespace prg1_uebungen
{
    class Program
    {
        // Startpunkt Programm
        static void Main(string[] args)
        {
            FileHandler fileHandler = new FileHandler();
            Console.WriteLine("1: Create file \n 2: Delete file \n 3: Recreate file \n 4: Create file and add text \n 5: Create file with text and read file \n 6: Create File and add array of strings \n 7: Write text in new file if it doesn't match a given line \n 8: Append to existing file \n 9: Create file and copy to another name \n 10: Create file and move/ change name \n 11: Read the first line of a file \n 12: Read last line of a file \n 13: Read specific line of file \n 14: Read the las n number of lines \n 15: Count the number of lines in a file");
            Console.WriteLine("Select option: \n");
            string option = Console.ReadLine();
            fileHandler.SelectOption(option);
        }
    }
}
