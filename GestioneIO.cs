using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class GestioneIO
    {
        public int menu()
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
            int scelta = leggiIntero("");

            return scelta;
        }

        public void home()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Premi un tasto per tornare al menu...");
            System.ConsoleKeyInfo enter = Console.ReadKey();
        }

        public void error()
        {
            Console.WriteLine("Non ci sono figure in elenco!");
        }

        public int maskSceltaFig()
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
            int scelta = leggiIntero("");

            return scelta;
        }

        public FiguraGeom maskCreazione(FiguraGeom f)
        {
            Console.Clear();
            Console.WriteLine("---| NUOVO INSERIMENTO |---");
            Console.WriteLine(" ");
            string R = leggiStringa("Premi INVIO per continuare / Premi R per Generare automaticamente").ToLower();

            if (f is Cerchio c)
            {
                if (R == "r")
                {
                    c.generaRandom(c);
                }
                else
                {
                    c.C = setCoord("Inserisci Centro");
                    c.R = leggiIntero("Inserisci Raggio:");
                }
            }

            else if (f is Triangolo t)
            {
                if (R == "r")
                {
                    t.generaRandom(t);
                }
                else
                {
                    t.A = setCoord("Inserisci punto A");
                    t.B = setCoord("Inserisci punto B");
                    t.C = setCoord("Inserisci punto C");
                }
            }
            
            else if (f.nLati == 4)
            {
                if (R == "r" && f is Quadrato q)
                {
                    q.generaRandom(q);
                }
                else if (R == "r" && f is Rettangolo r)
                {
                    r.generaRandom(r);
                }
                else
                {
                    f.A = setCoord("Inserisci punto A");
                    f.B = setCoord("Inserisci punto B");
                    f.C = setCoord("Inserisci punto C");
                    f.D = setCoord("Inserisci punto D");
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("Inserimento completato!");

            return f;
        }

        public void maskVisualizza(List<FiguraGeom> lista)
        {
            Console.Clear();
            Console.WriteLine("---| ELENCO FIGURE INSERITE |---");
            Console.WriteLine(" ");

            foreach (FiguraGeom f in lista)
            {
                Console.WriteLine(f);
            }
        }

        public FiguraGeom maskScegliMod(List<FiguraGeom> lista)
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
            int scelta = leggiIntero("Scegli una figura:");

            return lista[scelta - 1];
        }

        public FiguraGeom maskModifica(FiguraGeom f)
        {
            Console.Clear();
            Console.WriteLine("---| MODIFICA FIGURA " + f + " |---");
            Console.WriteLine(" ");

            if (f is Cerchio c)
            {
                c.C = setCoord("Modifica Centro " + c.C);
                c.R = leggiIntero("Modifica Raggio: " + c.R);
            }
            else
            {
                f.A = setCoord("Modifica punto A " + f.A);
                f.B = setCoord("Modifica punto B " + f.B);
                f.C = setCoord("Modifica punto C " + f.C);

                if (f.nLati == 4)
                {
                    f.D = setCoord("Modifica punto D " + f.D);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Modifica completata!");

            return f;
        }
        public string maskElimina(FiguraGeom f)
        {
            Console.WriteLine(" ");
            string confirm = leggiStringa("Vuoi eliminare " + f + " ?").ToLower();

            if (confirm == "s") { Console.WriteLine("La figura è stata eliminata!"); }

            return confirm;
        }

        public void maskConfronta(List<FiguraGeom> lista)
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
            int scelta1 = leggiIntero("Scegli la prima figura:");
            int scelta2 = leggiIntero("Scegli la seconda figura:");

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

        public void maskTest(FiguraGeom f)
        {
            Console.Clear();
            Console.WriteLine("---| ANALIZZA LA FIGURA " + f + " |---");
            Console.WriteLine(" ");

            if (f is Cerchio c)
            {
                Console.WriteLine("La figura è un cerchio di:");
                Console.WriteLine("Area " + c.calcArea());
                Console.WriteLine("Circonferenza " + c.calcPerimetro());
            }
            else if (f is Triangolo t)
            {
                if (t.tEquilatero())
                {
                    Console.WriteLine("Il triangolo è Equilatero di:");
                }
                else if (t.tIsoscele())
                {
                    if (t.tRettangolo())
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
                    if (t.tRettangolo())
                    {
                        Console.WriteLine("Il triangolo è Rettangolo Scaleno di:");
                    }
                    else
                    {
                        Console.WriteLine("Il triangolo è Scaleno di:");
                    }
                }
                Console.WriteLine("Area " + t.calcArea());
                Console.WriteLine("Perimetro " + t.calcPerimetro());
            }
            else
            {
                if (f is Quadrato q && q.testQuadrato())
                {
                    Console.WriteLine("La figura è un Quadrato di:");
                    Console.WriteLine("Area " + q.calcArea());
                    Console.WriteLine("Perimetro " + q.calcPerimetro());
                }
                else if (f is Rettangolo r && r.testRettangolo())
                {
                    Console.WriteLine("La figura è un Rettangolo di:");
                    Console.WriteLine("Area " + r.calcArea());
                    Console.WriteLine("Perimetro " + r.calcPerimetro());
                }
                else
                {
                    Console.WriteLine("La figura è un quadrilatero generico!");
                }
            }
        }

        //_______METODI DI LETTURA_______

        public string leggiStringa(string msg)
        {
            Console.WriteLine(msg);
            string str = Console.ReadLine();
            return str;
        }

        public int leggiIntero(string msg)
        {
            int num = 0;
            bool repeat = false;
            Console.WriteLine(msg);
            do
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());

                    if (num > 0)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Valore non accettabile!");
                        repeat = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Scelta non valida!");
                    repeat = true;
                }
            } while (repeat);

            return num;
        }

        public Punto setCoord(string msg)
        {
            Punto P = new Punto();
            bool repeat = false;
            Console.WriteLine(msg);
            do
            {
                try
                {
                    Console.WriteLine("Scegli coordinata X:");
                    P.X = int.Parse(Console.ReadLine());
                    Console.WriteLine("Scegli coordinata Y:");
                    P.Y = int.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Scelta non valida!");
                    repeat = true;
                }
            } while (repeat);

            return P;
        }
    }
}
