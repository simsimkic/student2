using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class ConsumableEquipment : Equipment
    {
        private String typeOfConsumable;

        public String TypeOfConsumable
        {
            get { return typeOfConsumable; }
            set
            {
                if (value != typeOfConsumable)
                {
                    typeOfConsumable = value;
                }
            }
        }
    }
}
