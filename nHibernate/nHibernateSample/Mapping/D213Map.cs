using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class D213Map : ClassMapping<D213> {
        
        public D213Map() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
			Property(x => x.Name);
			Property(x => x.S1);
			Property(x => x.S2);
			Property(x => x.S3);
			Property(x => x.S4);
			Property(x => x.S5);
			ManyToOne(x => x.D21, map => { map.Column("D21"); map.Cascade(Cascade.None); });

        }
    }
}
