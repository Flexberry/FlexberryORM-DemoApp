using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class D131Map : ClassMapping<D131> {
        
        public D131Map() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Assigned));
			Property(x => x.Name);
			Property(x => x.S1);
			Property(x => x.S2);
			Property(x => x.S3);
			Property(x => x.S4);
			Property(x => x.S5);
			ManyToOne(x => x.D13, map => 
			{
				map.Column("D13");
				map.PropertyRef("Primarykey");
				map.Cascade(Cascade.None);
			});

        }
    }
}
