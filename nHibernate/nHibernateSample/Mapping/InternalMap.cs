using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

using nHibernateSample.Domain;

namespace nHibernateSample.Mapping
{
    public class InternalMap : ClassMapping<Internal>
    {
        public InternalMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.Primarykey, map => map.Generator(Generators.Guid));
            Property(x => x.S0);
            Property(x => x.S1);
            Property(x => x.S2);
            Property(x => x.S3);
            Property(x => x.S4);
            Property(x => x.S5);
            Property(x => x.S6);
            Property(x => x.S7);
            Property(x => x.S8);
            Property(x => x.S9);

            ManyToOne(
                x => x.Master0,
                map =>
                    {
                        map.Column(c => c.Name("MasterSpecial_m0"));
                        map.NotNullable(true);
                        map.Cascade(Cascade.None);
                    });

            //ManyToOne(x => x.Masterderived01, map => 
            //{
            //    map.Column("MasterSpecial_m1");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

            //ManyToOne(x => x.Masterderived02, map => 
            //{
            //    map.Column("MasterSpecial_m2");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

            //ManyToOne(x => x.Masterderived03, map => 
            //{
            //    map.Column("MasterSpecial_m3");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

            ManyToOne(
                x => x.Master01,
                map =>
                    {
                        map.Column("Master01");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master02,
                map =>
                    {
                        map.Column("Master02");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master03,
                map =>
                    {
                        map.Column("Master03");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master04,
                map =>
                    {
                        map.Column("Master04");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master05,
                map =>
                    {
                        map.Column("Master05");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master06,
                map =>
                    {
                        map.Column("Master06");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master07,
                map =>
                    {
                        map.Column("Master07");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master08,
                map =>
                    {
                        map.Column("Master08");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master09,
                map =>
                    {
                        map.Column("Master09");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master10,
                map =>
                    {
                        map.Column("Master10");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master11,
                map =>
                    {
                        map.Column("Master11");
                        map.Cascade(Cascade.None);
                    });

            ManyToOne(
                x => x.Master12,
                map =>
                    {
                        map.Column("Master12");
                        map.Cascade(Cascade.None);
                    });
        }
    }
}