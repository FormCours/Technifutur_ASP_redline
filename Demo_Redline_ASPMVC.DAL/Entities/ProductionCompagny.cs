using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    public class ProductionCompagny : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }


        public ProductionCompagny(string name)
        {
            this.Id = 0;
            this.Name = name;
        }

        public ProductionCompagny(long id, string name)
            : this(name)
        {
            this.Id = id;
        }
    }
}
