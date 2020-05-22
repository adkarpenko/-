using System;
using System.Runtime.Serialization;
namespace Kursach_AL.Entities
{
    [DataContract]
    public class PurchaseEntity
    {
        [DataMember]
        public string shop;
        [DataMember]
        public double price;
        [DataMember]
        public DateTime dateTime;
        public PurchaseEntity()
        {
            dateTime = DateTime.Now;
        }
    }
}
