namespace EF6Sample
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Main application form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initialize form components.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CDLIBEntities dbctx = new CDLIBEntities();

            dbctx.Database.Log = (s => { textBox1.AppendText(string.Format("{0}{1}", s, Environment.NewLine)); });

            DVD[] cddas = dbctx.DVD.ToArray();
            //DVD[] cddas = dbctx.DVD.Include("Publisher1").Include(@"Publisher1.Country1").ToList().ToArray();

            for (int i = 0; i < cddas.Length; i++ )
            { 
                textBox1.AppendText(cddas[i].Publisher1.Name);
                textBox1.AppendText(Environment.NewLine);
            }

            MessageBox.Show("OK!");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            CDLIBEntities dbctx = new CDLIBEntities();
            dbctx.Database.Log = (s => { textBox1.AppendText(s); });
            DVD_D[] sfhsdjk = dbctx.DVD.Select(x => new DVD_D { primaryKey = x.primaryKey, Name = x.Name, Publisher1 = new Publisher_D { Name = x.Publisher1.Name } }).ToArray();

            // Здесь большая странность ЕФа:
            // Нельзя прочитать у сущностей только некотрые свойства, только через анонимный класс или какой-то другой. 
            // В любом случае, если дальше нужно сохранить изменения через объект надо маппировать значения свойств из типа в котором прочитали в тип, который знает контекст ЕФ


            //sfhsdjk.ToArray().
            
            //DVD dvd = new DVD();
            //dvd.primaryKey = sfhsdjk[0].PrimaryKey;
            //dvd.Название = "оыцущззцщшлцукщз";
            //dbctx.DVD.Attach(dvd);
            //dbctx.SaveChanges();


            //sfhsdjk[0].Name = "123456";
            //sfhsdjk[0].Publisher1.Name   = "123456";
            //dbctx.DVD.Attach((DVD)sfhsdjk[0]);
            //dbctx.SaveChanges();

            MessageBox.Show("OK");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CDLIBEntities dbctx = new CDLIBEntities();

            Guid pkey = Guid.Parse("018FF5D0-0EB7-4E0F-B836-227D7E32425D");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            D0 d0 = dbctx.D0
                .Include("D1.D11.D111").Include("D1.D11.D112").Include("D1.D11.D113")
                .Include("D1.D12.D121").Include("D1.D12.D122").Include("D1.D12.D123")
                .Include("D1.D13.D131").Include("D1.D13.D132").Include("D1.D13.D133")
                .Include("D2.D21.D211").Include("D2.D21.D212").Include("D2.D21.D213")
                .Include("D2.D22.D221").Include("D2.D22.D222").Include("D2.D22.D223")
                .Include("D2.D23.D231").Include("D2.D23.D232").Include("D2.D23.D233")
                .Include("D3.D31.D311").Include("D3.D31.D312").Include("D3.D31.D313")
                .Include("D3.D32.D321").Include("D3.D32.D322").Include("D3.D32.D323")
                .Include("D3.D33.D331").Include("D3.D33.D332").Include("D3.D33.D333")                
                .Where(x => x.primaryKey == pkey).First() ;

            stopwatch.Stop();

            MessageBox.Show(string.Format("OK. Time taken: {0}", stopwatch.ElapsedMilliseconds));

            //dbctx.Database.Log = (s => { textBox1.AppendText(string.Format("{0}{1}", s, Environment.NewLine)); });
            
            //textBox1.AppendText(((D111)((D11)((D1)d0.D1.First()).D11.First()).D111.First()).Name);

            MessageBox.Show("OK");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CDLIBEntities dbctx = new CDLIBEntities();

            D0 d0 = new D0();
            
            GenDetails(d0, 10, "D", dbctx);

            DateTime starttime = DateTime.Now;
            dbctx.D0.Add(d0);
            dbctx.SaveChanges();
            MessageBox.Show(string.Format("OK. Time taken: {0}", DateTime.Now.Subtract(starttime)));

            MessageBox.Show("OK");
        }

        private void GenDetails(object obj, int QtyInEach, string basedetailname, CDLIBEntities dbctx)
        {
            Type objtype = obj.GetType();

            Guid thisid = Guid.NewGuid();

            objtype.GetProperty("primaryKey").SetValue(obj, thisid);

            SetRandPropVal(obj, "Name");
            SetRandPropVal(obj, "S1");
            SetRandPropVal(obj, "S2");
            SetRandPropVal(obj, "S3");
            SetRandPropVal(obj, "S4");
            SetRandPropVal(obj, "S5");

            if (basedetailname.Length == 3) { int o = 0; }

            if (basedetailname.Length < 4)
            {
                for (int i = 1; i <= 3; i++)
                {
                    string detaname = string.Format("{0}{1}", basedetailname, i);

                    object detcoll = objtype.GetProperty(detaname).GetValue(obj);

                    for (int j = 0; j < QtyInEach; j++)
                    {
                        Type childrentype = Type.GetType(string.Format("EF6Sample.{0}, EF6Sample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", detaname));
                        object newobj = Activator.CreateInstance(childrentype);
                        childrentype.InvokeMember(basedetailname == "D" ? "D0" : basedetailname, System.Reflection.BindingFlags.SetProperty, null, newobj, new object[] { thisid });
                        GenDetails(newobj, QtyInEach, detaname, dbctx);                        
                        detcoll.GetType().InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, detcoll, new[] { newobj });
                    }

                }
            }
        }

        private void SetRandPropVal(object obj, string name)
        {
            obj.GetType().GetProperty(name).SetValue(obj, System.IO.Path.GetRandomFileName());
        }

        //private IEnumerable<Guid> ReadMaster(System.Data.Entity.DbSet<> dbset)
        //{

        //    return dbset.Select(x => new Guid(((Guid)x.GetType().GetProperty("primaryKey").GetGetMethod().Invoke(x, new object[]{})).ToByteArray())).ToList();
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            ////Создание многих Internal с кучей мастеров
            CDLIBEntities dbctx = new CDLIBEntities();
            Dictionary<string, KeyClass[]> masterscache = new Dictionary<string, KeyClass[]>();

            //for (int i = 1; i < 13; i++)
            //{
            //    string mastername = string.Format("Master{0:00}", i);
            //    masterscache[mastername] = ReadMaster((System.Data.Entity.DbSet<object>)typeof(CDLIBEntities).GetProperty(mastername).GetGetMethod().Invoke(dbctx, new object[] { }));
            //}




            masterscache["Master01"] = dbctx.Master01.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master02"] = dbctx.Master02.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master03"] = dbctx.Master03.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master04"] = dbctx.Master04.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master05"] = dbctx.Master05.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master06"] = dbctx.Master06.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master07"] = dbctx.Master07.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master08"] = dbctx.Master08.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master09"] = dbctx.Master09.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master10"] = dbctx.Master10.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master11"] = dbctx.Master11.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["Master12"] = dbctx.Master12.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["MasterDerived01"] = dbctx.MasterDerived01.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["MasterDerived02"] = dbctx.MasterDerived02.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();
            masterscache["MasterDerived03"] = dbctx.MasterDerived03.Select(x => new KeyClass { primaryKey = x.primaryKey }).ToArray();

            Random rnd = new Random();
            RandomStringGenerator rsg = new RandomStringGenerator();
            int icnt=10000;
            Internal[] intl = new Internal[icnt];
            for (int i = 0; i < icnt; i++ )
            {
                intl[i] = dbctx.Internal.Create();
                //dbctx.Internal.Add(intl);
                intl[i].primaryKey = Guid.NewGuid();

                for (int j = 0; j < 10; j++) // Fill string properties with random values
                {
                    typeof(Internal).GetProperty(string.Format("S{0}", j)).GetSetMethod().Invoke(intl[i], new object[] { rsg.Generate(200) }); 
                }

                for (int j = 1; j < 13; j++) // Fill with random master links
                {
                    string mastername = string.Format("Master{0:00}", j);
                    typeof(Internal).GetProperty(mastername).GetSetMethod().Invoke(intl[i], new object[] { masterscache[mastername][rnd.Next(0, masterscache[mastername].Count() - 1)].primaryKey });
                }

                for (int j = 1; j < 4; j++) // Fill with random master links
                {
                    string mastername = string.Format("MasterDerived{0:00}", j);
                    typeof(Internal).GetProperty(string.Format("MasterSpecial_m{0}", j)).GetSetMethod().Invoke(intl[i], new object[] { masterscache[mastername][rnd.Next(0, masterscache[mastername].Count() - 1)].primaryKey });
                }
            }            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            dbctx.Internal.AddRange(intl);
            dbctx.SaveChanges();
            stopwatch.Stop();
            MessageBox.Show(string.Format("OK. Time taken: {0}", stopwatch.ElapsedMilliseconds));

            MessageBox.Show("OK");
        }


        private void button6_Click(object sender, EventArgs e)
        {
            // Чтение из с кучей мастеров
            CDLIBEntities dbctx = new CDLIBEntities();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IEnumerable<Internal> internals = dbctx.Internal
                .Include("Master011").Include("Master021").Include("Master031").Include("Master041").Include("Master051").Include("Master061")
                .Include("Master071").Include("Master081").Include("Master091").Include("Master101").Include("Master111").Include("Master121")
                .Include("MasterDerived01").Include("MasterDerived02").Include("MasterDerived03")
                .ToList();

            stopwatch.Stop();

            MessageBox.Show(string.Format("OK. Time taken: {0}", stopwatch.ElapsedMilliseconds));

            MessageBox.Show("OK");
        }
    }
}
