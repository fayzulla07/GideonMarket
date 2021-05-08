using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GideonMarket.Domain.Shared
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public virtual void Validate() { }
    }
}
