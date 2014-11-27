namespace CDADMTEST
{
    using System;

    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;

    using IIS.CDLIB;

    /// <summary>
    /// Flexberry ORM Samples Logic placed here.
    /// </summary>
    internal class OrmSample
    {
        /// <summary>
        /// Instance of <see cref="IDataService"/> for persistence operations.
        /// </summary>
        private readonly IDataService dataService;

        /// <summary>
        /// DataService being resolved by <see cref="DataServiceProvider.DataService"/>.
        /// </summary>
        public OrmSample()
        {
            dataService = DataServiceProvider.DataService;
        }

        /// <summary>
        /// Logic with custom DataService instance.
        /// </summary>
        /// <param name="ds">DataService for this instance.</param>
        public OrmSample(IDataService ds)
        {
            dataService = ds;
        }

        /// <summary>
        /// Return primary key some object by specified type.
        /// </summary>
        /// <param name="dataObjectType">Type of data object.</param>
        /// <returns>Primary key.</returns>
        internal object GetSomeObjectPrimaryKey(Type dataObjectType)
        {
            View dataObjectView = new View(dataObjectType, View.ReadType.OnlyThatObject);
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(dataObjectType, dataObjectView);
            lcs.ReturnTop = 1;
            DataObject[] dataObjects = dataService.LoadObjects(lcs);
            if (dataObjects.Length > 0)
            {
                return dataObjects[0].__PrimaryKey;
            }

            throw new Exception(string.Format("Could not find any objects specified type: {0} in database: {0}.", dataObjectType.FullName));
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
        internal void GenDetails(D dobj, int QtyInEach)
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
        internal void CheckDetailsQty(D dobj, int QtyInEach)
        {
            string[] detprops = Information.GetPropertyNamesByType(dobj.GetType(), typeof(DetailArray));
            for (int i = 0; i < detprops.Length; i++)
            {
                DetailArray detarr = (DetailArray)Information.GetPropValueByName(dobj, detprops[i]);
                if (detarr.Count != QtyInEach) 
                    throw new Exception(string.Format("Missing reading of {0}!", detprops[i]));

                for (int j = 0; j < detarr.Count; j++)
                {
                    D obj = (D)detarr.ItemByIndex(j);
                    CheckDetailsQty(obj, QtyInEach);
                }
            }

        }
    }
}
