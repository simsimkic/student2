using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Bolnica.Model;

namespace Bolnica.Controller
{
    class MedicationController
    {
        Service.MedicationService medicationService = new Service.MedicationService();

        public ObservableCollection<Medication> ViewMedicationList()
        {
            ObservableCollection<Medication> medList = medicationService.ViewMedicationList();
            return medList;
        }

        public Medication ViewMedication(String medName)
        {
            Medication medication = medicationService.ViewMedication(medName);
            return medication;
        }

        public Boolean ApproveMedication(int medId)
        {
            Boolean isApproved = medicationService.ApproveMedication(medId);
            return isApproved;
        }

        public void AddMedication(Medication medication)
        {
            medicationService.AddMedication(medication);
        }

        public void RemoveMedication(int medicationId)
        {
            medicationService.RemoveMedication(medicationId);
        }

        public void UpdateMedication(Medication medication)
        {
            medicationService.UpdateMedication(medication);
        }

        public void OrderMedication(int medicationId, int quantity)
        {
            medicationService.OrderMedication(medicationId, quantity);
        }

        public Medication FindMedicationById(int medicationId)
        {
            Medication medication = medicationService.FindMedicationById(medicationId);
            return medication;
        }

        public List<Medication> FindAllNotApprovedMedication()
        {
            List<Medication> lista = medicationService.FindAllNotApprovedMedication();
            return lista;
        }
    }
}
