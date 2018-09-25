using System;

namespace _1dv607_W2
{
    public class Boat
    {
        // private readonly int _id;
        private int _length;

        public string Type;

        /* public int Id
         {
             get { return _id; }
         }
 */
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
            //_id = ?
            // Boat måste i så fall känna till senaste båt-ID:t?? Create-pattern?
            Type = type;
            Length = length;
        }
    }
}