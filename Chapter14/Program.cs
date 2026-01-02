using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


// File Metadata
// Every file has:
// Creation time
// Last modified time
// Last accessed time
// Size


/*class FileMetadataDemo
{
    static void Main()
    {
        string file = "payroll1.dat";
        //string file = "payroll.dat";
        string dir = Directory.GetCurrentDirectory();

        if (File.Exists(file))
        {
            Console.WriteLine("Created: " + File.GetCreationTime(file));
            Console.WriteLine("Last Modified: " + File.GetLastWriteTime(file));
            Console.WriteLine("Last Accessed: " + File.GetLastAccessTime(file));
        }
        else
        {
            Console.WriteLine("Current Directory: " + dir);
            Console.WriteLine("File does not exist.");
        }
    }
}*/

/*
class ListFilesDemo
{
    static void Main()
    {
        //string folder = @"C:\Documents";
        string folder = @"C:\Users\jrbat\OneDrive - Missouri State University\ITC366 SP26\Demo Code\ITC366 Demo Code FA20\ITC366 Demo Code FA20\Chapter14\bin\Debug\net10.0";

        if (Directory.Exists(folder))
        {
            string[] files = Directory.GetFiles(folder);

            foreach (string f in files)
            {
                Console.WriteLine(f);
            }
        }
        else
        {
            Console.WriteLine("Folder not found.");
        }
    }
}*/

/*class ReadTextFileDemo
{
    static void Main()
    {
        string file = "employees.txt";

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
                Console.WriteLine(line);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
*/



/*class BinaryFileDemo
{
    static void Main()
    {
        string file = "photo.jpg";

        if (File.Exists(file))
        {
            byte[] data = File.ReadAllBytes(file);
            Console.WriteLine("File size in bytes: " + data.Length);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}*/


class FileInformation
{
    static void Main()
    {
        Console.Write("Enter a file name: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            Console.WriteLine("Created: " + File.GetCreationTime(fileName));
            Console.WriteLine("Last Modified: " + File.GetLastWriteTime(fileName));
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
}