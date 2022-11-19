using System;

namespace Geometria
{
    class Program
    {
        static void Main(string[] args)
        {
            GestioneIO gio = new GestioneIO();
            CRUD crud = CRUD.Instance;

            bool repeat = true;
            do
            {
                switch (gio.menu())
                {
                    case 1:
                        switch (gio.maskSceltaFig())
                        {
                            case 1:
                                Quadrato q = new Quadrato();
                                crud.inserisciFig(gio.maskCreazione(q));
                                break;
                            case 2:
                                Rettangolo r = new Rettangolo();
                                crud.inserisciFig(gio.maskCreazione(r));
                                break;
                            case 3:
                                Triangolo t = new Triangolo();
                                crud.inserisciFig(gio.maskCreazione(t));
                                break;
                            case 4:
                                Cerchio c = new Cerchio();
                                crud.inserisciFig(gio.maskCreazione(c));
                                break;
                        }
                        break;

                    case 2:
                        gio.maskVisualizza(crud.getLista());
                        break;

                    case 3:
                        if (crud.getLista().Count == 0) { gio.error(); break; }
                        gio.maskModifica(gio.maskScegliMod(crud.getLista()));
                        break;

                    case 4:
                        if (crud.getLista().Count == 0) { gio.error(); break; }
                        FiguraGeom del = gio.maskScegliMod(crud.getLista());
                        if (gio.maskElimina(del) == "s") { crud.eliminaFig(del); }
                        break;

                    case 5:
                        if (crud.getLista().Count == 0) { gio.error(); break; }
                        gio.maskTest(gio.maskScegliMod(crud.getLista()));
                        break;

                    case 6:
                        if (crud.getLista().Count == 0) { gio.error(); break; }
                        gio.maskConfronta(crud.getLista());
                        break;

                    case 8:
                        Environment.Exit(0);
                        break;
                }
                gio.home();

            } while (repeat);
        }
    }
}
