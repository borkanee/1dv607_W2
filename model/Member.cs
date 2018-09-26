using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _1dv607_W2
{
    public class Member
    {
        public int Id { get; }
        private string _name;
        private string _personalNumber;
        private List<Boat> _boats;
        public ReadOnlyCollection<Boat> Boats
        {
            get { return _boats.AsReadOnly(); }
        }
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
        public Member(string inputName, string inputPersonalNumber, int id, List<Boat> boats)
        {
            Name = inputName;
            PersonalNumber = inputPersonalNumber;
            Id = id;
            _boats = boats;
        }
    }
}