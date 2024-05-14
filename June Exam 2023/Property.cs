using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;

namespace June_Exam_2023
{
    internal class Property
    {

        //static so it counts every cycle of the code   for a unique number 
        static private int propertynum;

        //attributes
        private string _eircode;
        private double _rent;
        private int _bedSpaces;
        private int _housenum;

        //getters and setters
        public string Eircode
        {
            get { return _eircode;}     //Adding the exceptions to the setter 
            set {

                    if (value.ToUpper().StartsWith("D") == true && value.Length == 6)
                    {
                        _eircode = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Eircode");
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
        public int HouseNum
        {
            get { return _housenum; }
            set { _housenum = value; }
        }

        //default constructor
        public Property()
        {
            propertynum++;
            _housenum = propertynum;
        }

        public Property(string eircode , double rent , int bed )     //paramarterised constructor
        {
            propertynum++;
            _housenum = propertynum;


            //all the attributes
            Eircode = eircode;
            Rent = rent;
            BedSpaces = bed;
        }
        public virtual bool EligibleForGrant()
        {
            if (Rent <= 1000)
            {
                return true;
            }
            else { return false; }
        }
        public double GetPricePerBedSpace()
        {
            double pricePerBed;
            if (BedSpaces == 0 ) 
            {
                return 0;
            }
            else {
                pricePerBed = Rent / (double)BedSpaces;     //this is an example of casting 
                return pricePerBed;

            }
        }
        public override string ToString()
        {
            return $"{HouseNum,-5}{Eircode,-10}{Rent,-10}{EligibleForGrant(),-15}{BedSpaces,-15}{GetPricePerBedSpace(),-15}";
        }

    }
}
