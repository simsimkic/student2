using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Service
{
    class FormService
    {
        Repository.FormRepository formRepository = new Repository.FormRepository();
        public Boolean AddForm(Form form)
        {
            return formRepository.AddForm(form);
        }
    }
}
