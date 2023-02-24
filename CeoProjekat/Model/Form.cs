using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Form
    {
        int interventionId;
        FormType formType;
        String description;
        int reportOrPrescription; // 0 if prescription, 1 if report

        public int InterventionId
        {
            get { return interventionId; }
            set { interventionId = value; }
        }
        public int ReportOrPrescription
        {
            get { return reportOrPrescription; }
            set { reportOrPrescription = value; }
        }
        public FormType FFormType
        {
            get { return formType; }
            set { formType = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
