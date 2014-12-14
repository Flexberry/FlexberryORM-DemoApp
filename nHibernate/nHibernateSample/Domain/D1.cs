using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class D1 {
        public D1() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual D0 D0 { get; set; }
        public virtual string Name { get; set; }
        public virtual string S1 { get; set; }
        public virtual string S2 { get; set; }
        public virtual string S3 { get; set; }
        public virtual string S4 { get; set; }
        public virtual string S5 { get; set; }
        public List<D11> D11List { get; set; }
        public List<D12> D12List { get; set; }
        public List<D13> D13List { get; set; }
    }
}
