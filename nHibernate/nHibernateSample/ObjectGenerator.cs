using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nHibernateSample
{
    using System.Collections;

    class ObjectGenerator
    {
        private static readonly RandomStringGenerator rnd = new RandomStringGenerator();

        public static void SetProperty(object obj, string name, object value)
        {
            var info = obj.GetType().GetProperty(name);
            info.SetValue(obj, value, null);
        }

        public static int CountDetails(object master, string baseDetailName)
        {
            int sum = 0;

            if (baseDetailName.Length < 4)
            {
                for (int i = 1; i < 4; i++)
                {
                    string detailName = string.Format("{0}{1}", baseDetailName, i);
                    var detailCollection = (IEnumerable)master.GetType().GetProperty(detailName + "List").GetValue(master, null);

                    sum += (int)detailCollection.GetType().GetProperty("Count").GetValue(detailCollection, null);
                    foreach (var detail in detailCollection)
                    {
                        sum += CountDetails(detail, detailName);
                    }
                }
            }

            return sum;
        }

        public static void GenerateDetails(object master, int qty, string baseDetailName)
        {
            SetProperty(master, "Name", System.IO.Path.GetRandomFileName());
            SetProperty(master, "S1", rnd.Generate(200));
            SetProperty(master, "S2", rnd.Generate(200));
            SetProperty(master, "S3", rnd.Generate(200));
            SetProperty(master, "S4", rnd.Generate(200));
            SetProperty(master, "S5", rnd.Generate(200));

            if (baseDetailName.Length < 4)
            {
                for (int i = 1; i < 4; i++)
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
                        GenerateDetails(newDetail, qty, detailName);
                        detailCollection.Add(newDetail);
                    }

                    SetProperty(master, detailName + "List", detailCollection);
                }
            }
        }

        public static IEnumerable<object> GenerateMasters(int qty)
        {
            var result = new List<object>(12 * qty);

            for (int i = 0; i < 13; i++)
            {
                var masterTypeName = string.Format("nHibernateSample.Domain.Master{0:00}", i);
                var masterType = Type.GetType(masterTypeName);
                for (int j = 0; j < qty; j++)
                {
                    var newMaster = Activator.CreateInstance(masterType);
                    for (int s = 0; s < 10; s++)
                    {
                        SetProperty(newMaster, "S" + s, rnd.Generate(200));
                    }

                    result.Add(newMaster);
                }
            }

            return result;
        }
    }
}
