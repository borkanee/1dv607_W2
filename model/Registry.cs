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
        public void getCompactList()
        {

            // Varför hämta och spara allt för varenda operation?
            // Så länge programmet körs kommer ändrad data finnas i minnet?

            GetMembers();
            _doc.Load(@"./members.xml");
            string xmlcontents = _doc.InnerXml;
            Console.WriteLine(xmlcontents);

            XmlNodeList memberNodes = _doc.SelectNodes("//memberRegistry/member");
            foreach (XmlNode memberNode in memberNodes)
            {
                int id = int.Parse(memberNode.Attributes["id"].Value);
                string name = memberNode.Attributes["name"].Value;
                string pNumber = memberNode.Attributes["personalNumber"].Value;
                Console.WriteLine(id + " " + name + " " + pNumber);
                //memberNode.Attributes["age"].Value = (age + 1).ToString();
                // _members.Add(new Member());

                // RETURNERA LISTA TILL CONTROLLER? Kopia? KURS 1dv024?
            }
            //doc.Save(@"./members.xml");
        }

        public IEnumerable<Member> GetVerboseList()
        {
            for (int i = 0; i < 10; i++)
            {
                _members.Add(new Member("Hejhej", "9191919191"));
            }
            return _members;
        }

        public void SaveMember(Member member)
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
        private List<Member> GetMembers()
        {
            // returnera lista med medlemmar som innehåller all info
            // iterera alla medlemmar i xml, plocka ut info och skapa nya medlemmar,
            // populera listan med medlemmar och båtar

            return new List<Member>();
        }
        public void WriteToXml()
        {
            /*

             int id = _doc.SelectNodes("//memberRegistry/member").Count + 1;

             _doc.Load(@"./members.xml");

             XmlNode memberRegistry = _doc.SelectSingleNode("//memberRegistry");

             XmlElement xmlMember = _doc.CreateElement("member");
             xmlMember.SetAttribute("id", id.ToString());
             xmlMember.SetAttribute("name", member.Name);
             xmlMember.SetAttribute("personalNumber", member.PersonalNumber);

             memberRegistry.AppendChild(xmlMember);

             _doc.Save(@"./members.xml");
             */
        }
    }
}
