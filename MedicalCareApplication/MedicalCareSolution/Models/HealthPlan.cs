//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthPlanPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HealthPlan
    {
        
        public int HealthPlanId { get; set; }
        [Display(Name = "Plan Type")]
        public string HealthPlanCode { get; set; }
        [Display(Name = "Plan Description")]
        public string HealthPlanDescription { get; set; }
        [Display(Name = "Required PCP?")]
        public Nullable<bool> PCPrequiredBool { get; set; }
        [Display(Name = "Does your PCP InNetwork")]
        public Nullable<bool> PCPNetworkBool { get; set; }

        public virtual IEnumerable<HealthPlanDetail> HealthPlanDetails { get; set; }
    }
}
