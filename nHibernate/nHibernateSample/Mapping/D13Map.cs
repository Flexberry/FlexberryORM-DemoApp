using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class D13Map : ClassMapping<D13> {
        
        public D13Map() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Assigned));
			Property(x => x.Name);
			Property(x => x.S1);
			Property(x => x.S2);
			Property(x => x.S3);
			Property(x => x.S4);
			Property(x => x.S5);
			ManyToOne(x => x.D1, map => 
			{
				map.Column("D1");
				map.PropertyRef("Primarykey");
				map.Cascade(Cascade.None);
			});

			Set(x => x.D131List, colmap =>  { colmap.Key(x => x.Column("D13")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Set(x => x.D132List, colmap =>  { colmap.Key(x => x.Column("D13")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Set(x => x.D133List, colmap =>  { colmap.Key(x => x.Column("D13")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
