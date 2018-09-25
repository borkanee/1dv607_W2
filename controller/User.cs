using System;
using System.Collections.Generic;

namespace _1dv607_W2
{
    public class User
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
                registry.AddMember(inputName, inputPersonalNum);
                view.PresentFirstMsg();
                return true;
            }

            //TO GET A COMPACT LIST
            if (e == ConsoleView.Event.List)
            {
                List<Member> members = registry.GetMembers();
                view.PresentCompactList(members);

                int memberId = int.Parse(view.GetId());
                Member member = registry.GetMemberInfo(memberId);
                view.PresentMemberInfo(member);

                return true;
            }

            //TO GET A VERBOSE LIST
            if (e == ConsoleView.Event.VerboseList)
            {
                List<Member> members = registry.GetMembers();
                view.PresentVerboseList(members);
                return true;
            }

            //TO VIEW MEMBER INFO
            if (e == ConsoleView.Event.MemberInfo)
            {
                // TODO:...
            }

            //TO DELETE A MEMBER
            if (e == ConsoleView.Event.DeleteMember)
            {
                // TODO:...
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
