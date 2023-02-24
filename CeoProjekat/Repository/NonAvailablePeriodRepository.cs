using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class NonAvailablePeriodRepository
    {
        private RoomRepository roomRepository;

        public NonAvailablePeriodRepository()
        {
            roomRepository = new RoomRepository();
        }

        public List<NonAvailableRoomPeriod> FindAllNonAvailablePeriodsByRoom(string name)
        {
            string line;
            List<NonAvailableRoomPeriod> lista = new List<NonAvailableRoomPeriod>();

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\38162\Desktop\Projekat\SIMS projekat\Lokalni repozitorijum\projekat2\project\zdravoCorporationBackend\Files/nonAvailableRoomPeriod.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(',')[3] == name)
                    {
                        NonAvailableRoomPeriod nonAvailableRoomPeriod = new NonAvailableRoomPeriod();
                        nonAvailableRoomPeriod.Id = Int32.Parse(line.Split(',')[0]);
                        nonAvailableRoomPeriod.StartPeriod = line.Split(',')[1];
                        nonAvailableRoomPeriod.EndPeriod = line.Split(',')[2];

                        HospitalRoom room = roomRepository.FindRoomByFullname(name);
                        nonAvailableRoomPeriod.Room = room;

                        lista.Add(nonAvailableRoomPeriod);
                    }

                }
            }

            return lista;
        }
    }
}
