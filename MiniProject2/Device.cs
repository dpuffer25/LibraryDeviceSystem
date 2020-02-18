// Dalyno Puffer CIS 340 Mini Project 2 4:30PM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2
{
    class Device
    {
        //inital property variables

        private string sku;
        private string name;
        private string avail;

        // property for SKU variable

        public string SKU
        {
            get
            {
                return this.sku;
            }

            set
            {
                this.sku = value;
            }
        }

        // property for name variable

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        //property for avail variable

        public string Avail
        {
            get
            {
                return this.avail;
            }

            set
            {
                this.avail = value;
            }
        }

        //default constructor

        public Device()
        {

        }

        //overloaded constructor 1

        public Device(string name)
        {
            this.Name = Name;
        }

        //overloaded constructor 2

        public Device(string sku, string name, string avail)
        {
            this.Name = name;
            this.SKU = sku;
            this.Avail = avail;
        }
    }
}

