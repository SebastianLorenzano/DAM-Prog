using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMLibTest
{
    public class SetTest
    {
        public class Test1Results

        {

            public bool Empty1 { get; set; }

            public int Count1 { get; set; }

            public bool EmptyJuan { get; set; }

            public int CountJuan { get; set; }

            public bool ContainsJuan { get; set; }

            public bool EmptyJuan2 { get; set; }

            public int CountJuan2 { get; set; }

            public bool ContainsJuan2 { get; set; }

            public bool EmptyAna { get; set; }

            public int CountAna { get; set; }

            public bool ContainsAna2 { get; set; }

            public bool EmptyAna2 { get; set; }

            public int CountAna2 { get; set; }

            public bool ContainsAna { get; set; }

        }



        // Test de caja blanca

        public static Test1Results Test1(ISet<string> set)

        {

            Test1Results results = new Test1Results();

            {

                set.Clear();

                results.Empty1 = set.IsEmpty;

                results.Count1 = set.Count;

                set.Remove(null);

                set.Add(null);

                set.Contains(null);



                set.Add("Juan");

                results.EmptyJuan = set.IsEmpty;

                results.CountJuan = set.Count;

                results.ContainsJuan = set.Contains("Juan");



                set.Add("Juan");

                results.EmptyJuan2 = set.IsEmpty;

                results.CountJuan2 = set.Count;

                results.ContainsJuan2 = set.Contains("Juan");



                set.Add("Ana");

                results.EmptyAna = set.IsEmpty;

                results.CountAna = set.Count;

                results.ContainsAna = set.Contains("Ana");



                set.Add("Ana");

                results.EmptyAna2 = set.IsEmpty;

                results.CountAna2 = set.Count;

                results.ContainsAna2 = set.Contains("Ana");

            }

            return results;

        }
    }
}
