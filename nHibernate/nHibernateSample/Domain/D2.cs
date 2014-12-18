using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D2 : D
    {
        public virtual D0 D0 { get; set; }
        public virtual IEnumerable<D21> D21List { get; set; }
        public virtual IEnumerable<D22> D22List { get; set; }
        public virtual IEnumerable<D23> D23List { get; set; }
    }
}