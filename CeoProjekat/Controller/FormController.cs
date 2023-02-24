using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Controller
{
    class FormController
    {
        Service.FormService formService = new Service.FormService();
        public Boolean AddForm(Form form)
        {
            return formService.AddForm(form);
        }
    }
}
