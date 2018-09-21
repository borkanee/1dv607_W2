using System;
using System.Collections.Generic;

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
                registry.saveMember(new Member(inputName, inputPersonalNum));
                view.PresentFirstMsg();
                return true;
            }

            //TO GET A COMPACT LIST
            if (e == ConsoleView.Event.List)
            {
                List<string> compactList = registry.getCompactList();
                Console.Write(compactList);
                view.PresentCompactList(compactList);
                return true;
            }

            //TO EXIT PROGRAM
            if (e == ConsoleView.Event.Exit)
            {
                return false;
            }

            
            //OR ELSE
            return false;
        }
    }
}
