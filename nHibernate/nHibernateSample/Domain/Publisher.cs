using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class Publisher
    {
        public Publisher()
        {
        }

        public virtual System.Guid Primarykey { get; set; }
        public virtual Country Country { get; set; }
        public virtual string Name { get; set; }
    }
}