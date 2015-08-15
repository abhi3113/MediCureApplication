//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganizationPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeePolicy
    {
        public string EmployeePolicyId { get; set; }
        public string EmployeeId { get; set; }
        public string EnrollmentTypeId { get; set; }
        public string HealthPlanId { get; set; }
        public string OrganizationId { get; set; }
        public Nullable<System.DateTime> DateOfHire { get; set; }
        public Nullable<System.DateTime> QualifyingEventDate { get; set; }
        public Nullable<System.DateTime> EffectiveDateOfCoverage { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}
