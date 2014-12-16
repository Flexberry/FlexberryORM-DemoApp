using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

using nHibernateSample.Domain;

namespace nHibernateSample.Mapping
{
    public class D23Map : ClassMapping<D23>
    {
        public D23Map()
        {
            Schema("dbo");
            Lazy(true);
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
                        map.PropertyRef("Primarykey");
                        map.Cascade(Cascade.None);
                    });

            Set(
                x => x.D231List,
                colmap =>
                    {
                        colmap.Key(x => x.Column("D23"));
                        colmap.Inverse(true);
                        colmap.Cascade(Cascade.All);
                    },
                map => { map.OneToMany(); });
            Set(
                x => x.D232List,
                colmap =>
                    {
                        colmap.Key(x => x.Column("D23"));
                        colmap.Inverse(true);
                        colmap.Cascade(Cascade.All);
                    },
                map => { map.OneToMany(); });
            Set(
                x => x.D233List,
                colmap =>
                    {
                        colmap.Key(x => x.Column("D23"));
                        colmap.Inverse(true);
                        colmap.Cascade(Cascade.All);
                    },
                map => { map.OneToMany(); });
        }
    }
}