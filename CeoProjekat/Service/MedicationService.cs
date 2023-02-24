using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bolnica.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    class MedicationService
    {
        Repository.MedicationRepository medicationRepository = new Repository.MedicationRepository();

        public ObservableCollection<Medication> ViewMedicationList()
        {
            ObservableCollection<Medication> medList = medicationRepository.ViewMedicationList();
            return medList;
        }

        public Medication ViewMedication(String medName)
        {
            Medication medication = medicationRepository.ViewMedication(medName);
            return medication;
        }
        public Boolean ApproveMedication(int medId)
        {
            Boolean isApproved = medicationRepository.ApproveMedication(medId);
            return isApproved;
        }

        public void AddMedication(Medication medication)
        {
            medicationRepository.AddMedication(medication);
        }

        public void RemoveMedication(int medicationId)
        {
            medicationRepository.RemoveMedication(medicationId);
        }

        public void UpdateMedication(Medication medication)
        {
            medicationRepository.UpdateMedication(medication);
        }

        public void OrderMedication(int medicationId, int quantity)
        {
            Medication medication = medicationRepository.FindMedicationById(medicationId);
            medication.Quantity += quantity;
            medicationRepository.UpdateMedication(medication);
        }

        public List<Medication> ViewAllMedication()
        {
            List<Medication> lista = medicationRepository.FindAllMedication();
            return lista;
        }

        public Medication FindMedicationById(int medicationId)
        {
            Medication medication = medicationRepository.FindMedicationById(medicationId);
            return medication;
        }

        public void ViewMedication(int medicationId)
        {
            Medication medication = medicationRepository.FindMedicationById(medicationId);
            Console.WriteLine("Id : " + medication.Id);
            Console.WriteLine("Name : " + medication.Name);
            Console.WriteLine("Uses : " + medication.Uses);
            Console.WriteLine("Ingridients : " + medication.Ingridients);
        }

        public List<Medication> FindAllNotApprovedMedication()
        {
            List<Medication> lista = medicationRepository.FindAllNotApprovedMedication();
            return lista;
        }
    }
}
