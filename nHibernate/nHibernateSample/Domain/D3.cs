using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D3 : D
    {
        public virtual D0 D0 { get; set; }
        public virtual IEnumerable<D31> D31List { get; set; }
        public virtual IEnumerable<D32> D32List { get; set; }
        public virtual IEnumerable<D33> D33List { get; set; }
    }
}