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
    
    public partial class D11
    {
        public D11()
        {
            this.D111 = new HashSet<D111>();
            this.D112 = new HashSet<D112>();
            this.D113 = new HashSet<D113>();
        }
    
        public System.Guid primaryKey { get; set; }
        public string Name { get; set; }
        public System.Guid D1 { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public string S5 { get; set; }
    
        public virtual D1 D12 { get; set; }
        public virtual ICollection<D111> D111 { get; set; }
        public virtual ICollection<D112> D112 { get; set; }
        public virtual ICollection<D113> D113 { get; set; }
    }
}