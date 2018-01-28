using System;

namespace OnboardingApp
{
    enum Choices_One
    {
        Yes,
        No
    };
    
    enum Choices_Two
    {
        Yes,
        No,
        Maybe
    };
    
    class Program
    {
        static void Main(string[] args)
        {
            var theUser = new User();
            theUser.First = AskQuestion("What is your first name?");
            theUser.Last = AskQuestion("What is your last name?");
            theUser.IsAccount = AskBool("Is this a personal account?");
            Console.WriteLine(theUser.FullName());
        }

        private static string AskQuestion(string req)
        {
            Console.WriteLine(req);
            return Console.ReadLine();
        }
        
        public static bool AskBool(string prompt)
        {
            // Exit from program if CTL+C is pressed.
            Console.TreatControlCAsInput = false;
            
            ConsoleKeyInfo cki;
            
            var res = "";
            var answer = false;
            var thePrompt = $"{prompt}\n(Y or N): ";
            
            Console.Clear();
            Console.Write(thePrompt);
            
            do 
            {
                cki = Console.ReadKey();
                Console.ResetColor();
                
                switch (cki.KeyChar)
                {
                    case 'y':
                    case 'Y':
                        res = "Yes";
                        answer = true;
                        Console.Clear();
                        Console.ResetColor();
                        Console.Write(thePrompt);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(res);
                        Console.ResetColor();
                        Console.Write(" (press enter to confirm)");
                        break;
                    case 'n':
                    case 'N':
                        res = "No";
                        answer = false;
                        Console.Clear();
                        Console.ResetColor();
                        Console.Write(thePrompt);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(res);
                        Console.ResetColor();
                        Console.Write(" (press enter to confirm)");
                        break;
                    default:
                        Console.Clear();
                        Console.Write(thePrompt);
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.Enter);

            Console.Clear();
            Console.WriteLine($"You answered {res}.");
            return answer;

        }

        private static string AskEnum<T>(string prompt) where T : struct, IConvertible, IComparable, IFormattable
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new Exception();
            }

            foreach (var test in Enum.GetValues(type))
            {
                Console.WriteLine("Testing " + test);
            }

            return "";
        }
    }
}