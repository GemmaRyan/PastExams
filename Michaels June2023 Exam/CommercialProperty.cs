using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michaels_June2023_Exam
{
    internal class CommercialProperty : Propertiy
    {
        public string _ratesBand;
        public string RatesBand
        {
            get { return _ratesBand; }
            set { _ratesBand = value; }
        }
        public CommercialProperty(string EirCode, double RenT, int BedSpaces, string RateBand) : base(EirCode, RenT, BedSpaces)
        {
            Eircode = EirCode;
            Rent = RenT;
            NumberBedSpace = BedSpaces;
            RatesBand = RateBand;
        }
        public bool EligibleForGrandt()
        {
            if (RatesBand != "A" && RatesBand != "B" && RatesBand != "C")
            {
                return false;
            }
            else if (RatesBand == "A" && Rent <= 1000)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("A, B or C, are only accectped as a base grant");
            }
        }
        public override string ToString()
        {
            return string.Format($".{Numb,-10} {Eircode,-10} {Rent,-10} {EligibleForGrandt(),-10} {NumberBedSpace,-10} {GetSpacePerBed(),-10:c2} {RatesBand,-10}");
        }
    }
}
