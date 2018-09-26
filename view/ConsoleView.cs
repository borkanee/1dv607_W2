using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            NewBoat,
            ListBoats,
            MemberChange,
            DeleteBoat,
            BoatInformation,
            EnterId,
            None,

        }

        public void PresentFirstMsg()
        {
            Console.Clear();
            Console.WriteLine($@"
WELCOME TO THE JOLLY PIRATE YACHT CLUB


To exit the program write 'exit'.
To create a member write 'create'.
To get a compact list write 'list'.
To get a verbose list write 'verbose'.
");
        }

        public void PresentCompactList(ReadOnlyCollection<Member> members)
        {
            Console.Clear();
            Console.WriteLine($@"
COMPACT LIST:
- - - - - - - - - - - - - - - -");
            foreach (Member member in members)
            {
                Console.WriteLine($"Name: {member.Name}, Id: {member.Id}, Number of boats: {member.Boats.Count}");
            };
            Console.WriteLine($@"
- - - - - - - - - - - - - - - -
Do you want to view a specific member information write 'yes'.
To return to main menu enter any other key.
");

        }

        public void PresentMemberInfo(Member member)
        {
            Console.Clear();
            Console.WriteLine($@"
MEMBER:
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
            Console.WriteLine($@"
To delete member write 'delete'.
To change information about member write 'change'.
To add a boat write 'new boat'.
To show boat menu write 'boats'.

To return to main menu enter any other key.
");
        }

        public void PresentBoatTypes()
        {
            Console.Clear();
            int counter = 1;
            var values = Enum.GetValues(typeof(BoatType));
            foreach (var value in values)
            {
                Console.WriteLine(counter.ToString() + " " + value);
                counter++;
            }
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine("Select a boat type by entering the number");
        }
        public BoatType GetBoatType()
        {
            int number = int.Parse(Console.ReadLine());
            BoatType type = (BoatType)number;

            return type;
        }

        public int GetBoatLength()
        {
            Console.Clear();
            Console.WriteLine("Enter the length of your boat:");
            int length = int.Parse(Console.ReadLine());

            return length;
        }

        public int GetId(ReadOnlyCollection<Member> members)
        {
            Console.Write("Enter the id: ");
            int num;
            bool isInt = int.TryParse(Console.ReadLine(), out num);
            bool validId = members.Where(member => member.Id == num).ToList().Count != 0;

            while (!(isInt && validId))
            {
                Console.Write("Please enter a valid id: ");
                isInt = int.TryParse(Console.ReadLine(), out num);
                validId = members.Where(member => member.Id == num).ToList().Count != 0;
            }
            return num;

        }

        public void PresentVerboseList(ReadOnlyCollection<Member> members)
        {
            Console.Clear();
            Console.WriteLine($@"
VERBOSE LIST:
- - - - - - - - - - - - - - - -");
            foreach (Member member in members)
            {
                {
                    Console.WriteLine($"Name: {member.Name}, Id: {member.Id}, Personal number: {member.PersonalNumber}");
                    foreach (Boat boat in member.Boats)
                    {
                        Console.WriteLine($"    Boat id: {boat.Id}, boat type: {boat.Type}, boat length: {boat.Length}");
                    };
                    Console.WriteLine("- - - - - - - - - - - - - - - -");
                };
            }
            Console.WriteLine($@"
Do you want to view a specific member information write 'yes'.
To return to main menu enter any other key.
");
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

        public void PresentBoats(ReadOnlyCollection<Boat> boats)
        {
            Console.Clear();
            Console.WriteLine($@"
BOATS:
- - - - - - - - - - - - - - - -");
            foreach (Boat boat in boats)
            {
                Console.WriteLine($"Boat id: {boat.Id}, boat type: {boat.Type}, boat length: {boat.Length}");
            };
            Console.WriteLine($@"
- - - - - - - - - - - - - - - -
Do you want to manage a boat write 'yes'.
Enter any other key to return to main menu.
");
        }

        public void PresentBoat(Boat boat)
        {
            Console.Clear();
            Console.WriteLine($@"
BOAT:
- - - - - - - - - - - - - - - -
Boat id: {boat.Id}, boat type: {boat.Type}, boat length: {boat.Length}
- - - - - - - - - - - - - - - -
To delete boat write 'delete boat'.
To change information about the boat write 'boat information'.
");
        }

        public Event GetEvent()
        {
            string inputString = System.Console.ReadLine();
            if (inputString == "create")
            {
                return Event.CreateMember;
            }
            if (inputString == "list")
            {
                return Event.List;
            }
            if (inputString == "verbose")
            {
                return Event.VerboseList;
            }
            if (inputString == "exit")
            {
                return Event.Exit;
            }
            if (inputString == "delete")
            {
                return Event.DeleteMember;
            }
            if (inputString == "change")
            {
                return Event.MemberChange;
            }
            if (inputString == "new boat")
            {
                return Event.NewBoat;
            }

            if (inputString == "boats")
            {
                return Event.ListBoats;
            }
            if (inputString == "delete boat")
            {
                return Event.DeleteBoat;
            }
            if (inputString == "boat information")
            {
                return Event.BoatInformation;
            }
            if (inputString == "yes")
            {
                return Event.EnterId;
            }

            return Event.None;
        }
    }
}