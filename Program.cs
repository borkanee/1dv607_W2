using System;

namespace _1dv607_W2
{
    class Program
    {
        static void Main(string[] args)
        {
                ConsoleView view = new ConsoleView();
                User user = new User();
                Registry registry = new Registry();

                while (user.ManageMember(view, registry));
            

            /* catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            */

        }
    }
}