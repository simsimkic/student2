using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class DirectorRepository
    {
        public Director FindDirectorById(int directorId)
        {
            string line;
            Director director = new Director();
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/directors.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[0] == directorId.ToString())
                    {
                        director.Id = Int32.Parse(line.Split(';')[0]);
                        director.FirstName = line.Split(';')[1];
                        director.LastName = line.Split(';')[2];
                        director.Username = line.Split(';')[3];
                        director.Password = line.Split(';')[4];
                        director.Address = line.Split(';')[5];
                        director.Email = line.Split(';')[6];
                        director.Jmbg = long.Parse(line.Split(';')[7]);
                        director.Birth = line.Split(';')[8];
                        director.Phone = long.Parse(line.Split(';')[9]);
                        break;
                    }
                }
            }
            return director;
        }
    }
}
