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
    
    public partial class PreventiveCare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PreventiveCare()
        {
            this.HealthPlans = new HashSet<HealthPlan>();
        }
    
        public string PreventiveCareId { get; set; }
        public Nullable<decimal> PhysicalExamLimit { get; set; }
        public Nullable<decimal> RoutinePediatricCareLimit { get; set; }
        public Nullable<decimal> ImmunizationLimit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HealthPlan> HealthPlans { get; set; }
    }
}
