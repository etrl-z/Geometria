using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class Triangolo : FiguraGeom, IRandom<Triangolo>
    {
        public Triangolo() { nLati = 3; }

        public override double calcPerimetro()
        {
            return (double)(A.Distanza(B) + B.Distanza(C) + C.Distanza(A));
        }

        public override double calcArea()
        {
            double p = calcPerimetro() / 2;

            return Math.Sqrt(p * (p - A.Distanza(B)) * (p - B.Distanza(C)) * (p - C.Distanza(A)));
        }

        public bool Equals(Triangolo t2)
        {
            return (A == t2.A && B == t2.B && C == t2.C);
        }

        public override bool Equivale(FiguraGeom f2)
        {
            return Math.Abs(calcArea() - f2.calcArea()) <= ERR;
        }

        public FiguraGeom generaRandom(Triangolo t)
        {
            t.A = A.PuntoAutom();
            t.B = B.PuntoAutom();
            t.C = C.PuntoAutom();

            return t;
        }

        public bool tEquilatero()
        {
            double AB = A.Distanza(B);
            double BC = B.Distanza(C);
            double CA = C.Distanza(A);

            return (AB == BC && BC == CA);
        }

        public bool tIsoscele()
        {
            double AB = A.Distanza(B);
            double BC = B.Distanza(C);
            double CA = C.Distanza(A);

            return (AB == BC || AB == CA || BC == CA);
        }

        public bool tRettangolo()
        {
            double AB = A.Distanza(B);
            double BC = B.Distanza(C);
            double CA = C.Distanza(A);

            return (AB * AB + BC * BC - CA * CA <= ERR || AB * AB + CA * CA - BC * BC <= ERR || CA * CA + BC * BC - AB * AB <= ERR);
        }

        public override string ToString()
        {
            return "Triangolo di Punti: A" + A + ", B" + B + ", C" + C;
        }

    }
}
