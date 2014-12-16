using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D13 : D
    {
        public virtual D1 D1 { get; set; }
        public virtual IEnumerable<D131> D131List { get; set; }
        public virtual IEnumerable<D132> D132List { get; set; }
        public virtual IEnumerable<D133> D133List { get; set; }
    }
}