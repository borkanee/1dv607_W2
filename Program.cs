using System;

namespace _1dv607_W2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConsoleView view = new ConsoleView();
                MemberController memberController = new MemberController();
                Registry registry = new Registry();

                while (memberController.ManageMember(view, registry)) ;
            }
            catch (ArgumentOutOfRangeException ex)
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
        }
    }
}