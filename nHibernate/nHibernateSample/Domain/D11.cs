using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D11 {
        public D11() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D1 D1 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D111> D111List { get; set; }
        public virtual List<D112> D112List { get; set; }
        public virtual List<D113> D113List { get; set; }
    }
}
