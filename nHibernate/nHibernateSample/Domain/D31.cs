using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D31 : D
    {
        public virtual D3 D3 { get; set; }
        public virtual IEnumerable<D311> D311List { get; set; }
        public virtual IEnumerable<D312> D312List { get; set; }
        public virtual IEnumerable<D313> D313List { get; set; }
    }
}