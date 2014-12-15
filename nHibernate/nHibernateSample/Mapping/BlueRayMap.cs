using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class BlueRayMap : ClassMapping<BlueRay> {
        
        public BlueRayMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
			Property(x => x.Capacity);
			Property(x => x.Name);
			ManyToOne(x => x.Publisher, map => { map.Column("Publisher"); map.Cascade(Cascade.None); });

        }
    }
}
