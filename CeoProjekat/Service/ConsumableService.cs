using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Repository;

namespace Bolnica.Service
{
    class ConsumableService
    {
        private ConsumableRepository consumableRepository;

        public ConsumableService()
        {
            consumableRepository = new ConsumableRepository();
        }

        public void AddConsumable(ConsumableEquipment consumable)
        {
            consumableRepository.AddConsumable(consumable);
        }

        public void RemoveConsumable(int consumableId)
        {
            consumableRepository.RemoveConsumable(consumableId);
        }

        public void UpdateConsumable(ConsumableEquipment consumable)
        {
            consumableRepository.UpdateConsumable(consumable);
        }

        public void OrderConsumable(int consumableId, int quantity)
        {
            ConsumableEquipment consumable = consumableRepository.FindConsumableById(consumableId);
            consumable.Quantity += quantity;
            consumableRepository.UpdateConsumable(consumable);
        }

        public List<ConsumableEquipment> ViewAllConsumable()
        {
            List<ConsumableEquipment> lista = consumableRepository.FindAllConsumable();
            return lista;
        }

        public ConsumableEquipment FindConsumableById(int consumableId)
        {
            ConsumableEquipment consumable = consumableRepository.FindConsumableById(consumableId);
            return consumable;
        }

        public void ViewConsumable(int consumableId)
        {
            ConsumableEquipment consumable = consumableRepository.FindConsumableById(consumableId);
            Console.WriteLine("Id : " + consumable.Id);
            Console.WriteLine("Type : " + consumable.TypeOfConsumable);
            Console.WriteLine("Name : " + consumable.Name);
            Console.WriteLine("Quantity : " + consumable.Quantity);
        }
    }
}
