using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D31 {
        public D31() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D3 D3 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public List<D311> D311List { get; set; }
        public List<D312> D312List { get; set; }
        public List<D313> D313List { get; set; }
    }
}
