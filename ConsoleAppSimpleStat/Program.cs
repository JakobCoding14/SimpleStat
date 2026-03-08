using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
                                                                    
 class Program
{
    static List<decimal> dataList = new();

    static void Main(string[] args)
    {
        CollectInput();
    }

    static void CollectInput()
    {
        Console.WriteLine("Welcome to the Simple Statistics Console App!");
        Console.WriteLine("Please enter the data values to be shown in statistics");
        Console.WriteLine("------------------------------------------------------");
        while (true)
        {
            string userloopInput;
            decimal convertedloopInput;
            Console.Clear();
            Console.WriteLine("Please enter decimal/integer number to be included in the statistic");
            Console.WriteLine("Enter the word DONE to end the input and show the statistics with the given data");
            userloopInput = Console.ReadLine().ToUpper();


            if (userloopInput == "DONE") // If the user wants is done with input and wants to see the statistic of the given numbers
            {
               if (dataList.Count == 0)
               {
                    Console.WriteLine("You entered no data");
                    Console.WriteLine("Press any key to continue data input");
                    Console.ReadKey();
                    continue;
               }
                ManageStatCalculation();
                break;
            }

            else if (!decimal.TryParse(userloopInput, out convertedloopInput)) // Guard clause: If the user enters string
            {
                Console.WriteLine("Input was in the wrong format \n Press any key to continue data input");
                Console.ReadKey();
                continue;
            }

            dataList.Add(convertedloopInput);
        }
    }

    static void ManageStatCalculation()
    {
        

         // Deconstruction
         decimal savemaxVal = CalculateMax();
         decimal saveminVal = CalculateMin();
         (int savecounterTotalInput, decimal savearithmeticAverage) = CalculateArithmeticAverage();

        PrintStats(savecounterTotalInput, savearithmeticAverage, savemaxVal, saveminVal);
    }

    static decimal CalculateMax()
    {
        var maxVal = dataList[0];
        foreach(decimal number in dataList)
        {
            if (number > maxVal)
            {
                maxVal = number;
            }

        }

        return maxVal;
    }

    static decimal CalculateMin()
    {
        var minVal = dataList[0];
        foreach (decimal number in dataList)
        {
            if (number < minVal)
            {
                minVal = number;
            }
        }

        return minVal;
    }

    static (int, decimal) CalculateArithmeticAverage()
    {
        // Calculate Arithmetic Average, Total Number of inputs. Then return the values as a tuple to be printed in the PrintStats method

        int counterTotalInput = 0;
        decimal arithmeticAverage = 0;
        decimal sumOfInputs = 0;

        foreach (decimal number in dataList)
        {
           counterTotalInput++;
           sumOfInputs += number;
        }

        if (counterTotalInput > 0 )
        {
           arithmeticAverage = sumOfInputs / counterTotalInput;
        }

        return (counterTotalInput, arithmeticAverage); 
    }

    static void PrintStats(int savecounterTotalInput, decimal savearithmeticAverage, decimal savemaxVal, decimal saveminVal)
    {
        // Print the statistics 
        Console.Clear();
        Console.WriteLine("Statistics of the data input");
        Console.WriteLine($"Highest Value:        {savemaxVal}");
        Console.WriteLine($"Lowest Value:         {saveminVal}");
        Console.WriteLine($"Total number of data: {savecounterTotalInput}");
        Console.WriteLine($"Arithmetic Average:   {savearithmeticAverage}");
        Console.WriteLine("----------------------------------------------------------");
    }

}
