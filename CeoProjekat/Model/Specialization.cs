using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Specialization
    {
        public int id;
        public String specName;

        public string SpecName
        {
            get { return specName; }
            set { specName = value; }
        }

        public string Name { get; internal set; }
        public int Id { get; internal set; }
    }
}
