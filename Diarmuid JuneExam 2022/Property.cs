using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diarmuid_JuneExam_2022
{
    internal class Property
    {
        private static int _propertyNumbCounter;
        private int _propertyNumb;
        public string _eircode;
        public double _rent;
        public int _bedSpaces;

        public string Eircode
        {
            get { return _eircode; }
            set
            {
                if (value.Length == 6 && value.ToUpper().StartsWith('D'))
                {
                    _eircode = value;
                }
                else
                {
                    throw new ArgumentException("Invalid band");
                    throw new Exception("Credentials invalid");
                }
            }
        }
        public double Rent
        {
            get { return _rent; }
            set { _rent = value; }
        }
        public int BedSpaces
        {
            get { return _bedSpaces; }
            set { _bedSpaces = value; }
        }
        public Property()
        {
            _propertyNumbCounter++;
            _propertyNumb = _propertyNumbCounter;
        }
        public Property(string eircode, double rent, int bedSpaces)
        {
            _propertyNumbCounter++;
            _propertyNumb = _propertyNumbCounter;
            Eircode = eircode;
            this._rent = rent;
            this._bedSpaces = bedSpaces;
        }
        public virtual bool EligibleForGrant()
        {
            return _rent <= 1000;
        }
        public double GetPricePerBedSpace()
        {
            return _rent / _bedSpaces;
        }

        public override string ToString()
        {
            return String.Format($"\nProperty Number: {_propertyNumb}\nEircode: {_eircode}\nRent: {_rent}\nGrant Eligible: {EligibleForGrant()}\nBed Spaces: {_bedSpaces}\nPrice per Bed: {GetPricePerBedSpace()}");
        }

    }
}
