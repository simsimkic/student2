using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;


namespace Bolnica.Repository
{
    class StaticEquipmentRepository
    {
        private RoomRepository roomRepository;

        public StaticEquipmentRepository()
        {
            roomRepository = new RoomRepository();
        }

        public List<StaticEquipment> FindAllStaticEquipmentByRoom(String roomFullname)
        {
            string line;
            List<StaticEquipment> lista = new List<StaticEquipment>();

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/staticEquipment.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(',')[3] == roomFullname)
                    {
                        StaticEquipment staticEquipment = new StaticEquipment();
                        staticEquipment.Id = Int32.Parse(line.Split(',')[0]);
                        staticEquipment.TypeOfStatic = line.Split(',')[1];
                        staticEquipment.Name = line.Split(',')[2];

                        HospitalRoom room = roomRepository.FindRoomByFullname(roomFullname);
                        staticEquipment.Room = room;

                        lista.Add(staticEquipment);
                    }

                }
            }

            return lista;
        }
    }
}
