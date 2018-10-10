using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;

namespace _1dv607_W2
{
    public class Registry
    {
        private XmlDocument _doc;

        public Registry()
        {
            _doc = new XmlDocument();
            _doc.Load(@"./members.xml");
        }

        public Member GetMemberInfo(int memberId)
        {
            return GetMembers().Where(member => member.Id == memberId).Last();
        }

        public ReadOnlyCollection<Member> GetMembers()
        {
            List<Member> members = new List<Member>();

            XmlNodeList memberNodes = _doc.SelectNodes("//memberRegistry/member");
            foreach (XmlNode memberNode in memberNodes)
            {
                List<Boat> boats = new List<Boat>();
                int id = int.Parse(memberNode.Attributes["id"].Value);
                string name = memberNode.Attributes["name"].Value;
                string pNumber = memberNode.Attributes["personalNumber"].Value;

                foreach (XmlNode boat in memberNode.ChildNodes)
                {
                    string typeString = boat.Attributes["type"].Value;
                    BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), typeString);
                    int length = int.Parse(boat.Attributes["length"].Value);
                    int boatId = int.Parse(boat.Attributes["id"].Value);
                    boats.Add(new Boat(boatType, length, boatId));
                }

                members.Add(new Member(name, pNumber, id, boats));
            }
            return members.AsReadOnly();
        }

        public void AddMember(string inputName, string inputPersonalNum)
        {
            int id = GetMemberId();

            XmlNode memberRegistry = _doc.SelectSingleNode("//memberRegistry");

            XmlElement xmlMember = _doc.CreateElement("member");
            xmlMember.SetAttribute("id", id.ToString());
            xmlMember.SetAttribute("name", inputName);
            xmlMember.SetAttribute("personalNumber", inputPersonalNum);

            memberRegistry.AppendChild(xmlMember);

            _doc.Save(@"./members.xml");
        }

        private int GetMemberId()
        {
            int memberId;
            XmlNodeList members = _doc.SelectNodes("//memberRegistry/member");
            if (members.Count == 0)
            {
                memberId = 1;
            }
            else
            {
                memberId = members
             .Cast<XmlElement>()
             .Max(member => int.Parse(member.Attributes["id"].Value)) + 1;

            }
            return memberId;
        }

        public void ChangeMember(int newId, string newName, string newPersonalNumber)
        {

            XmlNodeList memberNodes = _doc.SelectNodes("//memberRegistry/member");
            foreach (XmlNode memberNode in memberNodes)
            {
                if (int.Parse(memberNode.Attributes["id"].Value) == newId)
                {
                    memberNode.Attributes["name"].Value = newName;
                    memberNode.Attributes["personalNumber"].Value = newPersonalNumber;
                }
            }
            _doc.Save(@"./members.xml");

        }

        public void DeleteMember(int memberId)
        {
            XmlNodeList memberNodes = _doc.SelectNodes("//memberRegistry/member");
            foreach (XmlNode memberNode in memberNodes)
            {
                if (int.Parse(memberNode.Attributes["id"].Value) == memberId)
                {
                    memberNode.ParentNode.RemoveChild(memberNode);
                }
            }
            _doc.Save(@"./members.xml");

        }

        public void AddBoat(int memberId, BoatType boatType, int boatLength)
        {
            int boatId = getBoatId();

            XmlNodeList memberNodes = _doc.SelectNodes("//memberRegistry/member");

            XmlElement xmlBoat = _doc.CreateElement("boat");
            xmlBoat.SetAttribute("id", boatId.ToString());
            xmlBoat.SetAttribute("type", boatType.ToString());
            xmlBoat.SetAttribute("length", boatLength.ToString());

            foreach (XmlNode memberNode in memberNodes)
            {
                if (int.Parse(memberNode.Attributes["id"].Value) == memberId)
                {
                    memberNode.AppendChild(xmlBoat);
                }
            }
            _doc.Save(@"./members.xml");
        }

        private int getBoatId()
        {
            int boatId;
            XmlNodeList boats = _doc.SelectNodes("//member/boat");

            if (boats.Count == 0)
            {
                boatId = 1;
            }
            else
            {
                boatId = boats
                .Cast<XmlElement>()
                .Max(boat => int.Parse(boat.Attributes["id"].Value)) + 1;
            }
            return boatId;
        }

        public void DeleteBoat(int boatId)
        {
            XmlNodeList boatNodes = _doc.SelectNodes("//member/boat");
            foreach (XmlNode boatNode in boatNodes)
            {
                if (int.Parse(boatNode.Attributes["id"].Value) == boatId)
                {
                    boatNode.ParentNode.RemoveChild(boatNode);
                }
            }
            _doc.Save(@"./members.xml");
        }

        public void ChangeBoat(int boatId, BoatType boatType, int boatLength)
        {
            XmlNodeList boatNodes = _doc.SelectNodes("//member/boat");
            foreach (XmlNode boatNode in boatNodes)
            {
                if (int.Parse(boatNode.Attributes["id"].Value) == boatId)
                {
                    boatNode.Attributes["type"].Value = boatType.ToString();
                    boatNode.Attributes["length"].Value = boatLength.ToString();
                }
            }
            _doc.Save(@"./members.xml");

        }
    }
}
