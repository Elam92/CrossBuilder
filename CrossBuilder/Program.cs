using System;

namespace Cross
{ 
    // Users can input an integer number to build a a Cross/X onto the console.
    class Program
    {
        static void Main(string[] args)
        {
            IPrint crossBuilder = new CrossBuilder();
            IValidator inputValidator = new IntValidator();

            Console.WriteLine("Welcome to Cross Builder!");
            Console.WriteLine("Please input an integer height of your cross! Enter nothing to quit.");

            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                // Validate input before building the tree.
                if (inputValidator.Validate(input)) {
                    int inputHeight = int.Parse(input);
                    crossBuilder.Print(inputHeight);

                    Console.WriteLine("Input another integer height for a new cross! Enter nothing to quit.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
