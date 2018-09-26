using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _1dv607_W2
{
    public class ConsoleView
    {
        public enum Event
        {
            CreateMember,
            List,
            Exit,
            VerboseList,
            MemberInfo,
            ShowMenu,
            DeleteMember,
            None,

        }

        public void PresentFirstMsg()
        {
            //Console.Clear();
            Console.WriteLine("Welcome to the Jolly Pirate Yacht Club");
            Console.WriteLine("To exit the program: press e");
            Console.WriteLine("To create a member: press c");
            Console.WriteLine("");
            Console.WriteLine("To get a compact list: press l");
            Console.WriteLine("To get a verbose list: press v");
        }

        public void PresentCompactList(ReadOnlyCollection<Member> members)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Enter member id for member information, to return press m");
            Console.WriteLine("Compact list:");
            foreach (Member member in members)
            {
                Console.WriteLine($"Name: {member.Name}, Id: {member.Id}, Number of boats: {member.Boats.Count}");
            };


        }

        public void PresentMemberInfo(Member member)
        {
            Console.WriteLine($@"
- - - - - - - - - - - - - - - -
Id: {member.Id}
Name: {member.Name}
Personal number: {member.PersonalNumber} 
Number of boats: {member.Boats.Count}");

            foreach (Boat boat in member.Boats)
            {
                Console.WriteLine($"Boat type: {boat.Type}, Boat length: {boat.Length}");
            };
            Console.WriteLine("- - - - - - - - - - - - - - - -");
        }

        public string GetId()
        {
            return Console.ReadLine();
        }

        public void PresentVerboseList(ReadOnlyCollection<Member> members)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Enter member id for member information");
            Console.WriteLine("Verbose list:");
            foreach (Member member in members)
            {
                {
                    Console.WriteLine($"Name: {member.Name}, Id: {member.Id}, Personal number: {member.PersonalNumber}");
                    foreach (Boat boat in member.Boats)
                    {
                        Console.WriteLine($"Boat type: {boat.Type}, Boat length: {boat.Length}");
                    };
                };
            }
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
            if (character == 'l')
            {
                return Event.List;
            }
            if (character == 'v')
            {
                return Event.VerboseList;
            }
            if (character == 'e')
            {
                return Event.Exit;
            }
            if (character == 'd')
            {
                return Event.DeleteMember;
            }

            return Event.None;
        }
    }
}