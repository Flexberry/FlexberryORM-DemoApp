using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D22 {
        public D22() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D2 D2 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D221> D221List { get; set; }
        public virtual List<D222> D222List { get; set; }
        public virtual List<D223> D223List { get; set; }
    }
}
