using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using Bolnica.Model;

namespace Bolnica.Controller
{
    class InterventionController
    {
        Service.InterventionService interventionService = new Service.InterventionService();

        public Model.Intervention CreateIntervention(DateTime start, String doctorName, String interventionType, int patientId)
        {
            Doctor doctor1 = new Doctor();
            Intervention intervention = new Intervention();
            intervention.Doctor = doctor1;

            int count = CountLinesInFile("C:/Users/Andjela Paunovic/Desktop/projekat2/project/zdravoCorporationBackend/HCI_wpf_Andjela_Paunovic/HCI_wpf_Andjela_Paunovic/CSV/interventions.csv");
            intervention.Id = count - 1;
            intervention.Start = start;
            if (interventionType == "surgery")
                intervention.Type = InterventionType.surgery;
            else if (interventionType == "examination")
                intervention.Type = InterventionType.examination;
            else
                intervention.Type = InterventionType.stationaryTreatment;
            String[] words = doctorName.Split(' ');
            String idString = words[0];
            int idInt;
            Int32.TryParse(idString, out idInt);
            intervention.doctor.ID = idInt;
            intervention.doctor.FirstName = words[1];
            intervention.doctor.LastName = words[2];
            intervention.PatientId = patientId;

            return intervention;
        }

        static int CountLinesInFile(string f)
        {
            int count = 0;
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }

        public Model.Intervention ScheduleIntervention(Model.Intervention intervention)
        {
            Intervention scheduledIntervention = interventionService.ScheduleIntervention(intervention);
            return scheduledIntervention;
        }

        public ObservableCollection<Intervention> ViewScheduledInterventions(int doctorId)
        {
            ObservableCollection<Intervention> interventions = interventionService.ViewScheduledInterventions(doctorId);
            return interventions;
        }

        public List<Intervention> ViewEarlierInterventions(int patientId)
        {
            List<Intervention> interventions = interventionService.ViewEarlierInterventions(patientId);
            return interventions;
        }
        public List<Intervention> ViewFutureInterventions(int patientId)
        {
            List<Intervention> interventions = interventionService.ViewFutureInterventions(patientId);
            return interventions;
        }

        public Intervention ViewIntervention(int interventionId)
        {
            Intervention intervention = interventionService.ViewIntervention(interventionId);
            return intervention;
        }

        public ObservableCollection<Intervention> ViewAllInterventions(int patientId)
        {
            ObservableCollection<Intervention> interventions = interventionService.ViewScheduledInterventions(patientId);
            return interventions;
        }

        public int AddDescription(int patientId, String description)
        {
            return interventionService.AddDescription(patientId, description);
        }
    }
}
