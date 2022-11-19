using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class CRUD : ICRUD
    {
        private static CRUD istanza;

        private CRUD() { }
        public static CRUD Instance
        {
            get
            {
                if (istanza == null)
                {
                    istanza = new CRUD();
                }
                return istanza;
            }
        }

        private List<FiguraGeom> lista = new List<FiguraGeom>();

        public List<FiguraGeom> getLista()
        {
            return lista;
        }
        
        public void inserisciFig(FiguraGeom f)
        {
            lista.Add(f);
        }
        public void eliminaFig(FiguraGeom f)
        {
            lista.Remove(f);
        }
    }
}
