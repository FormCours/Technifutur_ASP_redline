using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    public class ProductionCompany : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }


        public ProductionCompany(string name)
        {
            this.Id = 0;
            this.Name = name;
        }

        public ProductionCompany(long id, string name)
            : this(name)
        {
            this.Id = id;
        }
    }
}
