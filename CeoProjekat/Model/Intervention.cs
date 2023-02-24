using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Intervention
    {
        public Doctor doctor;
        private int id;
        private String description;
        private Boolean absence;
        private InterventionType type;
        private DateTime start;
        private DateTime end;
        private PriorityType priority;
        private int patientId;
        private int prescriptionId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }
        public int PrescriptionId
        {
            get { return prescriptionId; }
            set { prescriptionId = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Absence
        {
            get { return absence; }
            set { absence = value; }
        }

        private InterventionType _iType;
        public InterventionType Type
        {
            get { return _iType; }
            set { _iType = value; }
        }

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        public PriorityType Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public String DoctorFirstName
        {
            get { return doctor.FirstName; }
            set { doctor.FirstName = value; }
        }
        public String DoctorLastName
        {
            get { return doctor.LastName; }
            set { doctor.LastName = value; }
        }
    }
}
