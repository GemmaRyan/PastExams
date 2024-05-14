using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unas_solution_to_CA3
{
    internal class Event
    {
        static int eventIdCounter = 1;
        int _eventNumber;
        string _name;
        string _eventType;
        decimal _price;
        int _capactity;
        int _seatsSold;
        public string Name { get { return _name; } private set { _name = value; } }

        public int EventNumber { get; set; }
        public string EventType
        {
            get { return _eventType; }

            set
            {

                value = value.ToLower().Trim();
                if (value == "concert" || value == "sporting" || value == "drama" || value == "comedy")
                {
                    _eventType = value;
                }
                else
                {
                    throw new ArgumentException("Must be one of sporting, drams, comedy or concert ");
                }
            }
        }
        public decimal Price
        {

            get { return _price; }

            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentException("Must be greater than zero");
                }
            }
        }
        public int Capactity
        {
            get { return _capactity; }

            set
            {
                if (value > 0)
                {
                    _capactity = value;
                }
                else
                {
                    throw new ArgumentException("Must be greater than zero");
                }
            }
        }
        public int SeatsSold
        {
            get { return _seatsSold; }
            private set { _seatsSold = value; }
        }

        public Event(string name, string eventType, decimal price, int capactity, int seatsSold)
        {
            // Teaching note: By setting the properties rather than the
            // underlying private attributes we make use of the exception handling of the
            // setters.

            Name = name;
            EventType = eventType;
            Price = price;
            Capactity = capactity;
            SeatsSold = seatsSold;
            EventNumber = eventIdCounter++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="eventType"></param>
        /// <param name="price"></param>
        /// <param name="capactity"></param>
        public Event(string name, string eventType, decimal price, int capactity) : this(name, eventType, price, capactity, 0)
        {
            // Teaching Note: This makes use of the other constructor rather than repeating code
            // the this keyword above calls the construtor for this class since we give it 5 arguments
            // it calls the parameter with 5 arguments.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A string with either Low, Medium, High or Unknown</returns>
        public string GetPriceClassification()
        {
            string classification = "";

            switch (_price)
            {
                case decimal p when ((p >= 0m) && (p < 50m)):
                    classification = "Low";
                    break;
                case decimal p when ((p >= 50m) && (p < 100m)):
                    classification = "Medium";
                    break;
                case decimal p when (p >= 100m):
                    classification = "High";
                    break;
                default:
                    classification = "UNKNOWN";
                    break;
            }

            return classification;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A double as percetage</returns>
        public double CalculatePercentageSeatsSold()
        {

            // teaching note: We don't need to be concerned about the 
            // Capacitiy being zero as the class does not allow that.
            return (double)SeatsSold / (double)Capactity;
        }

        public override string ToString()
        {
            return $" {EventNumber,-10} {Name,-15} {EventType,-10} {Price,-10:C2} {GetPriceClassification(),-10} {Capactity,-10} {SeatsSold,-10} {CalculatePercentageSeatsSold() * 100,-10:F2}% sold";

        }
    }
}
