using System;
using System.Collections.Generic;
using System.Xml;

namespace _1dv607_W2
{
    class Registry
    {
        private XmlDocument _doc = new XmlDocument();
        private List<Member> _members = new List<Member>();

        // TESTING XML...
        public List<string> getCompactList()
        {

            _doc.Load(@"./members.xml");
            string xmlcontents = _doc.InnerXml;
            List<string> list = new List<string>();

            XmlNodeList memberNodes = _doc.SelectNodes("//memberRegistry/member");
            foreach (XmlNode memberNode in memberNodes)
            {
                int id = int.Parse(memberNode.Attributes["id"].Value);
                string name = memberNode.Attributes["name"].Value;
                string pNumber = memberNode.Attributes["personalNumber"].Value;
                int numberOfBoats = 0;
                //foreach(XmlNode child in memberNode.ChildNodes)
                //{
                //    numberOfBoats += 1;
                //}
                list.Add(name + " " + id);
            }
            return list;
        }
        public void saveMember(Member member)
        {
            // GLÖM EJ!: Iterera alla ID:n, ta ut största talet, + 1
        
            int id = _doc.SelectNodes("//memberRegistry/member").Count + 1;

            _doc.Load(@"./members.xml");

            XmlNode memberRegistry = _doc.SelectSingleNode("//memberRegistry");

            XmlElement xmlMember = _doc.CreateElement("member");
            xmlMember.SetAttribute("id", id.ToString());
            xmlMember.SetAttribute("name", member.Name);
            xmlMember.SetAttribute("personalNumber", member.PersonalNumber);

            memberRegistry.AppendChild(xmlMember);

            _doc.Save(@"./members.xml");
        }
        private List<Member> getMembers()
        {
            // returnera lista med medlemmar som innehåller all info
            // iterera alla medlemmar i xml, plocka ut info och skapa nya medlemmar,
            // populera listan med medlemmar och båtar

            return new List<Member>();
        }
    }
}
