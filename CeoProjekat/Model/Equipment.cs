using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Equipment
    {
        private int id;
        private String name;
        private int quantity = 1;

        public int Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                }
            }
        }

        public String Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value != quantity)
                {
                    quantity = value;
                }
            }
        }


    }
}

