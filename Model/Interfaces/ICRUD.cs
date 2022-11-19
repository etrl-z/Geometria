using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    interface ICRUD
    {
        public List<FiguraGeom> GetLista();
        public void InserisciFig(FiguraGeom f);
        public void EliminaFig(FiguraGeom f);

    }
}
