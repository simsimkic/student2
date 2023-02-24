using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Director : User
    {
        public long Jmbg { get; internal set; }
        public string Birth { get; internal set; }
        public long Phone { get; internal set; }
    }
}
