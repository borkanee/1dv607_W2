using System;

namespace _1dv607_W2
{
    public class Boat
    {
        private BoatType _type;

        private int _length;

        private int _id;

        public BoatType Type
        {
            get { return _type; }
            private set
            {
                _type = value;
            }
        }

        public int Length
        {
            get { return _length; }
            private set
            {
                if (value > 30)
                {
                    throw new ArgumentOutOfRangeException("Boat is too long");
                }
                _length = value;
            }
        }

        public int Id
        {
            get { return _id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Id has to be larger than 0");
                }
                _id = value;
            }
        }

        public Boat(BoatType type, int length, int boatId)
        {
            if ((!Enum.IsDefined(typeof(BoatType), type)))
            {
                throw new ArgumentOutOfRangeException("A Boat can only be instantiated with defined BoatType");
            }
            Type = type;
            Length = length;
            Id = boatId;
        }
    }
}