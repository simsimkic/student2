using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Repository
{
    class FormRepository
    {
        String path = @"C:\Users\Andjela Paunovic\Desktop\CeoProjekat\CeoProjekat\Data\forms.csv";
        public Boolean AddForm(Form form)
        {
            String line = "\n" + form.InterventionId + "," + form.FFormType + "," + form.Description + "," + form.ReportOrPrescription;
            File.AppendAllText(path, line);
            return true;
        }
    }
}
