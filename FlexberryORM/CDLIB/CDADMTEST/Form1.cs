namespace CDADMTEST
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.FunctionalLanguage;
    using IIS.CDLIB;

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

        /// <summary>
        /// The button 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button1_Click(object sender, EventArgs e)
        {
            // How to create entities
            // -----------------------------------

            // You can instantiate dataobjects as usual. Let's create several countries, persons, discs, etc.
            Country ctr1 = new Country();
            ctr1.Name = "Greece";
            Country ctr2 = new Country();
            ctr2.Name = "USA";
            Country ctr3 = new Country();
            ctr3.Name = "Ireland";

            Person prs1 = new Person();
            prs1.LastName = "Johnson";
            prs1.FirstName = "John";
            Person prs2 = new Person();
            prs2.LastName = "McLaren";
            prs2.FirstName = "Alice";

            Publisher pblshr1 = new Publisher();
            pblshr1.Name = "First Publisher";
            pblshr1.Country = ctr1;

            Publisher pblshr2 = new Publisher();
            pblshr2.Name = "Second Publisher";
            pblshr2.Country = ctr2;

            CDDA cdda = new CDDA();
            cdda.Publisher = pblshr1;
            cdda.Name = "Strange music";

            // There is a creation of composited dataobjects (they acts as a part of aggregation dataobject).
            cdda.Track.Add(new Track()
            {
                Name = "My strange love",
                Author = prs1,
                Singer = prs2,
                Length = new Random().Next(100, 600)
            });
            cdda.Track.Add(new Track()
            {
                Name = "Stupid is as stupid does",
                Author = prs2,
                Singer = prs1,
                Length = new Random().Next(100, 600)
            });
            cdda.Track.Add(new Track() { Name = "Save my life", Author = prs2, Singer = prs1, Length = new Random().Next(100, 600) });

            CDDD cddd = new CDDD();
            cddd.Publisher = pblshr2;
            cddd.Name = "Old software";
            cddd.Capacity = 640;

            var objstoupdlist = new List<ICSSoft.STORMNET.DataObject>();

            for (int i = 0; i < 5; i++)
            {
                DVD dvd = new DVD();
                dvd.Publisher = pblshr1;
                dvd.Name = string.Format("Movie {0}", i);
                dvd.Capacity = i * 100;
                objstoupdlist.Add(dvd);
            }

            // Just put all the objects that needs to be persisted in one array. 
            objstoupdlist.AddRange(new ICSSoft.STORMNET.DataObject[] { ctr1, ctr2, ctr3, prs1, prs2, pblshr1, pblshr2, cdda, cddd });

            try
            {

                ICSSoft.STORMNET.DataObject[] objstoupd = objstoupdlist.ToArray();

                // DataServiceProvider.DataService creates data service from app.config. Look at keys: DataServiceType, CustomizationStrings
                // Flexberry ORM persists dataobjects according to their statuses. Flexberry automatically resolves dependencies between dataobjects. All queries runs in one transaction. 
                // 1 UpdateObjects call = 1 DB transaction.
                DataServiceProvider.DataService.UpdateObjects(ref objstoupd);

                MessageBox.Show("OK!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(string.Format("Something wrong: {0}", exc));
            }


        }

        /// <summary>
        /// The button 2_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button2_Click(object sender, EventArgs e)
        {
            // How to read one specific dataobject
            // -----------------------------------
            CDDA cdda = new CDDA(); // Instantiate dataobject
            cdda.SetExistObjectPrimaryKey("412F141F-1376-47BC-81EA-DD9091814C39");

            // Put an object's primary key. It must exist in DB.
            DataServiceProvider.DataService.LoadObject("CDDA_E", cdda);

            // Load dataobject in specific view. View is a set of specific properties. You can define view in CASEBERRY tool, or in code by ViewAttribute.
            // Look at composed tracks in watch: they are read also.
            // Try to run in intermediate window: cdda.GetStatus(). Ensure object status is UnAltered. Also you can see loaded properties by running cdda.GetLoadedProperties().
            cdda.Name = "Blablabla " + DateTime.Now;

            // Let's try to change a value of one loaded property. You can change only loaded properties. If you change not-loaded property, you'll get an error while persisting.

            // You would run in an intermediate window: cdda.GetStatus(). Ensure: an object status changed to Altered. Also you can see a set of changed properties by running cdda.GetAlteredPropertyNames(). Flexberry ORM will update only changed propertyes.
            DataServiceProvider.DataService.UpdateObject(cdda); // You can persist only one object, it's OK.
        }

        /// <summary>
        /// The button 3_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button3_Click(object sender, EventArgs e)
        {
            // How to read many objects
            // -------------------------

            // There are several languages to construct limitations. SQLWhereLanguageDef is the simplest language
            ICSSoft.STORMNET.FunctionalLanguage.SQLWhere.SQLWhereLanguageDef ld =
                ICSSoft.STORMNET.FunctionalLanguage.SQLWhere.SQLWhereLanguageDef.LanguageDef;

            LoadingCustomizationStruct lcs = new LoadingCustomizationStruct(null); // Here you can set loading params.
            lcs.View = Information.GetView("CD_E", typeof(CD)); // It's a view for loading
            lcs.LoadingTypes = new[] { typeof(CDDA), typeof(CDDD), typeof(DVD) };

            // It's a limitation on descendants of class CD. Only view-class and it's descendants can be loaded.
            lcs.LimitFunction = ld.GetFunction(ld.funcEQ, new VariableDef(ld.StringType, "Publisher.Country.Name"), "USA");

            // Limitation on property value. You can use only properties in view. If the property doesn't exist in a view, you'll get an error while loading.
            lcs.ColumnsSort = new[] { new ColumnsSortDef("Name", ICSSoft.STORMNET.Business.SortOrder.Asc) };

            // Ordering of dataobjects in result array

            // lcs.RowNumber =new RowNumberDef(2, 5);// Read range of objects (useful for pagination)

            // There are three main methods for reading:
            // 1. Load from a storage and instantiate every dataobject.
            ICSSoft.STORMNET.DataObject[] objs = DataServiceProvider.DataService.LoadObjects(lcs);

            // 2. Load without instantiating (as a divider-separated string for each object). It used in UI often and very, very, very fast.
            ObjectStringDataView[] stringedview = DataServiceProvider.DataService.LoadStringedObjectView(';', lcs);

            // 3. Just count objects.
            int iObjsCount = DataServiceProvider.DataService.GetObjectsCount(lcs);

            MessageBox.Show("OK!");
        }

        /// <summary>
        /// The button 7_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button7_Click(object sender, EventArgs e)
        {
            // How to do something at persistence moment (step by step):
            // 1. Attach business service to a dataobject class in Caseberry or in a code by using BusinessServer .NET attribute (look at the CDDA class in CDLIB(Objects) assembly)
            // 2. Then generate from Caseberry or code manually business server class with catch up method, and code it (look at the CDLibBS class in CDLIB(BusinessServers) assembly)
            // 3. Just read, change any property, then persist dataobject
            CDDA cdda = new CDDA(); // Instantiate dataobject
            cdda.SetExistObjectPrimaryKey("412F141F-1376-47BC-81EA-DD9091814C39"); // Put an object's primary key. It must exist in DB.
            DataServiceProvider.DataService.LoadObject("CDDA_E", cdda);
            cdda.Name = "Huh! " + DateTime.Now.ToString();
            DataServiceProvider.DataService.UpdateObject(cdda);

        }

        /// <summary>
        /// The button 9_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button9_Click(object sender, EventArgs e)
        {
            // Create a dataobject with multiple details. 
            D0 aggregator = new D0();
            GenDetails(aggregator, 10); // Generate N objects for each detail. If N=10, qty of dataobjects will exceed 30000

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            DataServiceProvider.DataService.UpdateObject(aggregator); // All objects will be saved according to composition semantic

            stopwatch.Stop();
            MessageBox.Show(string.Format("Time taken for persistence: {0} ms", stopwatch.ElapsedMilliseconds));
        }


        /// <summary>
        /// The gen details.
        /// </summary>
        /// <param name="dobj">
        /// The dobj.
        /// </param>
        /// <param name="QtyInEach">
        /// The qty in each.
        /// </param>
        private void GenDetails(D dobj, int QtyInEach)
        {
            dobj.Name = System.IO.Path.GetRandomFileName();
            dobj.S1 = System.IO.Path.GetRandomFileName();
            dobj.S2 = System.IO.Path.GetRandomFileName();
            dobj.S3 = System.IO.Path.GetRandomFileName();
            dobj.S4 = System.IO.Path.GetRandomFileName();
            dobj.S5 = System.IO.Path.GetRandomFileName();

            string[] detprops = Information.GetPropertyNamesByType(dobj.GetType(), typeof(DetailArray));
            for (int i = 0; i < detprops.Length; i++)
            {
                DetailArray detarr = (DetailArray)Information.GetPropValueByName(dobj, detprops[i]);
                Type dettypetocreate = Information.GetCompatibleTypesForDetailProperty(dobj.GetType(), detprops[i])[0];
                for (int j = 0; j < QtyInEach; j++)
                {
                    D newobj = (D)Activator.CreateInstance(dettypetocreate);
                    GenDetails(newobj, QtyInEach);
                    detarr.AddObject(newobj);
                }
            }

        }

        /// <summary>
        /// The check details qty.
        /// </summary>
        /// <param name="dobj">
        /// The dobj.
        /// </param>
        /// <param name="QtyInEach">
        /// The qty in each.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        private void CheckDetailsQty(D dobj, int QtyInEach)
        {
            string[] detprops = Information.GetPropertyNamesByType(dobj.GetType(), typeof(DetailArray));
            for (int i = 0; i < detprops.Length; i++)
            {
                DetailArray detarr = (DetailArray)Information.GetPropValueByName(dobj, detprops[i]);
                if (detarr.Count != QtyInEach) throw new Exception(string.Format("Missing reading of {0}!", detprops[i]));
                for (int j = 0; j < detarr.Count; j++)
                {
                    D obj = (D)detarr.ItemByIndex(j);
                    CheckDetailsQty(obj, QtyInEach);
                }
            }

        }

        /// <summary>
        /// The button 21_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button21_Click(object sender, EventArgs e)
        {
            // Load a dataobject with multiple details
            D0 aggregator = new D0();
            aggregator.SetExistObjectPrimaryKey("018FF5D0-0EB7-4E0F-B836-227D7E32425D");

            // aggregator.DisableInitDataCopy(); // Uncomment it to do loading faster
            // Take timeshot.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DataServiceProvider.DataService.LoadObject("D0_E", aggregator);
            stopwatch.Stop();
            MessageBox.Show(string.Format("Time taken for loading: {0} ms", stopwatch.ElapsedMilliseconds));
            CheckDetailsQty(aggregator, 10); // Ensure we have really had 10 objects per every detailarray
            MessageBox.Show("OK");
        }

        /// <summary>
        /// The button 9_ click_1.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button9_Click_1(object sender, EventArgs e)
        {
            // Create copy of dataobject
            D0 aggregator = new D0();
            aggregator.SetExistObjectPrimaryKey("018FF5D0-0EB7-4E0F-B836-227D7E32425D");
            DateTime starttime = DateTime.Now; // Take timeshot before loading
            DataServiceProvider.DataService.LoadObject("D0_E", aggregator);
            DateTime protostarttime = DateTime.Now; // Take timeshot before prototyping
            aggregator.Prototyping2(true); // This makes every object new
            DateTime updatestarttime = DateTime.Now; // Take timeshot before persistence
            DataServiceProvider.DataService.UpdateObject(aggregator);

            MessageBox.Show(string.Format("Time taken for loading: {1} {0}prototyping: {2} {0}persistence: {3}", Environment.NewLine,
                protostarttime.Subtract(starttime),
                updatestarttime.Subtract(protostarttime),
                DateTime.Now.Subtract(updatestarttime)
                ));

            MessageBox.Show("OK");
        }
    }
}
