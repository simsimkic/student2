using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Therapy
    {
        int patientId;
        int dose;
        String medicationName;

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }
        public int Dose
        {
            get { return dose; }
            set { dose = value; }
        }
        public String MedicationName
        {
            get { return medicationName; }
            set { medicationName = value; }
        }
    }
}
