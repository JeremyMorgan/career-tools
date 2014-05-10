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
    
    public partial class Event
    {
        public int EventID { get; set; }
        public string UserID { get; set; }
        public int ContactFK { get; set; }
        public int JobFK { get; set; }
        public int TypeFK { get; set; }
        public System.DateTime Date { get; set; }
        public int StageFK { get; set; }
        public string Notes { get; set; }
    
        public virtual Contact Contact { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Job Job { get; set; }
        public virtual Stage Stage { get; set; }
    }
}