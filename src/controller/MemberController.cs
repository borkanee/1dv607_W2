using System.Collections.ObjectModel;

namespace _1dv607_W2
{
    public class MemberController
    {
        ConsoleView.Event e;

        public bool ManageMember(ConsoleView view, Registry registry)
        {
            view.PresentFirstMsg();
            e = view.GetEvent();

            //CREATE A MEMBER
            if (e == ConsoleView.Event.CreateMember)
            {
                string inputName = view.GetName();
                string inputPersonalNum = view.GetPersonalNumber();
                registry.AddMember(inputName, inputPersonalNum);
                view.PresentFirstMsg();
                return true;
            }

            //SHOW LISTS
            if (e == ConsoleView.Event.List || e == ConsoleView.Event.VerboseList)
            {
                ReadOnlyCollection<Member> members = registry.GetMembers();
                if (e == ConsoleView.Event.List)
                {
                    view.PresentCompactList(members);
                }
                if (e == ConsoleView.Event.VerboseList)
                {
                    view.PresentVerboseList(members);
                }

                e = view.GetEvent();

                // SHOW MEMBER INFO
                if (e == ConsoleView.Event.EnterId)
                {
                    int memberId = view.GetId(members);
                    Member member = registry.GetMemberInfo(memberId);
                    view.PresentMemberInfo(member);

                    e = view.GetEvent();

                    // CHANGE MEMBER
                    if (e == ConsoleView.Event.MemberChange)
                    {
                        string inputName = view.GetName();
                        string inputPersonalNum = view.GetPersonalNumber();
                        registry.ChangeMember(memberId, inputName, inputPersonalNum);

                    }

                    // DELETE MEMBER
                    if (e == ConsoleView.Event.DeleteMember)
                    {
                        registry.DeleteMember(memberId);
                    }

                    // ADD A BOAT
                    if (e == ConsoleView.Event.NewBoat)
                    {
                        view.PresentBoatTypes();
                        BoatType boatType = view.GetBoatType();
                        int boatLength = view.GetBoatLength();
                        registry.AddBoat(memberId, boatType, boatLength);
                    }

                    // LIST BOATS
                    if (e == ConsoleView.Event.ListBoats)
                    {
                        view.PresentBoats(member.Boats);
                        e = view.GetEvent();

                        // SHOW BOAT INFORMATION
                        if (e == ConsoleView.Event.EnterId)
                        {
                            int boatId = view.GetId(member.Boats);
                            view.PresentBoat(member.GetBoat(boatId));

                            e = view.GetEvent();

                            // CHANGE BOAT
                            if (e == ConsoleView.Event.ChangeBoat)
                            {
                                view.PresentBoatTypes();
                                BoatType boatType = view.GetBoatType();
                                int boatLength = view.GetBoatLength();
                                registry.ChangeBoat(boatId, boatType, boatLength);
                            }

                            // DELETE BOAT
                            if (e == ConsoleView.Event.DeleteBoat)
                            {
                                registry.DeleteBoat(boatId);
                            }
                        }
                    }
                }
                return true;
            }

            //TO EXIT PROGRAM
            if (e == ConsoleView.Event.Exit)
            {
                return false;
            }
            return true;
        }
    }
}
