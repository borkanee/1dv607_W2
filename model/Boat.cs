using System;

namespace _1dv607_W2
{
    public class Boat
    {
        private int _length;

        private BoatType _type;

        public int Id { get; }
        public BoatType Type
        {
            get { return _type; }
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


        public Boat(BoatType type, int length, int boatId)
        {
            _type = type;
            Length = length;
            Id = boatId;
        }
    }
}