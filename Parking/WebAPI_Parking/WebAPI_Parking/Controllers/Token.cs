using System;

namespace WebAPI_Parking.Controllers
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}