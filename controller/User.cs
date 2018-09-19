using System;

namespace _1dv607_W2
{
    class User
    {
        ConsoleView.Event e;
        public bool ManageMember(ConsoleView view, Registry registry)
        {
            view.PresentFirstMsg();

            e = view.GetEvent();

            //TO CREATE A MEMBER
            if (e == ConsoleView.Event.CreateMember)
            {
                string inputName = view.GetName();
                string inputPersonalNum = view.GetPersonalNumber();
                registry.SaveMember(new Member(inputName, inputPersonalNum));
                view.PresentFirstMsg();
                return true;
            }

            //TO EXIT PROGRAM
            if (e == ConsoleView.Event.Exit)
            {
                return false;
            }
            if (e == ConsoleView.Event.VerboseList)
            {
                Console.WriteLine("TESTAR...");
                // Vidare...
                //var memberList = registry.GetVerboseList();
                //view.PresentVerboseList();
                return true;
            }
            return true;
        }
    }
}
