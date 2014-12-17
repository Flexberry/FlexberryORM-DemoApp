using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

using nHibernateSample.Domain;

namespace nHibernateSample.Mapping
{
    public class Masterderived02Map : UnionSubclassMapping<Masterderived02>
    {
        public Masterderived02Map()
        {
            Schema("dbo");
            Lazy(false);
            Property(x => x.S0);
            Property(x => x.S1);
            Property(x => x.S2);
            Property(x => x.S3);
            Property(x => x.S4);
            Property(x => x.S5);
            Property(x => x.S6);
            Property(x => x.S7);
            Property(x => x.S8);
            Property(x => x.S9);
        }
    }
}