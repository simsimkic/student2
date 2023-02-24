using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    enum InterventionType { EXAMINATION, SURGEON, STATIONARY_TREATMENT };

    class HospitalRoom
    {
        private int id;
        private InterventionType type;
        private String name;
        private int floor;

        public String Fullname
        {
            get { return type + " " + name; }
        }


        public String Tip
        {
            set
            {
                if (value == "EXAMINATION")
                {
                    type = InterventionType.EXAMINATION;
                }
                else if (value == "SURGEON")
                {
                    type = InterventionType.SURGEON;
                }
                else if (value == "STATIONARY_TREATMENT")
                {
                    type = InterventionType.STATIONARY_TREATMENT;
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

        public int Floor
        {
            get { return floor; }
            set
            {
                if (value != floor)
                {
                    floor = value;
                }
            }
        }
    }
}
