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
    
    public partial class Stage
    {
        public Stage()
        {
            this.Events = new HashSet<Event>();
        }
    
        public int StageID { get; set; }
        public string StageName { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }
    }
}
