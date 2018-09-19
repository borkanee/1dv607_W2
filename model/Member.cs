using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace _1dv607_W2
{
    class Member
    {
        private readonly int _id;
        private string _name;
        private string _personalNumber;

        private List<Boat> _boats = new List<Boat>();

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 15 || value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Name is too long or too short");
                }
                _name = value;
            }
        }
        public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("You must enter a 10-digit personal number");
                }
                _personalNumber = value;
            }
        }

        public Member(string inputName, string inputPersonalNumber)
        {
            Name = inputName;
            PersonalNumber = inputPersonalNumber;
        }
    }
}