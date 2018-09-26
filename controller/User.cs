using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

                if (e == ConsoleView.Event.EnterId)
                {
                    int memberId = view.GetId(members);
                    Member member = registry.GetMemberInfo(memberId);
                    view.PresentMemberInfo(member);

                    e = view.GetEvent();

                    if (e == ConsoleView.Event.MemberChange) {
                        string inputName = view.GetName();
                        string inputPersonalNum = view.GetPersonalNumber();
                        registry.ChangeMember(memberId, inputName, inputPersonalNum);

                    }
                    if (e == ConsoleView.Event.DeleteMember) {
                        registry.DeleteMember(memberId);
                    }
                    if (e == ConsoleView.Event.NewBoat) {
                        view.PresentBoatTypes();
                        BoatType boatType = view.GetBoatType();
                        int boatLength = view.GetBoatLength();
                        registry.AddBoat(memberId, boatType, boatLength);
                    }
                    if (e == ConsoleView.Event.ListBoats) {
                        view.PresentBoats(member.Boats);
                        e = view.GetEvent();

                        if (e == ConsoleView.Event.EnterId)
                        {
                            int boatId = view.GetId(members);

                            foreach (Boat boat in member.Boats)
                            {
                                if (boat.Id == boatId)
                                {
                                    view.PresentBoat(boat);
                                }
                            }
                            e = view.GetEvent();
                            if (e == ConsoleView.Event.BoatInformation)
                            {
                                view.PresentBoatTypes();
                                BoatType boatType = view.GetBoatType();
                                int boatLength = view.GetBoatLength();
                                registry.ChangeBoat(boatId, boatType, boatLength);
                            }
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
            //OR ELSE
            return true;
        }
    }
}
