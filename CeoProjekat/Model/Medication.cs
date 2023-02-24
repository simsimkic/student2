using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Medication
    {
        private int id;
        private String name;
        private String ingridients;
        private String uses;
        private Boolean approved = false;
        private int approvingConuter;
        private int quantity = 1;
        private int dose;

        public int ApprovingCounter
        {
            get { return approvingConuter; }
            set { approvingConuter = value; }
        }
        public int Dose
        {
            get { return dose; }
            set { dose = value; }
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

        public Boolean Approved
        {
            get { return approved; }
            set
            {
                if (approved != value)
                {
                    approved = value;
                }
            }
        }

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
        public String Ingridients
        {
            get { return ingridients; }
            set
            {
                if (value != ingridients)
                {
                    ingridients = value;
                }
            }
        }
        public String Uses
        {
            get { return uses; }
            set
            {
                if (value != uses)
                {
                    uses = value;
                }
            }
        }
    }
}
