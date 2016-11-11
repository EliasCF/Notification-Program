using System;
using System.Xml;
using System.Xml.Linq;

namespace Notification_Program.XML
{
    class XmlHandler
    {
        //Write the set time to Time.xml
        public void WriteToXML(String[] Text, String Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path); //Load Time.xml

            String Date = Text[0] + " " + Text[1] + ":" + Text[2] + ":" + Text[3]; //Creat a String containing the set time

            doc.SelectSingleNode("Main/Date").InnerText = Date; //Write the set time
            doc.SelectSingleNode("Main/Message").InnerText = Text[4]; //Write the message

            doc.Save(Path); //Save the changes to Time.xml
        }

        public DateTime GetXML(String Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path); //Load Time.xml

            if(doc.SelectSingleNode("Main/Date").InnerText.Equals(""))
            {
                return DateTime.MinValue; //Return the minumum DateTime value (01-01-0001 00:00:00)
            }

            return Convert.ToDateTime(doc.SelectSingleNode("Main/Date").InnerText); //Return the Time.xml date node
        }
            
        //Check if the Hours/Minutes/Seconds nodes in Time.xml are empty
        public bool XmlIsEmpty(String Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path); //Load Time.xml

            if(GetXML(Path).Equals(DateTime.MinValue)) //If the nodes are empty, then return true
            {
                return true;
            }

            return false; //If nodes are not empty then return false
        }

        //Create Time.xml in the current directory
        public void CreateTimeXml(String Path)
        {
            XDocument doc = new XDocument(
                new XElement("Main",
                    new XElement("Date", ""),
                    new XElement("Message", "")));

            doc.Save(Path);
        }
    }
}