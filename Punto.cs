using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class Punto
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punto() { }

        public Punto(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public double Distanza(Punto p2)
        {
            return Math.Sqrt(((X - p2.X) * (X - p2.X)) + (Y - p2.Y) * (Y - p2.Y));
        }
        public Punto PuntoAutom()
        {
            Random r = new Random();
            Punto p = new Punto();
            p.X = r.Next(0, 20);
            p.Y = r.Next(0, 20);

            return p;
        }

        public override string ToString()
        {
            return "("+X+","+Y+")";
        }
        

    }
}
