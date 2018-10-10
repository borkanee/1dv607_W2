using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace _1dv607_W2
{
    public class Member
    {
        private string _name;

        private string _personalNumber;

        private int _id;

        private List<Boat> _boats;

        public string Name
        {
            get { return _name; }
            private set
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
            private set
            {
                if (!Regex.IsMatch(value, @"[0-9]{2}(0[1-9]|(10|11|12))(0[1-9]|[1-2][0-9]|3[0-1])[0-9]{4}$"))
                {
                    throw new ArgumentOutOfRangeException("You must enter a 10-digit personal number (YYMMDDNNNN)");
                }
                _personalNumber = value;
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

        public ReadOnlyCollection<Boat> Boats
        {
            get { return _boats.AsReadOnly(); }
        }

        public Member(string inputName, string inputPersonalNumber, int id, List<Boat> boats)
        {
            Name = inputName;
            PersonalNumber = inputPersonalNumber;
            Id = id;
            _boats = boats;
        }
    }
}