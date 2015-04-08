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
    using NewPlatform.Flexberry.Samples;

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
            samplesControl1.SampleDataList = new List<SampleData>()
            {
                 new SampleData() 
                { 
                    SampleCaption = "All samples", WikiUrl = "http://wiki.flexberry.net", ChildNodesList = new List<SampleData>()
                    {
                        new SampleData() 
                        { 
                            SampleCaption = "1. Basic", WikiUrl = "http://wiki.flexberry.net", ChildNodesList = new List<SampleData>()
                            {
                                new SampleData() { SampleCaption = "1. How to instantiate dataobjects and persist into DB", WikiUrl = "http://wiki.ics.perm.ru/InstantiateAndPersistObjectsExample.ashx", SampleAction = BasicInstantiateAndPersist },
                                new SampleData() { SampleCaption = "2. How to load dataobject in specific view, change it\'s property, then persist. Object status and loading state", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic2 },
                                new SampleData() { SampleCaption = "3. How to load a set of dataobjects in specific view, limitation, quantity, etc.", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic3 },
                                new SampleData() { SampleCaption = "4. How to do something at persistence moment", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic4 },
                                new SampleData() { SampleCaption = "5. Create a dataobject with multiple details", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic5 },
                                new SampleData() { SampleCaption = "6. Load a dataobject with multiple details", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic6 },
                                new SampleData() { SampleCaption = "7. Prototyping", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic7 },
                                new SampleData() { SampleCaption = "8. Create master objects for multimaster example", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic8 },
                                new SampleData() { SampleCaption = "9. Create 10000 dataobjects", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic9 },
                                new SampleData() { SampleCaption = "10. Loading many objects", WikiUrl = "http://wiki.flexberry.net", SampleAction = Basic10 } 
                            }
                        },
                        new SampleData() 
                        { 
                            SampleCaption = "2. Standard", ChildNodesList = new List<SampleData>()
                            {
                            }
                        },
                        new SampleData() 
                        { 
                            SampleCaption = "3. Advanced", ChildNodesList = new List<SampleData>()
                            {
                            }
                        }
                    }
                }
            };
            samplesControl1.SelectedSample = samplesControl1.SampleDataList[0];
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
            BasicInstantiateAndPersist();
        }

        /// <summary>
        /// 1. How to instantiate dataobjects and persist into DB.
        /// </summary>
        public static void BasicInstantiateAndPersist()
        {
            Console.WriteLine("1. How to instantiate dataobjects and persist into DB.");

            // How to create entities
            // -----------------------------------

            // You can instantiate dataobjects as usual. Let's create several countries, persons, discs, etc.
            Country country1 = new Country { Name = "Greece" };
            Country country2 = new Country { Name = "USA" };
            Country country3 = new Country { Name = "Ireland" };

            Person person1 = new Person { LastName = "Johnson", FirstName = "John" };
            Person person2 = new Person { LastName = "McLaren", FirstName = "Alice" };

            Publisher publisher1 = new Publisher { Name = "First Publisher", Country = country1 };

            Publisher publisher2 = new Publisher { Name = "Second Publisher", Country = country2 };

            CDDA cdda = new CDDA
                            {
                                Publisher = publisher1, Name = "Strange music", Price = new Dollar(0, 87)
                            };

            // There is a creation of composited dataobjects (they acts as a part of aggregation dataobject).
            cdda.Track.Add(new Track()
            {
                Name = "My strange love",
                Author = person1,
                Singer = person2,
                Length = new Random().Next(100, 600)
            });
            cdda.Track.Add(new Track()
            {
                Name = "Stupid is as stupid does",
                Author = person2,
                Singer = person1,
                Length = new Random().Next(100, 600)
            });
            cdda.Track.Add(new Track()
            {
                Name = "Save my life",
                Author = person2,
                Singer = person1,
                Length = new Random().Next(100, 600)
            });

            CDDD cddd = new CDDD();
            cddd.Publisher = publisher2;
            cddd.Name = "Old software";
            cddd.Capacity = 640;
            cddd.Price = new Dollar(1, 52);

            List<ICSSoft.STORMNET.DataObject> objectsToUpdate = new List<ICSSoft.STORMNET.DataObject>();

            for (int i = 0; i < 5; i++)
            {
                DVD dvd = new DVD();
                dvd.Publisher = publisher1;
                dvd.Name = string.Format("Movie {0}", i);
                dvd.Capacity = i * 100;
                dvd.Price = new Dollar(2, 66);
                objectsToUpdate.Add(dvd);
            }

            // Just put all the objects that needs to be persisted into one array. 
            objectsToUpdate.AddRange(new ICSSoft.STORMNET.DataObject[]
            {
                country1, country2, country3, person1, person2, publisher1, publisher2, cdda, cddd
            });

            try
            {
                ICSSoft.STORMNET.DataObject[] objectsToUpdateArray = objectsToUpdate.ToArray();

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // DataServiceProvider.DataService creates data service from app.config. Look at keys: DataServiceType, CustomizationStrings
                // Flexberry ORM persists dataobjects according to their statuses. Flexberry automatically resolves dependencies between dataobjects. All queries runs in one transaction. 
                // 1 UpdateObjects call = 1 DB transaction.
                DataServiceProvider.DataService.UpdateObjects(ref objectsToUpdateArray);

                stopwatch.Stop();
                Console.WriteLine("Time taken for persistence: {0} ms.", stopwatch.ElapsedMilliseconds);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Something wrong: {0}", exc);
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
            Basic2();
        }

        /// <summary>
        /// 2. How to load dataobject in specific view, change it\'s property, then persist. Object status and loading state.
        /// </summary>
        public static void Basic2()
        {
            Console.WriteLine("2. How to load dataobject in specific view, change it\'s property, then persist. Object status and loading state.");

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
            // Look at composed tracks in watch: they had read.
            // Try to run in intermediate window: cdda.GetStatus(). Ensure object status is UnAltered. Also you can see loaded properties by running cdda.GetLoadedProperties().
            cdda.Name = "Blablabla " + DateTime.Now;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Let's try to change a value of one loaded property. You can change only loaded properties. If you change not-loaded property, you'll get an error while persisting.

            // You would run in an intermediate window: cdda.GetStatus(). Ensure: an object status changed to Altered. Also you can see a set of changed properties by running cdda.GetAlteredPropertyNames(). Flexberry ORM will update only changed propertyes.
            dataService.UpdateObject(cdda); // You can persist only one object, it's OK.
            
            stopwatch.Stop();
            Console.WriteLine("Time taken for persistence: {0} ms.", stopwatch.ElapsedMilliseconds);
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
            Basic3();
        }

        /// <summary>
        /// 3. How to load a set of dataobjects in specific view, limitation, quantity, etc..
        /// </summary>
        public static void Basic3()
        {
            Console.WriteLine("3. How to load a set of dataobjects in specific view, limitation, quantity, etc..");

            // How to read many objects
            // -------------------------

            // There are several languages to construct limitations. SQLWhereLanguageDef is the simplest language
            ICSSoft.STORMNET.FunctionalLanguage.SQLWhere.SQLWhereLanguageDef ld =
                ICSSoft.STORMNET.FunctionalLanguage.SQLWhere.SQLWhereLanguageDef.LanguageDef;

            LoadingCustomizationStruct lcs = new LoadingCustomizationStruct(null); // Here you can set loading params.
            lcs.View = CD.Views.CD_E; // It's a view for loading
            lcs.LoadingTypes = new[] { typeof(CDDA), typeof(CDDD), typeof(DVD) };

            // It's a limitation on descendants of class CD. Only view-class and it's descendants can be loaded.
            lcs.LimitFunction = ld.GetFunction(ld.funcEQ,
                new VariableDef(ld.StringType, Information.ExtractPropertyPath<CD>(c => c.Publisher.Country.Name)), "USA");

            // Limitation on property value. You can use only properties in view. If the property doesn't exist in a view, you'll get an error while loading.
            // Ordering of dataobjects in result array
            lcs.ColumnsSort = new[] { new ColumnsSortDef(Information.ExtractPropertyName<CD>(c => c.Name), ICSSoft.STORMNET.Business.SortOrder.Asc) };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // lcs.RowNumber =new RowNumberDef(2, 5);// Read range of objects (useful for pagination)

            // There are three main methods for reading:
            // 1. Load from a storage and instantiate every dataobject.
            ICSSoft.STORMNET.DataObject[] objs = DataServiceProvider.DataService.LoadObjects(lcs);

            // 2. Load without instantiating (as a divider-separated string for each object). It used in UI often and very, very, very fast.
            ObjectStringDataView[] stringedview = DataServiceProvider.DataService.LoadStringedObjectView(';', lcs);

            // 3. Just count objects.
            int iObjsCount = DataServiceProvider.DataService.GetObjectsCount(lcs);

            stopwatch.Stop();
            Console.WriteLine("Time taken for all loadings: {0} ms.", stopwatch.ElapsedMilliseconds);
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
            Basic4();
        }

        /// <summary>
        /// 4. How to do something at persistence moment.
        /// </summary>
        public static void Basic4()
        {
            Console.WriteLine("4. How to do something at persistence moment.");
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(CDDA));

            // How to do something at persistence moment (step by step):
            // 1. Attach business service to a dataobject class in Caseberry or in a code by using BusinessServer .NET attribute (look at the CDDA class in CDLIB(Objects) assembly)
            // 2. Then generate from Caseberry or code manually business server class with catch up method, and code it (look at the CDLibBS class in CDLIB(BusinessServers) assembly)
            // 3. Just read, change any property, then persist dataobject
            CDDA cdda = new CDDA(); // Instantiate dataobject
            cdda.SetExistObjectPrimaryKey(primaryKey); // Put an object's primary key. It must exist in DB.
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            dataService.LoadObject(CDDA.Views.CDDA_E, cdda);
            cdda.Name = "Huh! " + DateTime.Now;
            dataService.UpdateObject(cdda);
            stopwatch.Stop();
            Console.WriteLine("Time taken for loading and persistence: {0} ms.", stopwatch.ElapsedMilliseconds);
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
            Basic5();
        }

        /// <summary>
        /// 5. Create.
        /// </summary>
        public static void Basic5()
        {
            Console.WriteLine("5. Create a dataobject with multiple details.");

            // Create a dataobject with multiple details. 
            D0 aggregator = new D0();

            OrmSample ormSample = new OrmSample();
            ormSample.GenDetails(aggregator, 10);

            // Generate N objects for each detail. If N=10, qty of dataobjects will exceed 30000
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            DataServiceProvider.DataService.UpdateObject(aggregator);

            // All objects will be saved according to composition semantic.
            stopwatch.Stop();
            Console.WriteLine("Time taken for persistence: {0} ms.", stopwatch.ElapsedMilliseconds);
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
            Basic6();
        }

        /// <summary>
        /// 6. Loading.
        /// </summary>
        public static void Basic6()
        {
            Console.WriteLine("6. Loading a dataobject with multiple details.");
            
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
            Console.WriteLine("Time taken for loading: {0} ms.", stopwatch.ElapsedMilliseconds);
            ormSample.CheckDetailsQty(aggregator, 10); // Ensure we have really had 10 objects per every detailarray.
            Console.WriteLine("CheckDetailsQty: OK.");
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
            Basic7();
        }

        /// <summary>
        /// 7. Prototyping.
        /// </summary>
        public static void Basic7()
        {
            Console.WriteLine("7. Prototyping.");
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(D0));

            // Create copy of dataobject
            D0 aggregator = new D0();
            aggregator.SetExistObjectPrimaryKey(primaryKey);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dataService.LoadObject(D0.Views.D0_E, aggregator);

            stopwatch.Stop();
            long loadObjectTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();

            aggregator.Prototyping2(true); // This makes every object new

            stopwatch.Stop();
            long prototypingTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();

            dataService.UpdateObject(aggregator);

            stopwatch.Stop();
            long updateTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("Time taken for loading: {1} ms{0}prototyping: {2} ms{0}persistence: {3} ms.", Environment.NewLine, loadObjectTime, prototypingTime, updateTime);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Basic8();
        }

        /// <summary>
        /// 8. Prepare masters.
        /// </summary>
        public static void Basic8()
        {
            Console.WriteLine("8. Create master objects for multimaster example.");

            // Create master objects for multimaster example.
            IDataService dataService = DataServiceProvider.DataService;
            OrmSample ormSample = new OrmSample(dataService);
            ICSSoft.STORMNET.DataObject[] objstoupd = ormSample.CreateMasterXXs(100);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dataService.UpdateObjects(ref objstoupd);

            stopwatch.Stop();

            Console.WriteLine("Time taken for masters creation: {0} ms.", stopwatch.ElapsedMilliseconds);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Basic9();
        }

        /// <summary>
        /// 9. Create 10000.
        /// </summary>
        public static void Basic9()
        {
            Console.WriteLine("9. Create 10000.");

            // Create 10000 dataobjects of class Internal.
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

                // Fill string properties with random values.
                for (int j = 0; j < 10; j++)
                {
                    Information.SetPropValueByName(itnl, string.Format("S{0}", j), rsg.Generate(200));
                }

                // Set MasterSpecial property to one of descendants of class Master0 randomly
                itnl.MasterSpecial =
                    (Master0)
                        ormSample.GetRandomMaster(masterscache, string.Format("MasterDerived{0:00}", rndMaster0.Next(1, 3)));

                // Set each master property to randomly selected value of corresponding type.
                for (int j = 1; j < 13; j++)
                {
                    string mastertypename = string.Format("Master{0:00}", j);
                    Information.SetPropValueByName(itnl, mastertypename, ormSample.GetRandomMaster(masterscache, mastertypename));
                }
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dataService.UpdateObjects(ref objstoupd); // Just persists created objects
            stopwatch.Stop();
            Console.WriteLine("Time taken for creation: {0} ms.", stopwatch.ElapsedMilliseconds);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Basic10();
        }

        /// <summary>
        /// 10. Load.
        /// </summary>
        public static void Basic10()
        {
            Console.WriteLine("10. Load.");

            // Loading many objects of type Internal (for multimaster example)
            IDataService dataService = DataServiceProvider.DataService;
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Internal), Internal.Views.FULLInternal_E);
            // Full set of attributes
            //LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Internal), "Internal_E"); // S0 and only one attribute in each master
            lcs.InitDataCopy = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ICSSoft.STORMNET.DataObject[] internals = dataService.LoadObjects(lcs);
            //ObjectStringDataView[] sv = dataService.LoadStringedObjectView(';', lcs); //Loading as a string array, without dataobjects instantiation. It N-times faster and useful for UI.
            stopwatch.Stop();
            Console.WriteLine("Time taken for loading: {0} ms.", stopwatch.ElapsedMilliseconds);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // This example shows you how to use calculated properties.
            // Please open Person class in CDLIB(Objects) project, then look at the property FullName.
            // There is an expression defined by DataServiceExpression attribute. Specified data service (and its descendants) uses this expression when querying table.
            // Also, there is an equivalent code in property getter for calculating in dataobject instances.
            IDataService dataService = DataServiceProvider.DataService;
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Person), Person.Views.Person_E);
            ICSSoft.STORMNET.DataObject[] persons = dataService.LoadObjects(lcs); // Load as dataobjects, notstored property calculated thru property getter.
            ObjectStringDataView[] osdvpersons = dataService.LoadStringedObjectView(';', lcs); // Load as comma delimited string, notstored property calculated thru dataservice expression.
            Console.WriteLine("OK.");
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





            Console.WriteLine("OK.");
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

            Console.WriteLine(string.Format("'{0}' price is {1}", cdda.Name, cdda.Price));

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

            // Look ma! Just create objects and persist them: it really works!

            CustomDBOwnClass cdbo = new CustomDBOwnClass();
            CustomDBMasterClass cdbm = new CustomDBMasterClass();
            cdbm.CustomMasterAttribute = new RandomStringGenerator().Generate(200);
            cdbo.CustomDBMasterClass = cdbm;
            cdbo.CustomOwnAttribute = new RandomStringGenerator().Generate(200);

            IDataService dataService = DataServiceProvider.DataService;
            ICSSoft.STORMNET.DataObject[] objstoupd = new ICSSoft.STORMNET.DataObject[] { cdbo, cdbm };
            dataService.UpdateObjects(ref objstoupd);

            Console.WriteLine("OK!");
        }


        private void button18_Click(object sender, EventArgs e)
        {
            // Switching storages and storage types

            // An example: try to use Postgre RDBMS:
            // 0. We hope you had installed Postgre RDBMS. If had not, consider to visit http://www.postgresql.org/;
            // 1. Please create database by running a scrypt file "FlexberryORM\Database\POSTGRES\create.sql";
            // 2. Then open app.config and look at the appSettings section;
            // 3. Comment sections with keys DataServiceType and CustomizationStrings, then change keys of DataServiceType_POSTGRE and CustomizationStrings_POSTGRE to DataServiceType and CustomizationStrings;
            // 4. Change CustomizationStrings to properly connect to your Postgre server and database;
            // 5. Run an example to ensure it works: try to test any examples with data creation and loading.

            Console.WriteLine("Read comments in code under this button!");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Advanced working with views.

            // 1. You can create a view dynamically. 
            // If you need to create a view "in code", just use one of following:
            // a. Use default view constructor, then fill properties:
            ICSSoft.STORMNET.View dynaview = new ICSSoft.STORMNET.View(); // Create an empty view.
            dynaview.DefineClassType = typeof(CDDA); // Set a class for which the view is.
            dynaview.AddProperties(new string[] { "Name", "TotalTracks", "Publisher.Name" }); // dynaview.AddProperty(...) // You can add own and master properties as an array or one by one
            dynaview.AddMasterInView("Publisher"); // Add a master in view.
            //Also you can use dynaview.AddDetailInView method to link detail views

            // b. Creating a dytnamic view thru ViewAttribute:
            ICSSoft.STORMNET.View dynaview1 = new ICSSoft.STORMNET.View(new ViewAttribute("DynaView", new string[] { "Name", "Publisher.Name" }), typeof(CDDA));

            // 2. Operations with views. Each view acts as a set of properties.
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

            Console.WriteLine(string.Format("{1}{0}{0}{2}{0}{0}{3}{0}{0}{4}{0}{0}", Environment.NewLine,
                string.Format("{0} | {1} = {2}", view1.ToString(true), view2.ToString(true), concatresult.ToString(true)),
                string.Format("{0} & {1} = {2}", view1.ToString(true), view2.ToString(true), intersectresult.ToString(true)),
                string.Format("{0} - {1} = {2}", view1.ToString(true), view2.ToString(true), subtractsectresult.ToString(true)),
                string.Format("{0} ^ {1} = {2}", view1.ToString(true), view2.ToString(true), xconcatresult.ToString(true))
                ));
        }




    }
}
