using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D32 {
        public D32() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D3 D3 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public List<D321> D321List { get; set; }
        public List<D322> D322List { get; set; }
        public List<D323> D323List { get; set; }
    }
}
