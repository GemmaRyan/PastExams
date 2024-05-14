using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June_Exam_2023
{
    internal class CommercialProperty : Property
    {
        private string _rateBand;

        public string RateBand
        { 
            get { return _rateBand; }
            set {
                bool check;
                do // repeating the question until the correct answer is given isntead of ending the code
                {
                    _rateBand = value;
                    if (value.Trim().ToUpper() == "A" || value.Trim().ToUpper() == "B" || value.Trim().ToUpper() == "C")    //triming and getting an uppercase for each answer
                    {
                        check = true;
                        _rateBand = value;
                    }
                    else { throw new ArgumentException("Invalid Band Rate please choose A, B or C"); check = false; } //stupid exception handling which just ends the code 
                } while (check == false);
                
            } 
        }

        public CommercialProperty() : base() //default constructor
        {

        }
        public CommercialProperty(string eircode, double rent, int bed , string rate) : base(eircode , rent ,bed) //paramerterised constructor
        {
            RateBand = rate; 
        }

        public override bool EligibleForGrant()
        {
            if (RateBand == "A")
            {
                return true;
            }
            else return false;
        }
        public override string ToString()
        {
            return $"{HouseNum,-5}{Eircode,-10}{Rent,-10}{EligibleForGrant(),-15}{BedSpaces,-15}{GetPricePerBedSpace(),-15}{RateBand,-10}";
        }       //{"#",-1}{"Eircode",-10}{"Rent",-15} {"Eligible", -25} {"Bed Spaces",-30} {"Cost per bed",-35} {"Rates",-40}"
    }
}
