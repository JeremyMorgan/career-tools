//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareerTools.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        public Company()
        {
            this.Jobs = new HashSet<Job>();
        }
    
        public int CompanyID { get; set; }
        public string UserID { get; set; }
        public string CompanyName { get; set; }
    
        public virtual ICollection<Job> Jobs { get; set; }
    }
}