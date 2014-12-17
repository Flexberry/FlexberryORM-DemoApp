using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nHibernateSample
{
    using System.Collections;

    class DetailGenerator
    {
        private static readonly RandomStringGenerator rnd = new RandomStringGenerator();

        public static void SetProperty(object obj, string name, object value)
        {
            var info = obj.GetType().GetProperty(name);
            info.SetValue(obj, value, null);
        }

        public static void Generate(object master, int qty, string baseDetailName)
        {
            SetProperty(master, "Name", System.IO.Path.GetRandomFileName());
            SetProperty(master, "S1", rnd.Generate(200));
            SetProperty(master, "S2", rnd.Generate(200));
            SetProperty(master, "S3", rnd.Generate(200));
            SetProperty(master, "S4", rnd.Generate(200));
            SetProperty(master, "S5", rnd.Generate(200));
            
            if (baseDetailName.Length < 4)
            {
                for (int i = 1; i <= 3; i++)
                {
                    string detailName = string.Format("{0}{1}", baseDetailName, i);

                    Type detailType = Type.GetType("nHibernateSample.Domain." + detailName);

                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(detailType);
                    var detailCollection = (IList)Activator.CreateInstance(constructedListType);
                    
                    for (int j = 0; j < qty; j++)
                    {
                        object newDetail = Activator.CreateInstance(detailType);
                        SetProperty(newDetail, baseDetailName == "D" ? "D0" : baseDetailName, master);
                        Generate(newDetail, qty, detailName);
                        detailCollection.Add(newDetail);
                    }

                    SetProperty(master, detailName+"List", detailCollection);
                }
            }
        }
    }
}
