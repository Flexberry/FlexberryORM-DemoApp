using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D33 {
        public D33() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D3 D3 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D331> D331List { get; set; }
        public virtual List<D332> D332List { get; set; }
        public virtual List<D333> D333List { get; set; }
    }
}
