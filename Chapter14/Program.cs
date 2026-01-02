using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;


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


/*class FileInformation
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
}*/



//  Part Two - Sequential Access Files

//  C# treats files as streams of bytes — it does not automatically understand fields or records
//• Therefore, you must impose structure yourself, usually by:
//• Choosing a delimiter (comma, pipe, tab, etc.)
//• Writing each record in a consistent format
//• Sequential access means you read/write one line at a time, in order.

class Order
{
    public int OrderNum { get; set; }
    public int Item { get; set; }
}


/*class WriteOrderFile
{
    static void Main()
    {
        const int END = 999;
        const char DELIM = ',';
        const string FILE_NAME = "OrderData.txt";

        Order custOrder = new Order();

        FileStream outFile = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(outFile);

        Console.Write("Enter order number (999 to quit): ");
        custOrder.OrderNum = int.Parse(Console.ReadLine());

        while (custOrder.OrderNum != END)
        {
            Console.Write("Enter item number: ");
            custOrder.Item = int.Parse(Console.ReadLine());

            writer.WriteLine(custOrder.OrderNum + DELIM.ToString() + custOrder.Item);

            Console.Write("\nEnter next order number (999 to quit): ");
            custOrder.OrderNum = int.Parse(Console.ReadLine());
        }

        writer.Close();
        outFile.Close();
    }
}
*/
/*  What this produces:
    A text file like:
    123,5432
    124,5213
    125,5342
*/

// Reading from a Sequential Access File


/*class ReadOrderFile
{
    static void Main()
    {
        const char DELIM = ',';
        const string FILE_NAME = "OrderData.txt";

        FileStream inFile = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(inFile);

        string line;
        Console.WriteLine("OrderNum\tItem");

        while ((line = reader.ReadLine()) != null)
        {
            string[] fields = line.Split(DELIM);

            int orderNum = int.Parse(fields[0]);
            int item = int.Parse(fields[1]);

            Console.WriteLine($"{orderNum}\t\t{item}");
        }

        reader.Close();
        inFile.Close();
    }
}
/*
    C# sees files as raw bytes, so you define the structure.
        - Sequential access files are written and read line by line.
        - Use:
            -StreamWriter for writing
            - StreamReader for reading
            - Delimiters(like commas) separate fields.
            - This approach is simple, predictable, and ideal for small datasets.
*/


// Part 3   Serialization & Deserialization

/* Why Serialization?
    Text files are:
•      Readable by anyone → security risk
•      Annoying to parse → you must handle delimiters manually

Serialization solves this by letting you save entire objects directly to a file in binary form.

 What Serialization Does
    • 	Serialization: object → stream of bytes → file
    • 	Deserialization: stream of bytes → object
        This allows programs to store and retrieve objects without manually writing each field.
*/


/*
 * Required Namespaces:
 * using System.IO;
 * using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
  using System.Text.Json;
 */

// Note BinaryFormatter is obsolete and not recommended for new development due to security risks.

/*class SerializingObjects
{
    static void Main()
    {


        const int END = 999;
        string fileName = "orders.jsonl";   // JSON Lines format

        // Create the output file (overwrite if exists)
        using FileStream outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);

        Console.Write("Enter order number (999 to quit): ");
        int orderNum = int.Parse(Console.ReadLine());

        while (orderNum != END)
        {
            Console.Write("Enter item number: ");
            int item = int.Parse(Console.ReadLine());

            Order custOrder = new Order { OrderNum = orderNum, Item = item };

            // Serialize the object to JSON
            string json = JsonSerializer.Serialize(custOrder);

            // Write one JSON object per line
            using StreamWriter writer = new StreamWriter(outFile, leaveOpen: true);
            writer.WriteLine(json);
            writer.Flush();

            Console.Write("\nEnter next order number (999 to quit): ");
            orderNum = int.Parse(Console.ReadLine());
        }




    }
}*/


class ReadOrders
{
    static void Main()
    {
        const string FILE_NAME = "orders.jsonl";

        if (!File.Exists(FILE_NAME))
        {
            Console.WriteLine("No order file found.");
            return;
        }

        Console.WriteLine("OrderNum\tItem");

        foreach (string line in File.ReadLines(FILE_NAME))
        {
            // Deserialize each JSON line into an Order object
            Order custOrder = JsonSerializer.Deserialize<Order>(line);

            Console.WriteLine($"{custOrder.OrderNum}\t\t{custOrder.Item}");
        }
    }
}