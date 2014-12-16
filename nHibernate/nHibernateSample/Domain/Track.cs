using System;
using System.Text;
using System.Collections.Generic;

namespace nHibernateSample.Domain
{
    public class Track
    {
        public virtual System.Guid Primarykey { get; set; }
        public virtual Person Author { get; set; }
        public virtual Person Singer { get; set; }
        public virtual CDDA Cdda { get; set; }
        public virtual string Name { get; set; }
        public virtual int? Length { get; set; }
    }
}