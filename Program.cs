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
                User user = new User();
                Member member = new Member();

                while (user.ManageMember(view, member)) ;
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