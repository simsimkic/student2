using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;


namespace Bolnica.Repository
{
    class ConsumableRepository
    {
        private ConsumableEquipmentIdRepository consumableEquipmentIdRepository;

        public ConsumableRepository()
        {
            consumableEquipmentIdRepository = new ConsumableEquipmentIdRepository();
        }

        public void AddConsumable(Model.ConsumableEquipment consumable)
        {
            using (var writer = new StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/consumable.csv", true))
            {
                string[] values = { consumable.Id.ToString(), consumable.Name, consumable.TypeOfConsumable, consumable.Quantity.ToString() };
                string line = String.Join(";", values);
                writer.WriteLine(line);
            }
        }


        public void RemoveConsumable(int consumableId)
        {
            consumableEquipmentIdRepository.RemoveConsumableId(consumableId);

            List<String> lines = new List<string>();
            string line;

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/consumable.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[0] != consumableId.ToString())
                    {
                        lines.Add(line);
                    }
                }
            }

            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/consumable.csv"))
            {
                outfile.Write(String.Join(System.Environment.NewLine, lines.ToArray()));
            }
        }


        public Bolnica.Model.ConsumableEquipment FindConsumableById(int consumableId)
        {
            string line;
            ConsumableEquipment consumable = new ConsumableEquipment();
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/consumable.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[0] == consumableId.ToString())
                    {
                        consumable.Id = Int32.Parse(line.Split(';')[0]);
                        consumable.Name = line.Split(';')[1];
                        consumable.TypeOfConsumable = line.Split(';')[2];
                        consumable.Quantity = Int32.Parse(line.Split(';')[3]);
                        break;
                    }
                }
            }
            return consumable;
        }



        public void UpdateConsumable(ConsumableEquipment consumable)
        {
            List<String> lines = new List<string>();
            string line;

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/consumable.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Split(';')[0] == consumable.Id.ToString())
                    {
                        string[] values = { consumable.Id.ToString(), consumable.Name, consumable.TypeOfConsumable, consumable.Quantity.ToString() };
                        string line1 = String.Join(";", values);
                        lines.Add(line1);
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
            }

            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/consumable.csv"))
            {
                outfile.Write(String.Join(System.Environment.NewLine, lines.ToArray()));
            }
        }

        public List<ConsumableEquipment> FindAllConsumable()
        {
            string line;
            List<ConsumableEquipment> lista = new List<ConsumableEquipment>();

            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/38162/Desktop/Projekat/SIMS projekat/Lokalni repozitorijum/projekat2/project/zdravoCorporationBackend/Files/consumable.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    ConsumableEquipment consumable = new ConsumableEquipment();
                    consumable.Id = Int32.Parse(line.Split(';')[0]);
                    consumable.Name = line.Split(';')[1];
                    consumable.TypeOfConsumable = line.Split(';')[2];
                    consumable.Quantity = Int32.Parse(line.Split(';')[3]);
                    lista.Add(consumable);
                }
            }

            return lista;
        }
    }
}
