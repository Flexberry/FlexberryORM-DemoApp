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
    
    public partial class D2
    {
        public D2()
        {
            this.D21 = new HashSet<D21>();
            this.D22 = new HashSet<D22>();
            this.D23 = new HashSet<D23>();
        }
    
        public System.Guid primaryKey { get; set; }
        public string Name { get; set; }
        public System.Guid D0 { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public string S5 { get; set; }
    
        public virtual D0 D01 { get; set; }
        public virtual ICollection<D21> D21 { get; set; }
        public virtual ICollection<D22> D22 { get; set; }
        public virtual ICollection<D23> D23 { get; set; }
    }
}
