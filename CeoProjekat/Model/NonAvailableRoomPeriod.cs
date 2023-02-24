using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class NonAvailableRoomPeriod
    {
        private int id;
        private String startPeriod;
        private String endPeriod;
        private HospitalRoom room;

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

        public String StartPeriod
        {
            get { return startPeriod; }
            set
            {
                if (value != startPeriod)
                {
                    startPeriod = value;
                }
            }
        }

        public String EndPeriod
        {
            get { return endPeriod; }
            set
            {
                if (value != endPeriod)
                {
                    endPeriod = value;
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

    }
}
