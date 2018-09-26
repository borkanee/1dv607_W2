using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

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
            // TODO: om inget id, returnera felmedd...
            return GetMembers().Where(member => member.Id == memberId).Last();
        }

        //private List<Member> _members;

        public void AddMember(string inputName, string inputPersonalNum)
        {
            int id = getMemberId();

            XmlNode memberRegistry = _doc.SelectSingleNode("//memberRegistry");

            XmlElement xmlMember = _doc.CreateElement("member");
            xmlMember.SetAttribute("id", id.ToString());
            xmlMember.SetAttribute("name", inputName);
            xmlMember.SetAttribute("personalNumber", inputPersonalNum);

            memberRegistry.AppendChild(xmlMember);

            _doc.Save(@"./members.xml");
        }

        private int getMemberId()
        {
            XmlNode memberRegistry = _doc.SelectSingleNode("//memberRegistry");
            var id = int.Parse(memberRegistry.LastChild.Attributes["id"].Value);
            return id + 1;
        }
        public ReadOnlyCollection<Member> GetMembers()
        {
            // string xmlcontents = _doc.InnerXml;
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
                    BoatType boatType = (BoatType) Enum.Parse(typeof(BoatType), typeString);
                    // Console.WriteLine(boatType);
                    int length = int.Parse(boat.Attributes["length"].Value);
                    int boatId = int.Parse(boat.Attributes["id"].Value);
                    boats.Add(new Boat(boatType, length, boatId));
                }

                members.Add(new Member(name, pNumber, id, boats));
            }
            return members.AsReadOnly();
        }

        public void ChangeMember(int newId, string newName, string newPersonalNumber)
        {
            // string xmlcontents = _doc.InnerXml;

            XmlNodeList memberNodes = _doc.SelectNodes("//memberRegistry/member");
            foreach (XmlNode memberNode in memberNodes)
            {
                if (int.Parse(memberNode.Attributes["id"].Value) == newId) {
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
                if (int.Parse(memberNode.Attributes["id"].Value) == memberId) {
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
                if (int.Parse(memberNode.Attributes["id"].Value) == memberId) {
                    memberNode.AppendChild(xmlBoat);
                }
            }
            _doc.Save(@"./members.xml");
        }

        private int getBoatId()
        {
            var maxId = _doc.SelectNodes("//member/boat")
              .Cast<XmlElement>()
              .Max(boat => Int32.Parse(boat.Attributes["id"].Value));
            return maxId + 1;
        }

        public void DeleteBoat(int boatId)
        {
            XmlNodeList boatNodes = _doc.SelectNodes("//member/boat");
            foreach (XmlNode boatNode in boatNodes)
            {
                if (int.Parse(boatNode.Attributes["id"].Value) == boatId) {
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
                if (int.Parse(boatNode.Attributes["id"].Value) == boatId) {
                    boatNode.Attributes["type"].Value = boatType.ToString();
                    boatNode.Attributes["length"].Value = boatLength.ToString();
                }
            }
            _doc.Save(@"./members.xml");

        }
    }
}
