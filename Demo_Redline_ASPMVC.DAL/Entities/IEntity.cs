using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
