//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF6Sample
{
    using System;
    using System.Collections.Generic;
    
    public partial class D13
    {
        public D13()
        {
            this.D131 = new HashSet<D131>();
            this.D132 = new HashSet<D132>();
            this.D133 = new HashSet<D133>();
        }
    
        public System.Guid primaryKey { get; set; }
        public string Name { get; set; }
        public System.Guid D1 { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public string S5 { get; set; }
    
        public virtual D1 D11 { get; set; }
        public virtual ICollection<D131> D131 { get; set; }
        public virtual ICollection<D132> D132 { get; set; }
        public virtual ICollection<D133> D133 { get; set; }
    }
}
