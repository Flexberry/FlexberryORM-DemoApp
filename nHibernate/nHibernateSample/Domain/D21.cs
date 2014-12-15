using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D21 {
        public D21() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D2 D2 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public virtual List<D211> D211List { get; set; }
        public virtual List<D212> D212List { get; set; }
        public virtual List<D213> D213List { get; set; }
    }
}
