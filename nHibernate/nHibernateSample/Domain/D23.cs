using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D23 {
        public D23() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D2 D2 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D231> D231List { get; set; }
        public virtual List<D232> D232List { get; set; }
        public virtual List<D233> D233List { get; set; }
    }
}
