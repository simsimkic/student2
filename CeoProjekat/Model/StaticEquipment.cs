using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class StaticEquipment
    {
        private String typeOfStatic;
        private HospitalRoom room;

        public String TypeOfStatic
        {
            get { return typeOfStatic; }
            set
            {
                if (value != typeOfStatic)
                {
                    typeOfStatic = value;
                }
            }
        }

        public HospitalRoom Room
        {
            get { return room; }
            set
            {
                if (value != room)
                {
                    room = value;
                }
            }
        }

        public string Name { get; internal set; }
        public int Id { get; internal set; }
    }
}
