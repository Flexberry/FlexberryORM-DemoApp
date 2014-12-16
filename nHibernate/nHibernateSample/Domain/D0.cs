using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D0 : D
    {
        public virtual IEnumerable<D1> D1List { get; set; }
        public virtual IEnumerable<D2> D2List { get; set; }
        public virtual IEnumerable<D3> D3List { get; set; }
    }
}