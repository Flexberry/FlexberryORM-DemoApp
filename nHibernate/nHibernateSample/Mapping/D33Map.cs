using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class D33Map : ClassMapping<D33> {
        
        public D33Map() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
			Property(x => x.Name);
			Property(x => x.S1);
			Property(x => x.S2);
			Property(x => x.S3);
			Property(x => x.S4);
			Property(x => x.S5);
			ManyToOne(x => x.D3, map => { map.Column("D3"); map.Cascade(Cascade.None); });

			Set(x => x.D331List, colmap =>  { colmap.Key(x => x.Column("D33")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Set(x => x.D332List, colmap =>  { colmap.Key(x => x.Column("D33")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Set(x => x.D333List, colmap =>  { colmap.Key(x => x.Column("D33")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
