using System;

namespace _1dv607_W2
{
    public class ConsoleView
    {
        public enum Event
        {
            CreateMember,
            Exit,
            None
        }

        public void PresentFirstMsg()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Jolly Pirate Yacht Club");
            Console.WriteLine("Press e if you want to exit the program");
            Console.WriteLine("Press c to create a member");
        }

        public string GetPersonalNumber()
        {
            string personalNumber = "";

            while (personalNumber.Length != 10)
            {
                Console.Clear();
                Console.WriteLine("Enter your personal number (10 digit):");
                personalNumber = Console.ReadLine();
            }
            return personalNumber;
        }

        public string GetName()
        {
            string name = "";

            while (name.Length > 15 || name.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Enter your name (min 2 characters, max 15 characters):");
                name = Console.ReadLine();
            }
            return name;
        }

        public Event GetEvent()
        {
            char character = System.Console.ReadKey().KeyChar;
            if (character == 'c')
            {
                return Event.CreateMember;
            }
            if (character == 'e')
            {
                return Event.Exit;
            }
            return Event.None;
        }
    }
}