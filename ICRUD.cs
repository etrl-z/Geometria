using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    interface ICRUD
    {
        public List<FiguraGeom> getLista();
        public void inserisciFig(FiguraGeom f);
        public void eliminaFig(FiguraGeom f);

    }
}
