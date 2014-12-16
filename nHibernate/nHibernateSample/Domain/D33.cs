using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D33 : D
    {
        public virtual D3 D3 { get; set; }
        public virtual IEnumerable<D331> D331List { get; set; }
        public virtual IEnumerable<D332> D332List { get; set; }
        public virtual IEnumerable<D333> D333List { get; set; }
    }
}