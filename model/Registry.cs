using System;
using System.Xml;

namespace _1dv607_W2
{
    class Registry
    {
        

        // TESTING XML...
        public static void getCompactList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"./members.xml");
            string xmlcontents = doc.InnerXml;
            Console.WriteLine(xmlcontents);

            XmlNodeList memberNodes = doc.SelectNodes("//memberRegistry/member");
            foreach (XmlNode memberNode in memberNodes)
            {
                int id = int.Parse(memberNode.Attributes["id"].Value);
                string name = memberNode.Attributes["name"].Value;
                string pNumber = memberNode.Attributes["personalNumber"].Value;
                Console.WriteLine(id + " " + name + " " + pNumber);
                //memberNode.Attributes["age"].Value = (age + 1).ToString();
            }
            //doc.Save(@"./members.xml");
        }
    }
}
