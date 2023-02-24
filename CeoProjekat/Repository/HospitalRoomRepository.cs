using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class HospitalRoomRepository
    {
        public HospitalRoom FindRoomByFullname(String fullname)
        {
            string line;
            HospitalRoom room = new HospitalRoom();
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/rooms.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if ((line.Split(',')[1] + " " + line.Split(',')[2]) == fullname)
                    {
                        room.Id = Int32.Parse(line.Split(',')[0]);
                        room.Tip = line.Split(',')[1];
                        room.Name = line.Split(',')[2];
                        room.Floor = Int32.Parse(line.Split(',')[3]);
                        break;
                    }
                }
            }
            return room;

        }
    }
}
