﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wpf_app
{
    
    public class PersonOnBoard : IComparable
    {
        
        protected static ulong createdPersons = 0;

        
        protected string name;
        
        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Error!");
                }

                name = value;

            }
        }

        
        protected string email;
        
        public string Email
        {
            get
            {
                return email;
            }
            protected set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Error!");
                }
                email = value;
            }
        }

        public PersonOnBoard(string name, string email)
        {
            Name = name;
            Email = email;
            createdPersons++;
        }

        public static ulong GetCreatedPersons() //counter of created persons(message box)
        {
            return createdPersons;
        }

        public int CompareTo(object obj)
        {
            PersonOnBoard p = obj as PersonOnBoard;
            if (p != null)
                return Name.CompareTo(p.Name);
            else
            {
                throw new Exception("It's impossible to compare two objects");
            }
        }

        public string GetInfoString()
        {
            string info = "Name: " + Name + ", Mail: " + Email;
            return info;
        }
    }
}
