using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    public class Neighbor//: IEquatable<Neighbor>
    {
        public string FullName { get; set; }
        //public string FlatNumber { get; set; }
        public int FlatNumber { get; set; }
        public long PhoneNumber { get; set; }

        public Neighbor() { }

        //public Neighbor(string fullName, string numberFlat, long phoneNumber)
        //{
        //    FullName = fullName;
        //    FlatNumber = numberFlat;
        //    PhoneNumber = phoneNumber;
        //}

        public Neighbor(int numberFlat, string fullName)
        {
            FullName = fullName;
            FlatNumber = numberFlat;
        }

        public override string ToString()
        {
            return "FullName: " + FullName +  ", PhoneNumber: " + PhoneNumber;
        }
    }
}
