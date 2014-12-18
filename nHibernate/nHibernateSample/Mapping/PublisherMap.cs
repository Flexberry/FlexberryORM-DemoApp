using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

using nHibernateSample.Domain;

namespace nHibernateSample.Mapping
{
    public class PublisherMap : ClassMapping<Publisher>
    {
        public PublisherMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
            Property(x => x.Name);
            ManyToOne(
                x => x.Country,
                map =>
                    {
                        map.Column("Country");
                        map.Cascade(Cascade.None);
                    });
        }
    }
}