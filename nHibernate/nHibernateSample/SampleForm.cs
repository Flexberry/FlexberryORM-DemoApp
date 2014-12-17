using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nHibernateSample
{
    using System.Diagnostics;

    using NHibernate.Linq;

    using nHibernateSample.Domain;

    public partial class SampleForm : Form
    {
        public SampleForm()
        {
            InitializeComponent();
        }

        private void log(string message)
        {
            textBox1.AppendText(message);
            textBox1.AppendText(Environment.NewLine);
        }

        private void readWithMaster_Click(object sender, EventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var cdda = session.Get<CDDA>(new Guid("5471e9d7-def6-4847-abf5-c0da94cfcdc1"));
                log(cdda.Name);
                log(cdda.Publisher.Name);
            }
        }

        private void readSomeProperties_Click(object sender, EventArgs e)
        {

        }

        private void listItems_Click(object sender, EventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                foreach (var cdda in session.QueryOver<CDDA>().List())
                {
                    log(cdda.Name);
                }
            }
        }

        private void openSession_Click(object sender, EventArgs e)
        {
            var factory = NHibernateHelper.SessionFactory;
            if (factory != null)
            {
                log("Success init session factory");
            }
        }

        private void createDetails_Click(object sender, EventArgs e)
        {
            var d0 = new D0();
            ObjectGenerator.GenerateDetails(d0, 10, "D");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trn = session.BeginTransaction())
                {
                    session.SaveOrUpdate(d0);
                    trn.Commit();
                    stopwatch.Stop();
                }
            }

            log(string.Format("Time taken for persistence: {0} ms", stopwatch.ElapsedMilliseconds));
        }

        private void readD0_Click(object sender, EventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var d0 = session.Query<D0>().FirstOrDefault();
                stopwatch.Stop();
                if (d0 != null)
                {
                    log("Read detail hierarhy from database, time taken:" + stopwatch.ElapsedMilliseconds + "ms , total count: " + ObjectGenerator.CountDetails(d0, "D"));
                }
                else
                {
                    log("There are no D0 objects in database");
                }
            }
        }



        private void create10000_Click(object sender, EventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var masterCache = new Dictionary<int, object[]>(12);
                masterCache.Add(0, session.Query<Master00>().ToArray());
                masterCache.Add(1, session.Query<Master01>().ToArray());
                masterCache.Add(2, session.Query<Master02>().ToArray());
                masterCache.Add(3, session.Query<Master03>().ToArray());
                masterCache.Add(4, session.Query<Master04>().ToArray());
                masterCache.Add(5, session.Query<Master05>().ToArray());
                masterCache.Add(6, session.Query<Master06>().ToArray());
                masterCache.Add(7, session.Query<Master07>().ToArray());
                masterCache.Add(8, session.Query<Master08>().ToArray());
                masterCache.Add(9, session.Query<Master09>().ToArray());
                masterCache.Add(10, session.Query<Master10>().ToArray());
                masterCache.Add(11, session.Query<Master11>().ToArray());
                masterCache.Add(12, session.Query<Master12>().ToArray());
                var rnd = new Random(100);
                var list = new List<Internal>(10000);
                for (int i = 0; i < 10000; i++)
                {
                    var inter = new Internal
                                    {
                                        Master00 = (Master00)masterCache[0][rnd.Next(100)],
                                        Master01 = (Master01)masterCache[1][rnd.Next(100)],
                                        Master02 = (Master02)masterCache[2][rnd.Next(100)],
                                        Master03 = (Master03)masterCache[3][rnd.Next(100)],
                                        Master04 = (Master04)masterCache[4][rnd.Next(100)],
                                        Master05 = (Master05)masterCache[5][rnd.Next(100)],
                                        Master06 = (Master06)masterCache[6][rnd.Next(100)],
                                        Master07 = (Master07)masterCache[7][rnd.Next(100)],
                                        Master08 = (Master08)masterCache[8][rnd.Next(100)],
                                        Master09 = (Master09)masterCache[9][rnd.Next(100)],
                                        Master10 = (Master10)masterCache[10][rnd.Next(100)],
                                        Master11 = (Master11)masterCache[11][rnd.Next(100)],
                                        Master12 = (Master12)masterCache[12][rnd.Next(100)],
                                    };
                    list.Add(inter);
                }

                using (var trn = session.BeginTransaction())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    foreach (var inter in list)
                    {
                        session.Save(inter);
                    }
                    trn.Commit();
                    stopwatch.Stop();
                    log("Succesfully saved 10000 with masters in " + stopwatch.ElapsedMilliseconds + " ms");
                }
            }
        }

        private void createMasters_Click(object sender, EventArgs e)
        {
            var masters = ObjectGenerator.GenerateMasters(100);

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trn = session.BeginTransaction())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    foreach (var master in masters)
                    {
                        session.Save(master);
                    }

                    trn.Commit();
                    stopwatch.Stop();
                    log("Success master creating, time taken: " + stopwatch.ElapsedMilliseconds + " ms");
                }
            }

        }

        private void loadMasters_Click(object sender, EventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var internals = session.Query<Internal>().ToList();
                stopwatch.Stop();
                log("Read " + internals.Count + " items from Internals in " + stopwatch.ElapsedMilliseconds + " ms");
            }
        }
    }
}
