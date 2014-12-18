using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D23 : D
    {
        public virtual D2 D2 { get; set; }
        public virtual IEnumerable<D231> D231List { get; set; }
        public virtual IEnumerable<D232> D232List { get; set; }
        public virtual IEnumerable<D233> D233List { get; set; }
    }
}