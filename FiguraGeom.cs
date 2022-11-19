using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    abstract class FiguraGeom
    {
        public Punto A = new Punto();
        public Punto B = new Punto();
        public Punto C = new Punto();
        public Punto D = new Punto();
        public int R = new int();

        public int nLati { get; set; }

        public const double ERR = 0.00001;
        public abstract double calcArea();
        public abstract double calcPerimetro();
        
        public abstract bool Equivale(FiguraGeom f);
    }
}
