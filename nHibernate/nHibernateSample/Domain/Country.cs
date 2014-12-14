using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class Country {
        public Country() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual string Name { get; set; }
    }
}
