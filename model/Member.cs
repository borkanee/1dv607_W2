using System;
using System.Xml;
using System.Linq;

namespace _1dv607_W2
{
    class Member
    {
        private readonly int _id;
        private string _name;
        private string _personalNumber;

        private XmlDocument _doc = new XmlDocument();

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 15 || value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Name is to long or to short");
                }
                _name = value;
            }
        }
        public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("You must enter a 10-digit personal number");
                }
                _personalNumber = value;
            }
        }

        public Member()
        {
            _id = _doc.SelectNodes("//memberRegistry/member").Count + 1;
        }

        public void Create(string inputName, string inputPersonalNumber)
        {
            Name = inputName;
            PersonalNumber = inputPersonalNumber;

            WriteToXml();
        }

        private void WriteToXml()
        {
            _doc.Load(@"./members.xml");

            XmlNode memberRegistry = _doc.SelectSingleNode("//memberRegistry");


            // GLÖM EJ!: Iterera alla ID:n, ta ut största talet, + 1

            XmlElement member = _doc.CreateElement("member");
            member.SetAttribute("id", _id.ToString());
            member.SetAttribute("name", _name);
            member.SetAttribute("personalNumber", _personalNumber);

            memberRegistry.AppendChild(member);

            _doc.Save(@"./members.xml");
        }
    }
}