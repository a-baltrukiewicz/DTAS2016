using System;
using System.Collections.Generic;

namespace backend.DataObjects
{
    class Tag
    {
        public uint id { get; set; }
        public string name { get; set; }
        //wewnętrzne id do przyśpieszenia wyszukiwania
        
        public Tag() { }

        public Tag(string name, uint id)
        {
            this.name = name;
            this.id = id;
        }

        public static bool operator ==(Tag lhs, Tag rhs)
        {
            if (lhs.id == rhs.id)
                return true;
            return false;
        }

        public static bool operator !=(Tag lhs, Tag rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return this.name;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Tag p = (Tag)obj;
            return (name == p.name) && (id == p.id);
        }
    }
}
