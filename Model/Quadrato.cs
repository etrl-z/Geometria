using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class Quadrato : FiguraGeom, IRandom<Quadrato>
    {
        public Quadrato() { nLati = 4; }

        public override double calcPerimetro()
        {
            return (double)(A.Distanza(B) * 4);
        }

        public override double calcArea()
        {
            return (double)(A.Distanza(B) * A.Distanza(B));
        }

        public bool Equals(Quadrato q2)
        {
            return (A == q2.A && B == q2.B && C == q2.C && D == q2.D);
        }

        public override bool Equivale(FiguraGeom f2)
        {
            return Math.Abs(calcArea() - f2.calcArea()) <= ERR;
        }

        public bool testQuadrato()
        {
            double l = A.Distanza(B);
            double d1 = A.Distanza(C);
            double d2 = B.Distanza(D);

            return (calcPerimetro()/4 == l && d1 == d2);
        }

        public FiguraGeom generaRandom(Quadrato q)
        {
            q.A = A.PuntoAutom();           //primo punto
            
            q.B = B.PuntoAutom();           //secondo punto
            q.B.Y = q.A.Y;                  
            
            double lato = A.Distanza(B);    //terzo punto
            q.C.X = q.B.X;              
            q.C.Y = q.B.Y + (int)lato;   
            
            q.D.X = q.A.X;                  //quarto punto
            q.D.Y = q.C.Y;

            return q;
        }

        public override string ToString()
        {
            return "Quadrato di Punti: A" + A + ", B" + B + ", C" + C + ", D" + D;
        }

        
    }
}
