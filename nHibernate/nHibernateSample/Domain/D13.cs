using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D13 {
        public D13() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D1 D1 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D131> D131List { get; set; }
        public virtual List<D132> D132List { get; set; }
        public virtual List<D133> D133List { get; set; }
    }
}
