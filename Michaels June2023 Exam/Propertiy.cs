using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michaels_June2023_Exam
{
    class Propertiy
    {
        static int _numb;
        private string _eircode;
        private double _rent;
        private int _bedspaces;
        static char rate;
        public int Numb
        {
            get { return _numb; }
            set { _numb = value; }
        }
        public string Eircode
        {
            get { return _eircode; }
            set
            {
                if (value.ToUpper().StartsWith('D') && value.Length == 6)
                {
                    _eircode = value;
                }
                else if (value.ToUpper().StartsWith('D') && value.Length != 6)
                {
                    Console.WriteLine("eircode too long");

                }
                else if (!value.ToUpper().StartsWith('D') && value.Length == 6)
                {
                    throw new ArgumentException("eircode doesnt start with 'D'");
                }
                else
                {
                    Console.WriteLine("invalid input");
                }
            }
        }
        public double Rent
        {
            get { return _rent; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rent Cannot be below 0");
                }
                else if (value > 0)
                {
                    _rent = value;
                }
            }
        }
        public int NumberBedSpace
        {
            get { return _bedspaces; }
            set { _bedspaces = value; }
        }
        public Propertiy(string EirCode, double RenT, int BedSpaces)
        {
            Numb++;
            Eircode = EirCode;
            Rent = RenT;
            NumberBedSpace = BedSpaces;
        }
        public bool EligibleForGrandt()
        {
            if (Rent > 1000)
            {
                rate = ' ';
                return false;
            }
            else if (Rent <= 1000)
            {

                if (Rent <= 800 && Rent >= 200)
                {
                    rate = 'A';

                }
                else if (Rent >= 200 && Rent <= 600)
                {
                    rate = 'B';
                }
                else if (Rent <= 1000 && Rent >= 800)
                {
                    rate = 'C';
                }
                else
                { rate = ' '; }

                return true;
            }
            else
            {
                rate = ' ';
                return false;
            }
        }
        public double GetSpacePerBed()
        {
            double bedSpacePrice;

            return bedSpacePrice = _rent / _bedspaces;
        }
        public override string ToString()
        {
            return string.Format($".{Numb,-10} {Eircode,-10} {Rent,-10} {EligibleForGrandt(),-10} {NumberBedSpace,-10} {GetSpacePerBed(),-10:c2} {rate,10}");
        }
    }
}
