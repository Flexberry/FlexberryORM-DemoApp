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
            DetailGenerator.Generate(d0, 10, "D");

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
                    log("Read detail hierarhy from database, time taken:" + stopwatch.ElapsedMilliseconds + "ms , total count: " + DetailGenerator.Count(d0, "D"));
                }
                else
                {
                    log("There are no D0 objects in database");
                }
            }
        }
    }
}
