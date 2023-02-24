using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class InterventionRepository
    {
        String path = @"C:\Users\Andjela Paunovic\Desktop\CeoProjekat\CeoProjekat\Data\interventions.csv";
        public Intervention AddIntervention(Intervention intervention)
        {
            String line = "\n" + intervention.Id + "," + intervention.doctor.ID + "," + intervention.doctor.FirstName + "," +
                intervention.doctor.LastName + "," + intervention.PatientId + "," + intervention.PrescriptionId + ","
                + intervention.Start + "," + intervention.End + "," + intervention.Absence +
                "," + intervention.Description + "," + intervention.Type;
            File.AppendAllText(path, line);

            return null;
        }
        public ObservableCollection<Intervention> ViewScheduledInterventions(int doctorID)
        {
            ObservableCollection<Intervention> interventions = new ObservableCollection<Intervention>();
            String[] foundRecordInterv;
            String[] linesInterv = File.ReadAllLines(path);

            for (int i = 1; i < linesInterv.Length; i++)
            {

                Intervention interv = new Intervention();
                interv.doctor = new Doctor();
                foundRecordInterv = linesInterv[i].Split(',');

                if (Convert.ToInt32(foundRecordInterv[1]) == doctorID)
                {
                    Intervention mappedIntervention = mapInterventionData(foundRecordInterv, interv);
                    if (mappedIntervention.Start > DateTime.Now)
                    {
                        interventions.Add(mappedIntervention);
                    }
                }
            }
            return interventions;
        }

        public List<Intervention> ViewEarlierInterventions(int patientID)
        {
            List<Intervention> interventions = new List<Intervention>();
            String[] foundRecordInterv;
            String[] linesInterv = File.ReadAllLines(path);

            for (int i = 1; i < linesInterv.Length; i++)
            {

                Intervention interv = new Intervention();
                interv.doctor = new Doctor();
                foundRecordInterv = linesInterv[i].Split(',');

                if (Convert.ToInt32(foundRecordInterv[4]) == patientID)
                {
                    Intervention mappedIntervention = mapInterventionData(foundRecordInterv, interv);
                    if (interv.Start < DateTime.Now)
                    {
                        interventions.Add(mappedIntervention);
                    }
                }
            }
            return interventions;
        }
        public List<Intervention> ViewFutureInterventions(int patientID)
        {
            List<Intervention> interventions = new List<Intervention>();
            String[] foundRecordInterv;
            String[] linesInterv = File.ReadAllLines(path);

            for (int i = 1; i < linesInterv.Length; i++)
            {

                Intervention interv = new Intervention();
                interv.doctor = new Doctor();
                foundRecordInterv = linesInterv[i].Split(',');

                if (Convert.ToInt32(foundRecordInterv[4]) == patientID)
                {
                    Intervention mappedIntervention = mapInterventionData(foundRecordInterv, interv);
                    if (interv.Start > DateTime.Now)
                    {
                        interventions.Add(mappedIntervention);
                    }
                }
            }
            return interventions;
        }
        public Intervention mapInterventionData(String[] foundRecord, Intervention interv)
        {
            interv.Id = Convert.ToInt32(foundRecord[0]);
            interv.doctor.ID = Convert.ToInt32(foundRecord[1]);
            interv.doctor.FirstName = foundRecord[2];
            interv.doctor.LastName = foundRecord[3];
            interv.PatientId = Convert.ToInt32(foundRecord[4]);
            interv.PrescriptionId = Convert.ToInt32(foundRecord[5]);
            interv.Start = Convert.ToDateTime(foundRecord[6]);
            interv.End = Convert.ToDateTime(foundRecord[7]);
            interv.Absence = Convert.ToBoolean(foundRecord[8]);
            interv.Description = foundRecord[9];
            if (foundRecord[10] == "surgery")
                interv.Type = InterventionType.surgery;
            else if (foundRecord[10] == "examination")
                interv.Type = InterventionType.examination;
            else
                interv.Type = InterventionType.stationaryTreatment;

            return interv;
        }

        public Intervention ViewIntervention(int interventionId)
        {
            String[] foundRecordInterv;
            Intervention intervention = new Intervention();
            String[] linesInterv = File.ReadAllLines(path);

            for (int i = 1; i < linesInterv.Length; i++)
            {
                foundRecordInterv = linesInterv[i].Split(',');
                if (interventionId == Convert.ToInt32(foundRecordInterv[0]))
                {
                    intervention = mapInterventionData(foundRecordInterv, intervention);
                }
            }

            return intervention;
        }

        public ObservableCollection<Intervention> ViewAllInterventions(int patientID)
        {
            ObservableCollection<Intervention> interventions = new ObservableCollection<Intervention>();
            String[] foundRecordInterv;
            String[] linesInterv = File.ReadAllLines(path);

            for (int i = 1; i < linesInterv.Length; i++)
            {

                Intervention interv = new Intervention();
                interv.doctor = new Doctor();
                foundRecordInterv = linesInterv[i].Split(',');

                if (Convert.ToInt32(foundRecordInterv[4]) == patientID)
                {
                    Intervention mappedIntervention = mapInterventionData(foundRecordInterv, interv);
                    interventions.Add(mappedIntervention);
                }
            }
            return interventions;
        }
        public int AddDescription(int patientId, String description)
        {

            List<String> lines = new List<String>();
            int id = 0;

            using (StreamReader reader = new StreamReader(path))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {

                    if (line.Contains(","))
                    {
                        String[] split = line.Split(',');

                        if (split[4].Equals(Convert.ToString(patientId)) && split[9] == "")
                        {
                            split[9] = description;
                            id = Convert.ToInt32(split[0]);

                            line = String.Join(",", split);
                        }
                    }

                    lines.Add(line);

                }
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (String line in lines)
                    writer.WriteLine(line);
            }
            return id;
        }
    }
}
