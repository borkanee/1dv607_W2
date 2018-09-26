using System;

namespace _1dv607_W2
{
    public class Boat
    {
        private int _length;

        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                if (value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Boat type is too long");
                }
                _type = value;
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (value > 30)
                {
                    throw new ArgumentOutOfRangeException("Boat is too long");
                }
                _length = value;
            }
        }


        public Boat(string type, int length)
        {
            Type = type;
            Length = length;
        }
    }
}