using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Service;

namespace Bolnica.Controller
{
    class ConsumableController
    {
        private ConsumableService consumableService;

        public ConsumableController()
        {
            consumableService = new ConsumableService();
        }

        public void AddConsumable(ConsumableEquipment consumable)
        {
            consumableService.AddConsumable(consumable);
        }

        public void RemoveConsumable(int consumableId)
        {
            consumableService.RemoveConsumable(consumableId);
        }

        public void ViewConsumable(int consumableId)
        {
            consumableService.ViewConsumable(consumableId);
        }

        public void UpdateConsumable(ConsumableEquipment consumable)
        {
            consumableService.UpdateConsumable(consumable);
        }

        public void OrderConsumable(int consumableId, int quantity)
        {
            consumableService.OrderConsumable(consumableId, quantity);
        }

        public ConsumableEquipment FindConsumableById(int consumableId)
        {
            ConsumableEquipment consumable = consumableService.FindConsumableById(consumableId);
            return consumable;
        }
    }
}
