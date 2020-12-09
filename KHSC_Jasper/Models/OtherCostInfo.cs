using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class OtherCostInfo
    {
        public int OcId { get; set; }
        public DateTime Date { get; set; }
        public string ElectricityBillMonthName { get; set; }
        public int? ElectricityBillAmount { get; set; }
        public string WaterBillMonth { get; set; }
        public int? WaterBillAmount { get; set; }
        public int? ItBill { get; set; }
        public int? FunctionCost { get; set; }
        public int? ScienceFairCost { get; set; }
        public int? StudyTourCost { get; set; }
        public int? PoorFund { get; set; }
        public int? SchoolDev { get; set; }
        public int? SchoolMaintenance { get; set; }
        public int? ServicingCharge { get; set; }
        public int? AnyCostName { get; set; }
        public int? AnyCostFee { get; set; }
    }
}
