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

            XmlNodeList userNodes = doc.SelectNodes("//users/user");
            foreach (XmlNode userNode in userNodes)
            {
                int age = int.Parse(userNode.Attributes["age"].Value);
                userNode.Attributes["age"].Value = (age + 1).ToString();
            }
            doc.Save(@"./members.xml");

            Console.WriteLine(doc);
        }
    }
}
