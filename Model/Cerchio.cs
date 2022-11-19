using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class Cerchio : FiguraGeom, IRandom<Cerchio>
    {
        public Cerchio() { }

        public override double CalcPerimetro()
        {
            return (double)(2 * R * Math.PI);
        }
        public override double CalcArea()
        {
            return (double)(R * R * Math.PI);
        }
        public bool Equals(Cerchio c2)
        {
            return (C.X == c2.C.X && C.Y == c2.C.Y && R == c2.R);
        }

        public override bool Equivale(FiguraGeom f2)
        {
            return Math.Abs(CalcArea() - f2.CalcArea()) <= ERR;
        }
        public FiguraGeom GeneraRandom(Cerchio c)
        {
            Random r = new Random();
            c.C = C.PuntoAutom();
            c.R = r.Next(1,20);

            return c;
        }

        public override string ToString()
        {
            return "Cerchio di Centro C" + C + " e Raggio " + R;
        }
    }
}
