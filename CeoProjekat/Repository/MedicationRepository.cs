using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class MedicationRepository
    {
        String path = @"C:\Users\Andjela Paunovic\Desktop\CeoProjekat\CeoProjekat\Data\medications.csv";
        public ObservableCollection<Medication> ViewMedicationList()
        {

            ObservableCollection<Medication> medList = new ObservableCollection<Medication>();

            String[] foundRecordInterv;
            String[] linesInterv = File.ReadAllLines(path);

            for (int i = 1; i < linesInterv.Length; i++)
            {

                Medication med = new Medication();
                foundRecordInterv = linesInterv[i].Split(',');

                Medication mappedMedication = mapMedicationData(foundRecordInterv, med);
                medList.Add(mappedMedication);

            }

            return medList;
        }
        public Medication mapMedicationData(String[] foundRecord, Medication med)
        {
            med.Id = Convert.ToInt32(foundRecord[0]);
            med.Name = foundRecord[1];
            med.Ingridients = foundRecord[2];
            med.Uses = foundRecord[3];
            med.Approved = Convert.ToBoolean(foundRecord[4]);
            med.ApprovingCounter = Convert.ToInt32(foundRecord[5]);
            med.Quantity = Convert.ToInt32(foundRecord[6]);
            med.Dose = Convert.ToInt32(foundRecord[7]);

            return med;
        }

        public Medication ViewMedication(String medName)
        {
            Medication medication = new Medication();
            String[] foundRecordMed;
            String[] linesMed = File.ReadAllLines(path);

            for (int i = 1; i < linesMed.Length; i++)
            {
                foundRecordMed = linesMed[i].Split(',');
                if (medName.Equals(foundRecordMed[1]))
                {
                    medication = mapMedicationData(foundRecordMed, medication);
                }
            }

            return medication;
        }

        internal List<Medication> FindAllMedication()
        {
            throw new NotImplementedException();
        }

        public Boolean ApproveMedication(int medId)
        {
            //treba uvecati naci lek po Id-ju i uvecati approvingCounter
            Medication medication = new Medication();


            List<String> lines = new List<String>();

            using (StreamReader reader = new StreamReader(path))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(","))
                    {
                        String[] split = line.Split(',');

                        if (split[0].Equals(Convert.ToString(medId)))
                        {
                            split[5] = Convert.ToString(Convert.ToInt32(split[5]) + 1);
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

            return true;
        }

        public void AddMedication(Model.Medication medication)
        {
            using (var writer = new StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/medications.csv", true))
            {
                string[] values = { medication.Id.ToString(), medication.Name, medication.Ingridients, medication.Uses, medication.Quantity.ToString(), medication.Approved.ToString() };
                string line = String.Join(";", values);
                writer.WriteLine(line);
            }
        }


        public void RemoveMedication(int medicationId)
        {

            List<String> lines = new List<string>();
            string line;

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/medications.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[0] != medicationId.ToString())
                    {
                        lines.Add(line);
                    }
                }
            }

            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/medications.csv"))
            {
                outfile.Write(String.Join(System.Environment.NewLine, lines.ToArray()));
            }
        }


        public Model.Medication FindMedicationById(int medicationId)
        {
            string line;
            Medication medication = new Medication();
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/medications.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[0] == medicationId.ToString())
                    {
                        medication.Id = Int32.Parse(line.Split(';')[0]);
                        medication.Name = line.Split(';')[1];
                        medication.Ingridients = line.Split(';')[2];
                        medication.Uses = line.Split(';')[3];
                        medication.Quantity = Int32.Parse(line.Split(';')[4]);
                        medication.Approved = Boolean.Parse(line.Split(';')[5]);
                        break;
                    }
                }
            }
            return medication;
        }



        public void UpdateMedication(Medication medication)
        {
            List<String> lines = new List<string>();
            string line;

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/medications.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[0] == medication.Id.ToString())
                    {

                        string[] values = { medication.Id.ToString(), medication.Name, medication.Ingridients, medication.Uses, medication.Quantity.ToString(), medication.Approved.ToString() };
                        string line1 = String.Join(";", values);
                        lines.Add(line1);
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
            }

            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/medications.csv"))
            {
                outfile.Write(String.Join(System.Environment.NewLine, lines.ToArray()));
            }
        }


        public List<Medication> FindAllNotApprovedMedication()
        {
            string line;
            List<Medication> lista = new List<Medication>();

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/medications.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[5] == "False")
                    {
                        Medication medication = new Medication();
                        medication.Id = Int32.Parse(line.Split(';')[0]);
                        medication.Name = line.Split(';')[1];
                        medication.Ingridients = line.Split(';')[2];
                        medication.Uses = line.Split(';')[3];
                        medication.Quantity = Int32.Parse(line.Split(';')[4]);
                        medication.Approved = Boolean.Parse(line.Split(';')[5]);
                        lista.Add(medication);
                    }
                }
            }
            return lista;
        }
    }
}
