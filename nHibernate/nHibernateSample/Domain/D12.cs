using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D12 : D
    {
        public virtual D1 D1 { get; set; }
        public virtual IEnumerable<D121> D121List { get; set; }
        public virtual IEnumerable<D122> D122List { get; set; }
        public virtual IEnumerable<D123> D123List { get; set; }
    }
}