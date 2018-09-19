using System;

namespace _1dv607_W2
{
    class User
    {
        ConsoleView.Event e;
        public bool ManageMember(ConsoleView view, Member member)
        {
            view.PresentFirstMsg();

            e = view.GetEvent();

            //TO CREATE A MEMBER
            if (e == ConsoleView.Event.CreateMember)
            {
                string inputName = view.GetName();
                string inputPersonalNum = view.GetPersonalNumber();
                member.Create(inputName, inputPersonalNum);
                view.PresentFirstMsg();
                return true;
            }

            //TO EXIT PROGRAM
            if (e == ConsoleView.Event.Exit)
            {
                return false;
            }
            return false;
        }
    }
}
