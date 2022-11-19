using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    interface IRandom<T>
    {
        public FiguraGeom GeneraRandom(T f);
    }
}
