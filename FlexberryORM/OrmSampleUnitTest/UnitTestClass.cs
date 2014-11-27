namespace OrmSampleUnitTest
{
    using System;
    using System.IO;

    using CDADMTEST;

    using IIS.CDLIB;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit test class for Flexberry ORM sample.
    /// </summary>
    [TestClass]
    public class UnitTestClass
    {
        /// <summary>
        /// Set up DataDirectory domain property for relative connection string.
        /// </summary>
        public UnitTestClass()
        {
            string asmPath = this.GetType().Assembly.Location;
            string path = Path.GetDirectoryName(asmPath);
            if (path != null)
            {
                path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\DataBase"));
                AppDomain.CurrentDomain.SetData("DataDirectory", path);
            }
        }

        /// <summary>
        /// Test for <see cref="OrmSample.GetSomeObjectPrimaryKey"/>.
        /// </summary>
        [TestMethod]
        public void GetSomeObjectPrimaryKeyTest()
        {
            OrmSample ormSample = new OrmSample();
            object primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(CDDA));
            Assert.IsNotNull(primaryKey);
            primaryKey = ormSample.GetSomeObjectPrimaryKey(typeof(D0));
            Assert.IsNotNull(primaryKey);
        }
    }
}
