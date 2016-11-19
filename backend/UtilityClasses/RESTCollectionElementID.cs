using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.UtilityClasses
{
    class RESTCollectionElementID
    {
        public RESTCollectionElementID(uint elementNumber)
        {
            this.elementNumber = elementNumber;
            isCollection = false;
        }

        //dla przypadków w których wiadomo już, że element jest kolekcją
        public RESTCollectionElementID()
        {
            isCollection = true;
            elementNumber = 0;
        }

        public bool IsValid()
        {
            return !isCollection;
        }

        public bool IsCollection()
        {
            return isCollection;
        }

        public uint elementNumber { get; }
        private bool isCollection;
    }
}
