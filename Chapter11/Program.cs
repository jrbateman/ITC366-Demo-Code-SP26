using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
//class SystemExceptions


//Students will learn how to:

// How runtime exceptions occur  
// How to interpret exception messages  
// How to prevent common errors using input validation and bounds checking  


//C# exceptions are the language’s built‑in way of signaling that something went wrong during program execution.
//Instead of silently failing or producing bad results,
//C# throws an exception object that describes the problem so the program can react appropriately.


// **1. Base Program (Sunny-Day Scenario)**



//  Declares an integer array  
//  Prompts the user for a value  
//  Loops through the array  
//  Performs a division operation  

// **Expected Output (User enters 2)**  
//  Displays elements at index 0 and 1  
//  Prints `30 / 2 = 15`  
//  No errors occur  



static void Main()
   {
       int[] numbers = { 10, 20, 30, 40 };
       Console.Write("Enter an integer: ");

       int max = Convert.ToInt32(Console.ReadLine());

       for (int x = 0; x < max; x++)
       {
           Console.WriteLine($"Index {x}: {numbers[x]}");
       }

       int result = numbers[max] / max;
       Console.WriteLine($"Division result: {result}");
   }
}

// Exception Scenario #1: Invalid Integer Input**
// **Concept**
// If the user enters anything other than an integer (e.g., `"2.2"` or `"hello"`),
// the program attempts to convert it using `Convert.ToInt32()`, which triggers a **FormatException**.

// **Failure Point**
// int max = Convert.ToInt32(Console.ReadLine()); // FormatException

//**Improved Version with Validation**


Console.Write("Enter an integer: ");
string input = Console.ReadLine();

if (!int.TryParse(input, out int max))
{
    Console.WriteLine("Error: You must enter a valid integer.");
    return;
}

// **Teaching Notes**
//  Emphasize the difference between *compile-time* and *runtime* errors  
//  Show students how `TryParse` prevents the program from crashing


  static void Main()
   {
       int[] numbers = { 10, 20, 30, 40 };
       Console.Write("Enter an integer: ");

       // int max = Convert.ToInt32(Console.ReadLine());
       string input = Console.ReadLine();

       if (!int.TryParse(input, out int max))
       {
           Console.WriteLine("Error: You must enter a valid integer.");
           return;
       }

       for (int x = 0; x < max; x++)
       {
           Console.WriteLine($"Index {x}: {numbers[x]}");
       }

       int result = numbers[max] / max;
       Console.WriteLine($"Division result: {result}");
   }



// Exception Scenario #2: Array Index Out of Range**

//### **Concept**
//  If the user enters a number larger than the array length(e.g., `25`),
//  the loop attempts to access elements that don’t exist, causing an** IndexOutOfRangeException**.

//### **Failure Point**

//Console.WriteLine(numbers[x]); // x >= 4 causes exception


//### **Improved Version with Bounds Checking**



for (int x = 0; x<max; x++)
{
    if (x >= numbers.Length)
    {
        Console.WriteLine("Error: Index exceeds array bounds.");
        break;
    }

Console.WriteLine($"Index {x}: {numbers[x]}");
}


// ** Teaching Notes**
// ** Reinforce that arrays are zero‑based  
// Demonstrate how loops can easily exceed array limits if not validated  


    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40 };
        Console.Write("Enter an integer: ");

        // int max = Convert.ToInt32(Console.ReadLine());
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int max))
        {
            Console.WriteLine("Error: You must enter a valid integer.");
            return;
        }

        for (int x = 0; x < max; x++)
        {
            if (x >= numbers.Length)
            {
                Console.WriteLine("Error: Index exceeds array bounds.");
                break;
            }

            Console.WriteLine($"Index {x}: {numbers[x]}");
        }

        for (int x = 0; x < max; x++)
        {
            Console.WriteLine($"Index {x}: {numbers[x]}");
        }

        int result = numbers[max] / max;
        Console.WriteLine($"Division result: {result}");
    }

}



// Divide by Zero
// What happens when you enter a )

/*
 * if (max == 0)
{
    Console.WriteLine("Error: Cannot divide by zero.");
    return;
}
 * 
 */


static void Main()
{
    int[] numbers = { 10, 20, 30, 40 };
    Console.Write("Enter an integer: ");

    // int max = Convert.ToInt32(Console.ReadLine());
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int max))
    {
        Console.WriteLine("Error: You must enter a valid integer.");
        return;
    }

    if (max == 0)
    {
        Console.WriteLine("Error: Cannot divide by zero.");
        return;
    }

    for (int x = 0; x < max; x++)
    {
        if (x >= numbers.Length)
        {
            Console.WriteLine("Error: Index exceeds array bounds.");
            break;
        }

        Console.WriteLine($"Index {x}: {numbers[x]}");
    }

    for (int x = 0; x < max; x++)
    {
        Console.WriteLine($"Index {x}: {numbers[x]}");
    }

    int result = numbers[max] / max;
    Console.WriteLine($"Division result: {result}");
}

}


//Students now understand:

// How runtime exceptions occur  
// How to interpret exception messages  
// How to prevent common errors using input validation and bounds checking  


//***************************
// Part 2 - Throwing and catching exceptions.


// Throwing and catching exceptions is how C# handles unexpected errors during program execution.
// Throwing an exception means the program detects something wrong (like invalid input or a failed operation) and signals the problem by creating an exception object.
// Catching an exception means using a try/catch block to intercept that error so the program can respond gracefully instead of crashing.

//This mechanism allows developers to separate normal program logic from error‑handling logic,
//making applications more robust and easier to maintain


class ThrowCatchDemo
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();

            int value = int.Parse(input);

            if (value <= 0)
            {
                // Manually throw an exception
                throw new ArgumentException("Value must be greater than zero.");
            }

            Console.WriteLine($"You entered: {value}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Input error: You must enter a valid integer.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Program finished.");
        }
    }
}

class ThrowCatchDemo2
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();

            // ❗ This line can trigger a FormatException
            // Happens when the input is NOT a valid integer (e.g., "abc", "2.5", "")
            int value = int.Parse(input);

            // ❗ This condition triggers an ArgumentException (manually thrown)
            // Happens when the number is valid but not positive (e.g., 0 or negative)
            if (value <= 0)
            {
                throw new ArgumentException("Value must be greater than zero.");
            }

            Console.WriteLine($"You entered: {value}");
        }
        catch (FormatException ex)
        {
            // Triggered when int.Parse() fails due to invalid numeric format
            Console.WriteLine("Input error: You must enter a valid integer.");
        }
        catch (ArgumentException ex)
        {
            // Triggered when the manually thrown exception occurs
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Catches any other unexpected exception type
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            // Always runs, even if an exception occurred
            Console.WriteLine("Program finished.");
        }
    }

}


// Tracing Exceptions Through the Call Stack


class PayrollProgram
{
    static void Main()
    {
        try
        {
            ProduceCheck();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception caught in Main!");
            Console.WriteLine("Stack Trace:");
            Console.WriteLine(e.StackTrace);
        }
    }

    static void ProduceCheck()
    {
        double gross = GetGross();
        Console.WriteLine($"Gross pay: {gross}");
    }

    static double GetGross()
    {
        double hours = GetHours();
        double rate = 20.0;
        return hours * rate;
    }

    static double GetHours()
    {
        Console.Write("Enter hours worked: ");
        string input = Console.ReadLine();

        // ❗ This line can throw FormatException
        // Happens if the user enters something that cannot be converted to double
        double hours = Convert.ToDouble(input);

        return hours;
    }
}

/*
 * How This Demonstrates the Call Stack
1. User enters invalid input
        Example: "abc" or "ten"
2. Convert.ToDouble throws a FormatException
        Thrown from inside GetHours()
3. No catch block exists in:
    -GetHours
    - GetGross
    - ProduceCheck
    So the exception keeps moving upward.
4. Exception reaches Main
    Main does have a try/catch, so the exception is caught here.
5. Printing e.StackTrace shows:
*/