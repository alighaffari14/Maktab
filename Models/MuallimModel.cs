using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundingMaktab.Models
{
    public class MuallimModel
    {
        public int Muallim_Id { get; set; }
        public string Name { get; set; }
        public string Father_Name { get; set; }
        public string Deeni_Taleem { get; set; }
        public string Dunyawi_Taleem { get; set; }
        public string Contact_Number { get; set; }
        public string Madrisah_Education_Name { get; set; }
        public string Office_Id { get; set; }
    }
}