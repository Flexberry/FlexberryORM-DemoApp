using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class D21 : D
    {
        public virtual D2 D2 { get; set; }
        public virtual IEnumerable<D211> D211List { get; set; }
        public virtual IEnumerable<D212> D212List { get; set; }
        public virtual IEnumerable<D213> D213List { get; set; }
    }
}