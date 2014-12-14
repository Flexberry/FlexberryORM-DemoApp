using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class D0Map : ClassMapping<D0> {
        
        public D0Map() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Assigned));
			Property(x => x.Name);
			Property(x => x.S1);
			Property(x => x.S2);
			Property(x => x.S3);
			Property(x => x.S4);
			Property(x => x.S5);
			Set(x => x.D1List, colmap =>  { colmap.Key(x => x.Column("D0")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Set(x => x.D2List, colmap =>  { colmap.Key(x => x.Column("D0")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Set(x => x.D3List, colmap =>  { colmap.Key(x => x.Column("D0")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
