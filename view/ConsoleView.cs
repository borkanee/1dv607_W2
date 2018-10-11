using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

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
            DeleteMember,
            NewBoat,
            ListBoats,
            MemberChange,
            DeleteBoat,
            ChangeBoat,
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

        public void PresentBoats(ReadOnlyCollection<Boat> boats)
        {
            Console.Clear();
            if (boats.Count == 0)
            {
                Console.WriteLine($@"
THERE ARE NO BOATS
- - - - - - - - - - - - - - - -
Enter any other key to return to main menu.
");
            }
            else
            {
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
To change information about the boat write 'change boat'.
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
            Console.Write("Select a boat type by entering the number: ");
        }

        public BoatType GetBoatType()
        {
            int num;

            bool isInt = int.TryParse(Console.ReadLine(), out num);
            bool validId = num == 1 || num == 2 || num == 3 || num == 4;

            while (!(isInt && validId))
            {
                Console.Write("Please enter a valid number: ");
                isInt = int.TryParse(Console.ReadLine(), out num);
                validId = num == 1 || num == 2 || num == 3 || num == 4;
            }

            BoatType type = (BoatType)num;

            return type;
        }

        public int GetBoatLength()
        {
            Console.Write("Enter the length of your boat: ");
            int num;

            bool isInt = int.TryParse(Console.ReadLine(), out num);
            bool validLength = num > 1 && num < 21;

            while (!(isInt && validLength))
            {
                Console.Write("Please enter a length between 2-20: ");
                isInt = int.TryParse(Console.ReadLine(), out num);
                validLength = num > 1 && num < 21;
            }

            return num;
        }

        public int GetId(ReadOnlyCollection<Member> members)
        {
            Console.Write("Enter the id: ");
            int num;
            int empty = 0;
            bool isInt = int.TryParse(Console.ReadLine(), out num);
            bool validId = members.Count(member => member.Id == num) != empty;

            while (!(isInt && validId))
            {
                Console.Write("Please enter a valid id: ");
                isInt = int.TryParse(Console.ReadLine(), out num);
                validId = members.Count(member => member.Id == num) != empty;
            }
            return num;
        }

        public int GetId(ReadOnlyCollection<Boat> boats)
        {
            Console.Write("Enter the id: ");
            int num;
            int empty = 0;
            bool isInt = int.TryParse(Console.ReadLine(), out num);
            bool validId = boats.Count(boat => boat.Id == num) != empty;

            while (!(isInt && validId))
            {
                Console.Write("Please enter a valid id: ");
                isInt = int.TryParse(Console.ReadLine(), out num);
                validId = boats.Count(boat => boat.Id == num) != empty;
            }
            return num;
        }

        public string GetPersonalNumber()
        {
            Console.Write("Enter your personal number (YYMMDDNNNN): ");
            string stringInput = Console.ReadLine();

            while (!Regex.IsMatch(stringInput, @"[0-9]{2}(0[1-9]|(10|11|12))(0[1-9]|[1-2][0-9]|3[0-1])[0-9]{4}$"))
            {
                Console.Write("Please enter a valid personal number (YYMMDDNNNN): ");
                stringInput = Console.ReadLine();
            }
            return stringInput;
        }

        public string GetName()
        {
            string name = "";

            while (name.Length > 15 || name.Length < 2)
            {
                Console.Clear();
                Console.Write("Enter your name (min 2 characters, max 15 characters): ");
                name = Console.ReadLine();
            }
            return name;
        }

        public Event GetEvent()
        {
            string inputString = System.Console.ReadLine();
            Event e;
            switch (inputString)
            {
                case "create":
                    e = Event.CreateMember;
                    break;
                case "list":
                    e = Event.List;
                    break;
                case "verbose":
                    e = Event.VerboseList;
                    break;
                case "exit":
                    e = Event.Exit;
                    break;
                case "delete":
                    e = Event.DeleteMember;
                    break;
                case "change":
                    e = Event.MemberChange;
                    break;
                case "new boat":
                    e = Event.NewBoat;
                    break;
                case "boats":
                    e = Event.ListBoats;
                    break;
                case "delete boat":
                    e = Event.DeleteBoat;
                    break;
                case "change boat":
                    e = Event.ChangeBoat;
                    break;
                case "yes":
                    e = Event.EnterId;
                    break;
                default:
                    e = Event.None;
                    break;
            }
            return e;
        }
    }
}