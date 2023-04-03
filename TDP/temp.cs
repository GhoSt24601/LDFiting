using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TDP.pg;

namespace TDP
{
    internal class temp
    {
        public class det
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public double Count { get; set; }
            public double Mass { get; set; }
        }
        public static det qwe { get; set; } = new det();
        public static void dettemp(string name, string size, double count, double mass) 
        {
            qwe.Name = name;
            qwe.Size = size;
            qwe.Mass = mass;
            qwe.Count = count;
        }

    }
}


