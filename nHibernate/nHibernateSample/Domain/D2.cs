using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D2 {
        public D2() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D0 D0 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public List<D21> D21List { get; set; }
        public List<D22> D22List { get; set; }
        public List<D23> D23List { get; set; }
    }
}
