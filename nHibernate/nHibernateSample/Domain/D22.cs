using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D22 : D
    {
        public virtual D2 D2 { get; set; }
        public virtual IEnumerable<D221> D221List { get; set; }
        public virtual IEnumerable<D222> D222List { get; set; }
        public virtual IEnumerable<D223> D223List { get; set; }
    }
}