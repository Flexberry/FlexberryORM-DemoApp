using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D32 : D
    {
        public virtual D3 D3 { get; set; }
        public virtual IEnumerable<D321> D321List { get; set; }
        public virtual IEnumerable<D322> D322List { get; set; }
        public virtual IEnumerable<D323> D323List { get; set; }
    }
}