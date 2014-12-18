using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D11 : D
    {
        public virtual D1 D1 { get; set; }
        public virtual IEnumerable<D111> D111List { get; set; }
        public virtual IEnumerable<D112> D112List { get; set; }
        public virtual IEnumerable<D113> D113List { get; set; }
    }
}