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
            string xmlcontents = _doc.InnerXml;
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
                    string type = boat.Attributes["type"].Value;
                    int length = int.Parse(boat.Attributes["length"].Value);
                    boats.Add(new Boat(type, length));
                }

                members.Add(new Member(name, pNumber, id, boats));
            }
            return members.AsReadOnly();
        }
    }
}
