using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivians_MovieApp
{
    internal class Movie
    {
        static int counter;

        private int _num;
        private string _title;
        private string _genre;
        private int _length;
        private int _score;

        public string Title
        {
            get { return _title; }
            set { _title = value; }


        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }


        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }


        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }


        }

        public int Num
        {
            get { return _num; }
            set { _num = value; }

        }
        public Movie() // default constructor
        {
            counter++;
            _num = counter;
        }

        public Movie(string t, string g, int l, int s) // default constructor
        {
            counter++;
            _num = counter;
            Title = t;
            Genre = g;
            Length = l;
            Score = s;
        }

        public string LengthMessage()
        {
            if (Length < 20)
                return "short";
            else if (Length < 90)
                return "medium";
            else
                return "long";

        }

        public override string ToString() // data dump
        {
            return Num + " " + Title + " " + Genre + " " + Length + " " + Score;
        }
    }
}
