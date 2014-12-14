using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D3 {
        public D3() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D0 D0 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public List<D31> D31List { get; set; }
        public List<D32> D32List { get; set; }
        public List<D33> D33List { get; set; }
    }
}
