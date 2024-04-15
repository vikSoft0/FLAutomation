using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Xml.Linq;
using FLAutomation.Models;
namespace FLAutomation.ComponentHelper
{
    public class TestDataReaderHelper
    {
       
        public static TestXMLDataModel ReadTestDataXML()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string testDataLocation = dir.Replace("bin\\Debug\\", "TestData\\BookingData.xml");

            XDocument doc = XDocument.Load(testDataLocation);

            // Parse XML and extract data
            XElement dataElement = doc.Element("Root").Element("CreateBookingData");
     
            // Create instance of Person class and assign data
            TestXMLDataModel modelData = new TestXMLDataModel
            {
                Postcode = dataElement.Element("Postcode").Value,
                CarPlateNumber = dataElement.Element("CarPlateNumber").Value,
                Mileage = dataElement.Element("Mileage").Value,
                //Services = dataElement.Element("Postcode").Value,
                AditionalInfo = dataElement.Element("AditionalInfo").Value,
                CollectionSlotTime= dataElement.Element("CollectionSlotTime").Value,
                DeliverySlotTime= dataElement.Element("DeliverySlotTime").Value,
                UserName= dataElement.Element("UserName").Value,
                Mobile = dataElement.Element("Mobile").Value,
                Email = dataElement.Element("Email").Value,

            };
            modelData.Services = new List<string>();
            // Populate the service list
            foreach (XElement serviceElement in dataElement.Element("Services").Elements("service"))
            {
                modelData.Services.Add(serviceElement.Value);
            }
            return modelData;
        }
    }
}
