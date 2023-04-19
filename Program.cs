using System.Xml.Schema;

namespace DiceRoller
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the dice Roller!");
            Console.WriteLine();
            bool goOn = true;
            while (goOn == true)
            {
                Console.WriteLine("Please select the dice you wish to roll by entering a number (our dice range from D4 to D20):");
                bool tryRoll = false;
                int roll = -1;

                while (tryRoll == false)
                {
                    try
                    {
                        roll = int.Parse(Console.ReadLine());
                        tryRoll = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please try again, only valid integers may be entered.");
                    }

                    if (roll < 0 || roll > 20)
                    {
                        Console.WriteLine("We only have dice with sides in the range of 4 to 20");
                        Console.WriteLine("Please enter a number within the range:");
                        tryRoll = false;
                    }
                }
                int d1 = DiceRoll(roll);
                int d2 = DiceRoll(roll);
                int total = d1 + d2;
                Console.WriteLine($"First die (D{roll}): {d1}");
                Console.WriteLine($"Second die (D{roll}): {d2}");
                Console.WriteLine("Total: " + total);
                if (roll == 6)
                {
                    Console.WriteLine(SixSidedCombos(d1, d2));
                    Console.WriteLine((SixedSidedWins(total))); ;
                }
                goOn = Continue();
            }



        }
        public static int DiceRoll(int sides)
        {
            Random r = new Random();
            return r.Next(1, sides);
        }
        public static bool Continue()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to roll again? y/n");
            string input = Console.ReadLine().ToLower().Trim();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("GoodBye!");
                return false;
            }
            else
            {
                Console.WriteLine("Enter y or n...it says it right there. :|");
                return Continue();
            }


        }
        public static string SixSidedCombos(int d1, int d2)
        {

            if (d1 == 1 && d2 == 1)
            {
                return "Snake Eyes!";
            }
            else if (d2 == 6 && d2 == 6)
            {
                return ("Box Cars!");
            }
            else if (d1 == 1 && d2 == 2)
            {
                return ("Ace Deuce!");
            }
            else if (d1 == 2 && d2 == 1)
            {
                return ("Ace Deuce!");
            }
            else
            {
                return ("");

            }
        }
        public static string SixedSidedWins(int total)
        {
            if (total == 7 || total == 11)
            {
                return ("WIN!");
            }
            else if (total == 2 || total == 3 || total == 12)
            {
                return ("Craps!");
            }
            else
            {
                return "";
            }
        }
    } 
}