using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kattis
{
    public class AClassyProblem
    {
        private static short[] Nisse = new short[]
        {
            1,
            3,
            9,
            27,
            81,
            243,
            729,
            2187,
            6561,
            19683
        };

        private static int[] Pisse = new int[]
        {
            1,
            4,
            13,
            40,
            121,
            364,
            1093,
            3280,
            9841,
            29524
        };

        public static void Main()
        {
            var scanner = new IO.Scanner();
            var numberOfSorts = scanner.NextInt();
            var result = new List<string>();
            for (var i = 0; i < numberOfSorts; i++)
            {
                var numberOfPeople = scanner.NextInt();
                var people = new List<Person>(numberOfPeople);

                for (var j = 0; j < numberOfPeople; j++)
                {
                    people.Add(Parse2(scanner.Next(), scanner.Next()));
                    scanner.Next();
                }

                result.AddRange(Sort(people));
                result.Add("==============================");
            }
            var outp = new IO.BufferedStdoutWriter();
            outp.WriteLine(string.Join(Environment.NewLine, result));
            outp.Flush();
            //Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        public static Person Parse2(string name, string @class)
        {
            name = name.Substring(0, name.Length - 1);
            var index = 0;
            var kalle = new List<short>(10);
            for (var j = 0; j < 10; j++)
            {
                if (index > @class.Length)
                {
                    break;
                }

                var c = @class[index];
                switch (c)
                {
                    case 'l':
                        kalle.Add(0);
                        index += 6;
                        break;
                    case 'm':
                        kalle.Add(1);
                        index += 7;
                        break;
                    case 'u':
                        kalle.Add(2);
                        index += 6;
                        break;
                }
            }

            var count = kalle.Count();
            var cAdd = 0;
            var i = 9;
            for (; i >= 10 - count; i--)
            {
                cAdd += Nisse[i] * kalle[i - 10 + count];
            }

            cAdd += Pisse[i];
            //for (; i >= 0; i--)
            //{
            //    cAdd += Nisse[i];
            //}

            return new Person(name, 100000 - cAdd);
        }

        public static Person Parse(string name, string @class)
        {
            name = name.Substring(0, name.Length - 1);
            var anka = new StringBuilder(10);
            foreach (var subclass in @class.Split('-'))
            {
                switch (subclass)
                {
                    case "lower":
                        anka.Append(2);
                        break;
                    case "middle":
                        anka.Append(1);
                        break;
                    case "upper":
                        anka.Append(0);
                        break;
                }
            }
            var c = anka.ToString().ToCharArray();
            Array.Reverse(c);
            var b = new string(c);
            var a = long.Parse(b.PadRight(10, '1'));
            return new Person(name, a);
        }

        public static Person Parse(string a2)
        {
            var kalle = a2.Split(' ');
            return Parse2(kalle[0], kalle[1]);
        }

        public static IEnumerable<string> Sort(List<Person> people)
        {
            people.Sort();
            foreach (var p in people)
            {
                yield return p.Name;
            }
        }

        public class Person : IComparable<Person>
        {
            public Person(string name, long @class)
            {
                Name = name;
                Class = @class;
            }

            public string Name { get; }
            public long Class { get; }

            public int CompareTo(Person other)
            {
                var kalle = Class.CompareTo(other.Class);
                if (kalle != 0)
                {
                    return kalle;
                }
                return Name.CompareTo(other.Name);
            }
        }
    }
}
