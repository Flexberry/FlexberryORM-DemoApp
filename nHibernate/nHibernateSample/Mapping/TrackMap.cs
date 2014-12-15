using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using nHibernateSample.Domain;


namespace nHibernateSample.Mapping {
    
    
    public class TrackMap : ClassMapping<Track> {
        
        public TrackMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
			Property(x => x.Name);
			Property(x => x.Length);
			ManyToOne(x => x.Author, map => { map.Column("Author"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.Singer, map => 
			{
				map.Column("Singer");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

			ManyToOne(x => x.Cdda, map => { map.Column("CDDA"); map.Cascade(Cascade.None); });

        }
    }
}
