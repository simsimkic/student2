using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class RenovationRepository
    {
        public void AddRenovation(Renovation renovation)
        {
            using (var writer = new StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/renovations.csv", true))
            {
                string[] values = { renovation.Id.ToString(), renovation.HospitalRoom.Fullname, renovation.StartDate.ToString(), renovation.EndDate.ToString(), renovation.Description };
                string line = String.Join(",", values);
                writer.WriteLine(line);
            }
        }
    }
}
