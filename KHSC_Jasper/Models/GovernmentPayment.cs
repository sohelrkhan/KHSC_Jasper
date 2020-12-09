using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class GovernmentPayment
    {
        public int GpId { get; set; }
        public string MonthName { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
