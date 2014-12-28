using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D1 : D
    {
        public virtual D0 D0 { get; set; }
        public virtual IEnumerable<D11> D11List { get; set; }
        public virtual IEnumerable<D12> D12List { get; set; }
        public virtual IEnumerable<D13> D13List { get; set; }
    }
}