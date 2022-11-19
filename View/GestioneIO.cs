using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    static class GestioneIO
    {
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("---| FIGURE GEOMETRICHE |---");
            Console.WriteLine(" ");
            Console.WriteLine("Scegli un'operazione:");
            Console.WriteLine(" ");
            Console.WriteLine("1] Crea nuova figura");
            Console.WriteLine("2] Visualizza elenco figure");
            Console.WriteLine("3] Modifica figura");
            Console.WriteLine("4] Elimina figura");
            Console.WriteLine(" ");
            Console.WriteLine("5] Analizza una figura");
            Console.WriteLine("6] Confronta due figure");
            Console.WriteLine(" ");
            Console.WriteLine("8] Esci");
            int scelta = Utility.LeggiIntero("");

            return scelta;
        }

        public static void Home()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Premi un tasto per tornare al Menu...");
            Console.ReadKey();
        }

        public static void EmptyList()
        {
            Console.WriteLine("Non ci sono figure in elenco!");
        }

        public static int MaskSceltaFig()
        {
            Console.Clear();
            Console.WriteLine("---| NUOVO INSERIMENTO |---");
            Console.WriteLine(" ");
            Console.WriteLine("Che tipo di figura vuoi creare?");
            Console.WriteLine(" ");
            Console.WriteLine("1] Quadrato");
            Console.WriteLine("2] Rettangolo");
            Console.WriteLine("3] Triangolo");
            Console.WriteLine("4] Cerchio");
            int scelta = Utility.LeggiIntero("");

            return scelta;
        }

        public static FiguraGeom MaskCreazione(FiguraGeom f)
        {
            Console.Clear();
            Console.WriteLine("---| NUOVO INSERIMENTO |---");
            Console.WriteLine(" ");
            string R = Utility.LeggiStringa("Premi INVIO per continuare / Premi R per Generare automaticamente").ToLower();

            if (f is Cerchio c)
            {
                if (R == "r")
                {
                    c.GeneraRandom(c);
                }
                else
                {
                    c.C = Punto.SetCoord("Inserisci Centro");
                    c.R = Utility.LeggiIntero("Inserisci Raggio:");
                }
            }

            else if (f is Triangolo t)
            {
                if (R == "r")
                {
                    t.GeneraRandom(t);
                }
                else
                {
                    t.A = Punto.SetCoord("Inserisci punto A");
                    t.B = Punto.SetCoord("Inserisci punto B");
                    t.C = Punto.SetCoord("Inserisci punto C");
                }
            }
            
            else if (f.nLati == 4)
            {
                if (R == "r" && f is Quadrato q)
                {
                    q.GeneraRandom(q);
                }
                else if (R == "r" && f is Rettangolo r)
                {
                    r.GeneraRandom(r);
                }
                else
                {
                    f.A = Punto.SetCoord("Inserisci punto A");
                    f.B = Punto.SetCoord("Inserisci punto B");
                    f.C = Punto.SetCoord("Inserisci punto C");
                    f.D = Punto.SetCoord("Inserisci punto D");
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("Inserimento completato!");

            return f;
        }

        public static void MaskVisualizza(List<FiguraGeom> lista)
        {
            Console.Clear();
            Console.WriteLine("---| ELENCO FIGURE INSERITE |---");
            Console.WriteLine(" ");

            foreach (FiguraGeom f in lista)
            {
                Console.WriteLine(f);
            }
        }

        public static FiguraGeom MaskScegliMod(List<FiguraGeom> lista)
        {
            Console.Clear();
            Console.WriteLine("---| ELENCO FIGURE INSERITE |---");
            Console.WriteLine(" ");
            int index = 1;
            foreach (FiguraGeom f in lista)
            {
                Console.WriteLine(index + "] " + f);
                index++;
            }
            Console.WriteLine(" ");
            int scelta = Utility.LeggiIntero("Scegli una figura:");

            return lista[scelta - 1];
        }

        public static FiguraGeom MaskModifica(FiguraGeom f)
        {
            Console.Clear();
            Console.WriteLine("---| MODIFICA FIGURA " + f + " |---");
            Console.WriteLine(" ");

            if (f is Cerchio c)
            {
                c.C = Punto.SetCoord("Modifica Centro " + c.C);
                c.R = Utility.LeggiIntero("Modifica Raggio: " + c.R);
            }
            else
            {
                f.A = Punto.SetCoord("Modifica punto A " + f.A);
                f.B = Punto.SetCoord("Modifica punto B " + f.B);
                f.C = Punto.SetCoord("Modifica punto C " + f.C);

                if (f.nLati == 4)
                {
                    f.D = Punto.SetCoord("Modifica punto D " + f.D);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Modifica completata!");

            return f;
        }
        public static string MaskElimina(FiguraGeom f)
        {
            Console.WriteLine(" ");
            string confirm = Utility.LeggiStringa("Vuoi eliminare " + f + " ?").ToLower();

            if (confirm == "s") { Console.WriteLine("La figura è stata eliminata!"); }

            return confirm;
        }

        public static void MaskConfronta(List<FiguraGeom> lista)
        {
            Console.Clear();
            Console.WriteLine("---| CONFRONTA DUE FIGURE |---");
            Console.WriteLine(" ");
            int index = 1;
            foreach (FiguraGeom f in lista)
            {
                Console.WriteLine(index + "] " + f);
                index++;
            }
            Console.WriteLine(" ");
            int scelta1 = Utility.LeggiIntero("Scegli la prima figura:");
            int scelta2 = Utility.LeggiIntero("Scegli la seconda figura:");

            FiguraGeom f1 = lista[scelta1 - 1];
            FiguraGeom f2 = lista[scelta2 - 1];
            Console.WriteLine("Stai confrontando:");
            Console.WriteLine(f1);
            Console.WriteLine(f2);

            if (f1.Equivale(f2))
            {
                Console.WriteLine("Le due figure hanno la stessa area!");
            }
            else if (((Cerchio)f1).Equals((Cerchio)f2))
            {
                Console.WriteLine("Le due figure sono coincidenti!"); //NON FUNZIONA
            }
        }

        public static void MaskTest(FiguraGeom f)
        {
            Console.Clear();
            Console.WriteLine("---| ANALIZZA LA FIGURA " + f + " |---");
            Console.WriteLine(" ");

            if (f is Cerchio c)
            {
                Console.WriteLine("La figura è un cerchio di:");
                Console.WriteLine("Area " + c.CalcArea());
                Console.WriteLine("Circonferenza " + c.CalcPerimetro());
            }
            else if (f is Triangolo t)
            {
                if (t.CheckEquilatero())
                {
                    Console.WriteLine("Il triangolo è Equilatero di:");
                }
                else if (t.CheckIsoscele())
                {
                    if (t.CheckTriangoloRettangolo())
                    {
                        Console.WriteLine("Il triangolo è Rettangolo Isoscele di:");
                    }
                    else
                    {
                        Console.WriteLine("Il triangolo è Isoscele di:");
                    }
                }
                else
                {
                    if (t.CheckTriangoloRettangolo())
                    {
                        Console.WriteLine("Il triangolo è Rettangolo Scaleno di:");
                    }
                    else
                    {
                        Console.WriteLine("Il triangolo è Scaleno di:");
                    }
                }
                Console.WriteLine("Area " + t.CalcArea());
                Console.WriteLine("Perimetro " + t.CalcPerimetro());
            }
            else
            {
                if (f is Quadrato q && q.CheckQuadrato())
                {
                    Console.WriteLine("La figura è un Quadrato di:");
                    Console.WriteLine("Area " + q.CalcArea());
                    Console.WriteLine("Perimetro " + q.CalcPerimetro());
                }
                else if (f is Rettangolo r && r.CheckRettangolo())
                {
                    Console.WriteLine("La figura è un Rettangolo di:");
                    Console.WriteLine("Area " + r.CalcArea());
                    Console.WriteLine("Perimetro " + r.CalcPerimetro());
                }
                else
                {
                    Console.WriteLine("La figura è un quadrilatero generico!");
                }
            }
        }
    }
}
