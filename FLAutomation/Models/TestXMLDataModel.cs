using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAutomation.Models
{
   public class TestXMLDataModel
    {
        public string Postcode { get; set; }
        public string CarPlateNumber { get; set; }
        public string Mileage { get; set; }
        public List<string> Services { get; set; }
        public string AditionalInfo { get; set; }
        public string CollectionSlotTime { get; set; }
        public string DeliverySlotTime { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }
}
