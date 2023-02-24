using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Renovation
    {
        private HospitalRoom hospitalRoom;
        private int id;
        private DateTime startDate;
        private DateTime endDate;
        private String description;



        public String Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                }
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value != endDate)
                {
                    endDate = value;
                }
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value != startDate)
                {
                    startDate = value;
                }
            }
        }

        public HospitalRoom HospitalRoom
        {
            get { return hospitalRoom; }
            set
            {
                if (value != hospitalRoom)
                {
                    hospitalRoom = value;
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

    }
}
