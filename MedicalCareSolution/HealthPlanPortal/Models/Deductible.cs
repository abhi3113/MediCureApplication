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
    
    public partial class Deductible
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deductible()
        {
            this.HealthPlans = new HashSet<HealthPlan>();
        }
    
        public string DeductibleId { get; set; }
        public string DeductibleCode { get; set; }
        public Nullable<decimal> IndividualDedAmt { get; set; }
        public Nullable<decimal> FamilyDedAmt { get; set; }
        public Nullable<decimal> MaxDeductibleAmountPerIndividual { get; set; }
        public Nullable<bool> ServicesCoveredBeforeDeductibleMetBool { get; set; }
        public Nullable<bool> DeductibleIncdInOutOfPcktBool { get; set; }
        public Nullable<bool> AnnualLimitsPlanBool { get; set; }
        public Nullable<decimal> AnnualPremium { get; set; }
        public Nullable<decimal> CoinsuranceUpper { get; set; }
        public Nullable<decimal> CoinsuranceLower { get; set; }
        public Nullable<decimal> AnnualLimitHigher { get; set; }
        public Nullable<decimal> AnnualLimitLower { get; set; }
        public Nullable<decimal> TotalEstimatedCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HealthPlan> HealthPlans { get; set; }
    }
}
