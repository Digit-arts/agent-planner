//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgentPlanner.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quotation
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int ClientId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public byte ContractTypeId { get; set; }
        public double BillingRate { get; set; }
        public byte BillingFrequencyId { get; set; }
        public bool NightTimeRateIncrease { get; set; }
        public bool SundayRateIncrease { get; set; }
        public bool PublicHolidayRateIncrease { get; set; }
        public System.DateTime DateAdded { get; set; }
        public double TotalHours { get; set; }
        public double TotalCost { get; set; }
        public string HoursPerDay { get; set; }
    
        public virtual BillingFrequency BillingFrequency { get; set; }
        public virtual Client Client { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual Site Site { get; set; }
    }
}