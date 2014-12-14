using System;
using System.Text;
using System.Collections.Generic;


namespace nHibernateSample.Domain {
    
    public class Person {
        public Person() { }
        public virtual System.Guid Primarykey { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
    }
}
