using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D0 {
        public D0() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D1> D1List { get; set; }
        public virtual List<D2> D2List { get; set; }
        public virtual List<D3> D3List { get; set; }
    }
}
