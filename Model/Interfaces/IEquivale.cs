using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    interface IEquivale<T>
    {
        public bool Equivale(T f);
        public bool Equals(T f);

    }
}
