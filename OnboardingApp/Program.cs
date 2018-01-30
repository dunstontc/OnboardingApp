using System;

namespace OnboardingApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var theUser = new User();
            theUser.First = PromptInput("What is your first name?");
            theUser.Last = PromptInput("What is your last name?");
            theUser.IsAccountOwner = AskBool("Are you the owner of this account?");
            Console.Write(theUser.DescribeUser());
        }

        private static string PromptInput(string prompt)
        {
            Console.Clear();
            Console.ResetColor();
            
            Console.WriteLine(prompt);
            
            return Console.ReadLine();
        }
        
        // NOTE: rather than simplify this, it would be better to use an existing library. But I don't imagine this will be a console app long enough to do that.
        public static bool AskBool(string prompt)
        {
            // Exit from program if CTL+C is pressed.
            Console.TreatControlCAsInput = false;

            ConsoleKeyInfo cki;

            var answer = false;
            var thePrompt = $"{prompt}\n(Y or N): ";

            Console.Clear();
            Console.Write(thePrompt);

            do
            {
                cki = Console.ReadKey();
                Console.ResetColor();

                string res;
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
            return answer;
        }
    }
}
