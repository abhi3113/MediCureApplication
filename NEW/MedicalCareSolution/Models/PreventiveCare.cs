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
    
    public partial class PreventiveCare
    {
        public int PreventiveCareId { get; set; }
        [Display(Name = "Physical Exam Limit")]
        public Nullable<decimal> PhysicalExamLimit { get; set; }
        [Display(Name = "Routine Pediatric Care Limit")]
        public Nullable<decimal> RoutinePediatricCareLimit { get; set; }
        [Display(Name = "Immunization Limit")]
        public Nullable<decimal> ImmunizationLimit { get; set; }
        [Display(Name = "Health Plan Type")]
        public Nullable<int> HealthPlanId { get; set; }
    
        public virtual HealthPlan HealthPlan { get; set; }
    }
}
