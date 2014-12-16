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

    using nHibernateSample.Domain;

    public partial class SampleForm : Form
    {
        public SampleForm()
        {
            InitializeComponent();
        }

        private void readWithMaster_Click(object sender, EventArgs e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var cdda = session.Get<CDDA>(new Guid("5471e9d7-def6-4847-abf5-c0da94cfcdc1"));
                textBox1.AppendText(cdda.Name+Environment.NewLine);
                textBox1.AppendText(cdda.Publisher.Name+Environment.NewLine);
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
                    textBox1.AppendText(cdda.Name+Environment.NewLine);
                }
            }
        }

        private void openSession_Click(object sender, EventArgs e)
        {
            var factory = NHibernateHelper.SessionFactory;
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

            MessageBox.Show(string.Format("Time taken for persistence: {0} ms", stopwatch.ElapsedMilliseconds));
        }
    }
}
