using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class SpecializationRepository
    {
        public void addSpecialization(Specialization specialization)
        {
            using (var writer = new StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/specializations.csv", true))
            {
                string[] values = { specialization.Id.ToString(), specialization.Name };
                string line = String.Join(";", values);
                writer.WriteLine(line);
            }
        }

        public Model.Specialization FindSpecializationByName(String name)
        {
            string line;
            Specialization specialization = new Specialization();
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/specializations.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[1] == name)
                    {
                        specialization.Id = Int32.Parse(line.Split(';')[0]);
                        specialization.Name = line.Split(';')[1];
                        break;
                    }
                }
            }
            return specialization;
        }
    }
}
