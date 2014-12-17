using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

using nHibernateSample.Domain;

namespace nHibernateSample.Mapping
{
    public class D22Map : ClassMapping<D22>
    {
        public D22Map()
        {
            Schema("dbo");
            Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
            Property(x => x.Name);
            Property(x => x.S1);
            Property(x => x.S2);
            Property(x => x.S3);
            Property(x => x.S4);
            Property(x => x.S5);
            ManyToOne(
                x => x.D2,
                map =>
                    {
                        map.Column("D2");
                        map.Cascade(Cascade.None);
                    });

            Set(
                x => x.D221List,
                colmap =>
                    {
                        colmap.Key(x => x.Column("D22"));
                        colmap.Inverse(true);
                        colmap.Cascade(Cascade.All);
                    },
                map => { map.OneToMany(); });
            Set(
                x => x.D222List,
                colmap =>
                    {
                        colmap.Key(x => x.Column("D22"));
                        colmap.Inverse(true);
                        colmap.Cascade(Cascade.All);
                    },
                map => { map.OneToMany(); });
            Set(
                x => x.D223List,
                colmap =>
                    {
                        colmap.Key(x => x.Column("D22"));
                        colmap.Inverse(true);
                        colmap.Cascade(Cascade.All);
                    },
                map => { map.OneToMany(); });
        }
    }
}