using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Bolnica.Model;

namespace Bolnica.Controller
{
    class TherapyController
    {
        Service.TherapyService therapyService = new Service.TherapyService();

        public ObservableCollection<Therapy> ViewTherapies(int patientId)
        {
            return therapyService.ViewTherapies(patientId);
        }

        public Boolean RemoveTherapy(Therapy therapy)
        {
            return therapyService.RemoveTherapy(therapy);
        }

        public Boolean AddTherapy(Therapy therapy)
        {
            return therapyService.AddTherapy(therapy);
        }
    }
}
