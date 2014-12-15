using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class DVDMap : ClassMapping<DVD> {
        
        public DVDMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
			Property(x => x.Version);
			Property(x => x.Capacity);
			Property(x => x.Name);
			ManyToOne(x => x.Publisher, map => { map.Column("Publisher"); map.Cascade(Cascade.None); });

        }
    }
}
