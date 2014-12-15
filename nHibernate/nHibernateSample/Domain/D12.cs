using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D12 {
        public D12() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D1 D1 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D121> D121List { get; set; }
        public virtual List<D122> D122List { get; set; }
        public virtual List<D123> D123List { get; set; }
    }
}
