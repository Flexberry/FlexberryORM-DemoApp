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
            cdda.Price = new Dollar(0, 87);

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
            cddd.Price = new Dollar(1, 52);

            List<ICSSoft.STORMNET.DataObject> objstoupdlist = new List<ICSSoft.STORMNET.DataObject>();

            for (int i = 0; i < 5; i++)
            {
                DVD dvd = new DVD();
                dvd.Publisher = pblshr1;
                dvd.Name = string.Format("Movie {0}", i);
                dvd.Capacity = i * 100;
                dvd.Price = new Dollar(2, 66);
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
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(CDDA));

            // How to read one specific dataobject
            // -----------------------------------
            CDDA cdda = new CDDA(); // Instantiate dataobject
            cdda.SetExistObjectPrimaryKey(primaryKey);

            // Put an object's primary key. It must exist in DB.
            dataService.LoadObject(CDDA.Views.CDDA_E, cdda);

            // Load dataobject in specific view. View is a set of specific properties. You can define view in CASEBERRY tool, or in code by ViewAttribute.
            // Look at composed tracks in watch: they are read also.
            // Try to run in intermediate window: cdda.GetStatus(). Ensure object status is UnAltered. Also you can see loaded properties by running cdda.GetLoadedProperties().
            cdda.Name = "Blablabla " + DateTime.Now;

            // Let's try to change a value of one loaded property. You can change only loaded properties. If you change not-loaded property, you'll get an error while persisting.

            // You would run in an intermediate window: cdda.GetStatus(). Ensure: an object status changed to Altered. Also you can see a set of changed properties by running cdda.GetAlteredPropertyNames(). Flexberry ORM will update only changed propertyes.
            dataService.UpdateObject(cdda); // You can persist only one object, it's OK.
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
            lcs.View = CD.Views.CD_E; // It's a view for loading
            lcs.LoadingTypes = new[] { typeof(CDDA), typeof(CDDD), typeof(DVD) };

            // It's a limitation on descendants of class CD. Only view-class and it's descendants can be loaded.
            lcs.LimitFunction = ld.GetFunction(ld.funcEQ, new VariableDef(ld.StringType, Information.ExtractPropertyPath<CD>(c => c.Publisher.Country.Name)), "USA");

            // Limitation on property value. You can use only properties in view. If the property doesn't exist in a view, you'll get an error while loading.
            lcs.ColumnsSort = new[] { new ColumnsSortDef(Information.ExtractPropertyName<CD>(c => c.Name), ICSSoft.STORMNET.Business.SortOrder.Asc) };

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
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(CDDA));

            // How to do something at persistence moment (step by step):
            // 1. Attach business service to a dataobject class in Caseberry or in a code by using BusinessServer .NET attribute (look at the CDDA class in CDLIB(Objects) assembly)
            // 2. Then generate from Caseberry or code manually business server class with catch up method, and code it (look at the CDLibBS class in CDLIB(BusinessServers) assembly)
            // 3. Just read, change any property, then persist dataobject
            CDDA cdda = new CDDA(); // Instantiate dataobject
            cdda.SetExistObjectPrimaryKey(primaryKey); // Put an object's primary key. It must exist in DB.
            dataService.LoadObject(CDDA.Views.CDDA_E, cdda);
            cdda.Name = "Huh! " + DateTime.Now;
            dataService.UpdateObject(cdda);
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

            OrmSample ormSample = new OrmSample();
            ormSample.GenDetails(aggregator, 10); // Generate N objects for each detail. If N=10, qty of dataobjects will exceed 30000

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            DataServiceProvider.DataService.UpdateObject(aggregator); // All objects will be saved according to composition semantic

            stopwatch.Stop();
            MessageBox.Show(string.Format("Time taken for persistence: {0} ms", stopwatch.ElapsedMilliseconds));
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
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(D0));

            // Load a dataobject with multiple details
            D0 aggregator = new D0();
            aggregator.SetExistObjectPrimaryKey(primaryKey);

            // aggregator.DisableInitDataCopy(); // Uncomment it to do loading faster
            // Take timeshot.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dataService.LoadObject(D0.Views.FULLD0_E, aggregator);
            stopwatch.Stop();
            MessageBox.Show(string.Format("Time taken for loading: {0} ms", stopwatch.ElapsedMilliseconds));
            ormSample.CheckDetailsQty(aggregator, 10); // Ensure we have really had 10 objects per every detailarray
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
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(D0));

            // Create copy of dataobject
            D0 aggregator = new D0();
            aggregator.SetExistObjectPrimaryKey(primaryKey);
            DateTime starttime = DateTime.Now; // Take timeshot before loading
            dataService.LoadObject(D0.Views.D0_E, aggregator);
            DateTime protostarttime = DateTime.Now; // Take timeshot before prototyping
            aggregator.Prototyping2(true); // This makes every object new
            DateTime updatestarttime = DateTime.Now; // Take timeshot before persistence
            dataService.UpdateObject(aggregator);

            MessageBox.Show(string.Format("Time taken for loading: {1} {0}prototyping: {2} {0}persistence: {3}", Environment.NewLine,
                protostarttime.Subtract(starttime),
                updatestarttime.Subtract(protostarttime),
                DateTime.Now.Subtract(updatestarttime)
                ));

            MessageBox.Show("OK");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // Create master objects for multimaster example
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            ICSSoft.STORMNET.DataObject[] objstoupd = ormSample.CreateMasterXXs(100);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            dataService.UpdateObjects(ref objstoupd);
            stopwatch.Stop();
            MessageBox.Show(string.Format("Time taken for masters creation: {0} ms", stopwatch.ElapsedMilliseconds));

        }

        private void button22_Click(object sender, EventArgs e)
        {
            // Create 10000 dataobjects of class Internal
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            Dictionary<string, MasterBase[]> masterscache = ormSample.LoadMasters(); // Load master dataobjects into a cache
            RandomStringGenerator rsg = new RandomStringGenerator();
            Random rndMaster0 = new Random();
            int cnt = 10000;
            ICSSoft.STORMNET.DataObject[] objstoupd = new ICSSoft.STORMNET.DataObject[cnt];

            for (int i = 0; i < cnt; i++)
            {
                Internal itnl = new Internal(); 
                objstoupd[i] = itnl;
                for (int j = 0; j < 10; j++) // Fill string properties with random values
                { 
                    Information.SetPropValueByName(itnl, string.Format("S{0}", j), rsg.Generate(200));
                }

                //Set MasterSpecial property to one of descendants of class Master0 randomly
                itnl.MasterSpecial = (Master0) ormSample.GetRandomMaster(masterscache, string.Format("MasterDerived{0:00}", rndMaster0.Next(1,3)));
                
                for (int j = 1; j < 13; j++) // Set each master property to randomly selected value of corresponding type
                {
                    string mastertypename = string.Format("Master{0:00}", j);
                    Information.SetPropValueByName(itnl, mastertypename, ormSample.GetRandomMaster(masterscache, mastertypename));
                }

            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dataService.UpdateObjects(ref objstoupd); // Just persists created objects
            stopwatch.Stop();
            MessageBox.Show(string.Format("Time taken for creation: {0} ms", stopwatch.ElapsedMilliseconds));

        }
         
        private void button24_Click(object sender, EventArgs e)
        {
            // Loading many objects of type Internal (for multimaster example)
            IDataService dataService = DataServiceProvider.DataService;
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Internal), "FULLInternal_E"); // Full set of attributes
            //LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Internal), "Internal_E"); // S0 and only one attribute in each master
            lcs.InitDataCopy = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICSSoft.STORMNET.DataObject[] internals = dataService.LoadObjects(lcs);
            //ObjectStringDataView[] sv = dataService.LoadStringedObjectView(';', lcs); //Loading as a string array, without dataobjects instantiation. It N-times faster and useful for UI.
            stopwatch.Stop();
            MessageBox.Show(string.Format("Time taken for loading: {0} ms", stopwatch.ElapsedMilliseconds));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // This example shows you how to use calculated properties.
            // Please open Person class in CDLIB(Objects) project, then look at the property FullName.
            // There is an expression defined by DataServiceExpression attribute. Specified data service (and its descendants) uses this expression when querying table.
            // Also, there is an equivalent code in property getter for calculating in dataobject instances.
            IDataService dataService = DataServiceProvider.DataService;
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Person), "Person_E");
            ICSSoft.STORMNET.DataObject[] persons = dataService.LoadObjects(lcs); // Load as dataobjects, notstored property calculated thru property getter.
            ObjectStringDataView[] osdvpersons = dataService.LoadStringedObjectView(';', lcs); // Load as comma delimited string, notstored property calculated thru dataservice expression.
            MessageBox.Show("OK.");
            
        }

        private void button17_Click(object sender, EventArgs e)
        {

            // Working with views example

            // 1. Getting static views
            ICSSoft.STORMNET.View cd_e_for_cd_view = Information.GetView("CD_E", typeof(CD)); // Getting a statically defined view using Information.
            ICSSoft.STORMNET.View cd_e_for_cd_view1 = CD.Views.CD_E; //Also there is a simplest way to obtain view.
            ICSSoft.STORMNET.View cd_e_for_cdda_view = Information.GetView("CD_E", typeof(CDDA)); //Base-class defined views are valid for any descendant classes too.
            ICSSoft.STORMNET.View cd_e_for_cddd_view = Information.GetView("CD_E", typeof(CDDD)); //Base-class defined views are valid for any descendant classes too.

            // 2. Getting names for compatible static view for different classes 
            string[] commonviewnames = Information.AllViews(new Type[] { typeof(CDDA), typeof(CDDD) });


            // TODO: Move to advanced part

            // 3. How to create a view dynamically. 
            // If you need to create a view "in code", just use one of following:
            // a. Use default view constructor, then fill properties:
            ICSSoft.STORMNET.View dynaview = new ICSSoft.STORMNET.View(); // Create an empty view.
            dynaview.DefineClassType = typeof(CDDA); // Set a class for which the view is.
            dynaview.AddProperties(new string[] { "Name", "TotalTracks", "Publisher.Name" }); // dynaview.AddProperty(...) // You can add own and master properties as an array or one by one
            dynaview.AddMasterInView("Publisher"); // Add a master in view.
            //Also you can use dynaview.AddDetailInView method to link detail views

            //b. Creating a dytnamic view thru ViewAttribute:
            ICSSoft.STORMNET.View dynaview1 = new ICSSoft.STORMNET.View(new ViewAttribute("DynaView", new string[] { "Name", "Publisher.Name" }), typeof(CDDA));

            // 4. Operations with views. Each view acts as a set of properties.
            ICSSoft.STORMNET.View view1 = new ICSSoft.STORMNET.View(new ViewAttribute("DynaView1", new string[] { "Name", "Publisher.Name" }), typeof(CDDA));
            ICSSoft.STORMNET.View view2 = new ICSSoft.STORMNET.View(new ViewAttribute("DynaView2", new string[] { "Name", "TotalTracks" }), typeof(CDDA));
            // a. Concatenate views
            ICSSoft.STORMNET.View concatresult = (view1 | view2); // Concatenation result contains all properties of both source views ("Name", "Publisher.Name", "TotalTracks");
            // b. Intersection
            ICSSoft.STORMNET.View intersectresult = (view1 & view2); //Intersection result contains common properties only ("Name");
            // c. Subtraction
            ICSSoft.STORMNET.View subtractsectresult = (view1 - view2); //Subtraction result contains properties from view1, except all defined in view2 ("Publisher.Name");
            // d. Exclusive concatenation
            ICSSoft.STORMNET.View xconcatresult = (view1 ^ view2); // Common properties excluded ("Publisher.Name", "TotalTracks");


            MessageBox.Show("OK.");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Using stereotypes.
            //-------------------------------
            // You can add your own type synonym on a Flexberry diagram:
            // Draw a class on the diagram, then change it's stereotype to "typedef".
            // As result: you can use it as an attribute type for classes in a whole Flexberry stage. But it is only synonym. It leverages an abstraction level during modeling.
            // You need to resolve "typedef" to an implementation language (C#, SQL) in Flexberry typemaps for every codegeneration plugin.
            // Look at the String4000 class (in Flexberry sample repository, Entities diagram).
            // It maps attributes (defined by this type) to C# as System.String, and to SQL as VARCHAR(4000). As example, look at CD.Description attribute.
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Using custom types
            //-------------------------------
            // You can make your own datatype on a Flexberry diagram:
            // Draw a class on the diagram, then change stereotype to "type".
            // As result: you can use it as an attribute type for classes in a whole Flexberry stage.
            // Flexberry generates an empty class template in C#. Also, you need to resolve "typedef" to a storage type in Flexberry typemaps for storage plugins (SQL, MSSQL, ...)
            // Look at the Dollar class on an Entities diagram and in code (CDLIB(Objects)/Dollar.cs).
            // This class implemented by hand from a generated template. It represents dollars in good-looking manner (like $1.24 or .46¢).
            // Look at CD.Price attribute. Values of this attribute stored as decimals in SQL.            

            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(CDDA));

            CDDA cdda = new CDDA(); // Instantiate dataobject
            cdda.SetExistObjectPrimaryKey(primaryKey);

            // Getting some CDDA from DB
            dataService.LoadObject(CD.Views.CD_E, cdda);
            // Change price
            cdda.Price = new Dollar(0, 55);
            dataService.UpdateObject(cdda);

            MessageBox.Show(string.Format("'{0}' price is {1}", cdda.Name, cdda.Price));

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Custom naming of DB structures
            // There are 2 ways to setup naming: by Flexberry or in-code by .NET-attributes. If you choose first way, Flexberry will generate corresponding attributes.
            // You can map a dataobject and attributes to any DB structure names:
            // 1. Table name for class (ClassStorage attribute, class scope);
            // 2. Column name for attribute (PropertyStorage attribute, property scope);
            // 3. Primary key column name for dataobject identifier (PrimaryKeyStorage attribute, class scope);
            // 4. Foreighn key column name for references to master (PropertyStorage attribute, property scope);            
            // Example: look at the "DB structures custom naming" diagram:
            // 1. CustomDBOwnClass maps to CustomDBOwn table;
            // 2. CustomDBOwnClass.CustomOwnAttribute maps to CustomOwn column in CustomDBOwn table;
            // 3. CustomDBMasterClass maps to CustomDBMaster table;
            // 4. CustomDBMasterClass.CustomMasterAttribute maps to CustomMaster column in CustomDBOwnCustomDBMaster table;
            // 5. A reference from CustomDBOwnClass to CustomDBMasterClass maps as CustomDBMaster column in CustomDBOwnClass table;
            // 6. Identifiers of both classes maps to pkey column of corresponding tables;
            
            // Look ma! Custom DB structures naming really works!
            CustomDBOwnClass cdbo = new CustomDBOwnClass();
            CustomDBMasterClass cdbm = new CustomDBMasterClass();
            cdbm.CustomMasterAttribute = new RandomStringGenerator().Generate(200);
            cdbo.CustomDBMasterClass = cdbm;
            cdbo.CustomOwnAttribute = new RandomStringGenerator().Generate(200);

            IDataService dataService = DataServiceProvider.DataService;
            ICSSoft.STORMNET.DataObject[] objstoupd = new ICSSoft.STORMNET.DataObject[] {cdbo, cdbm};
            dataService.UpdateObjects(ref objstoupd);

            MessageBox.Show("OK!");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Switching storages and storage types

        }




    }
}
