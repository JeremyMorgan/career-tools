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
    
    public partial class Term
    {
        public Term()
        {
            this.Jobs = new HashSet<Job>();
        }
    
        public int TermId { get; set; }
        public string TermName { get; set; }
    
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
