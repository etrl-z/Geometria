using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class Rettangolo : FiguraGeom, IRandom<Rettangolo>
    {
        public Rettangolo() { nLati = 4; }

        public override double CalcPerimetro()
        {
            return (double)(A.Distanza(B) * 2 + B.Distanza(C) * 2);
        }

        public override double CalcArea()
        {
            return (double)(A.Distanza(B) * B.Distanza(C));
        }

        public bool Equals(Rettangolo r2)
        {
            return (A == r2.A && B == r2.B && C == r2.C && D == r2.D);
        }

        public override bool Equivale(FiguraGeom f2)
        {
            return Math.Abs(CalcArea() - f2.CalcArea()) <= ERR;
        }

        public bool CheckRettangolo()
        {
            double d1 = A.Distanza(C);
            double d2 = B.Distanza(D);

            return (d1 == d2);
        }

        public FiguraGeom GeneraRandom(Rettangolo r)
        {
            r.A = A.PuntoAutom();       //primo punto
            r.B = B.PuntoAutom();
            r.B.Y = r.A.Y;              //secondo punto ha la Y del precendente
            r.C = C.PuntoAutom();
            r.C.X = r.B.X;              //terzo punto ha la X del precedente
            r.D.X = r.A.X;
            r.D.Y = r.C.Y;              //quarto punto ha la X del primo e la Y del precedente

            return r;
        }

        public override string ToString()
        {
            return "Rettangolo di Punti: A" + A + ", B" + B + ", C" + C + ", D" + D;
        }
    }
}
