using System;
using System.Collections.Generic;

namespace Geometria
{
    class Program
    {
        static void Main(string[] args)
        {
            GestioneIO gio = new GestioneIO();
            CRUD crud = CRUD.Instance;

            while (true)
            {
                int choice = gio.Menu();
                switch (choice)
                {
                    //CREATE
                    case 1:
                        var figura = gio.MaskSceltaFig();
                        switch (figura)
                        {
                            case 1:
                                Quadrato q = new Quadrato();
                                FiguraGeom f = gio.MaskCreazione(q);
                                crud.InserisciFig(f);
                                break;
                            case 2:
                                Rettangolo r = new Rettangolo();
                                f = gio.MaskCreazione(r);
                                crud.InserisciFig(f);
                                break;
                            case 3:
                                Triangolo t = new Triangolo();
                                f = gio.MaskCreazione(t);
                                crud.InserisciFig(f);
                                break;
                            case 4:
                                Cerchio c = new Cerchio();
                                f = gio.MaskCreazione(c);
                                crud.InserisciFig(f);
                                break;
                        }
                        break;

                    //READ
                    case 2:
                        List<FiguraGeom> lista = crud.GetLista();
                        gio.MaskVisualizza(lista);
                        break;
                    
                    //UPDATE
                    case 3:
                        lista = crud.GetLista();
                        if (lista.Count == 0)
                        {
                            GestioneIO.EmptyList();
                            break;
                        }
                        FiguraGeom fToMod = gio.MaskScegliMod(lista);
                        gio.MaskModifica(fToMod);
                        break;
                    
                    //DELETE
                    case 4:
                        lista = crud.GetLista();
                        if (lista.Count == 0)
                        {
                            GestioneIO.EmptyList();
                            break;
                        }
                        FiguraGeom fToDel = gio.MaskScegliMod(lista);
                        if (gio.MaskElimina(fToDel) == "s")
                        {
                            crud.EliminaFig(fToDel);
                        }
                        break;
                    
                    //TEST
                    case 5:
                        lista = crud.GetLista();
                        if (lista.Count == 0)
                        {
                            GestioneIO.EmptyList();
                            break;
                        }
                        FiguraGeom fToTest = gio.MaskScegliMod(lista);
                        gio.MaskTest(fToTest);
                        break;

                    //COMPARE
                    case 6:
                        lista = crud.GetLista();
                        if (lista.Count == 0)
                        {
                            GestioneIO.EmptyList();
                            break;
                        }
                        gio.MaskConfronta(lista);
                        break;

                    //EXIT
                    case 8:
                        Environment.Exit(0);
                        break;
                }

                GestioneIO.Home();

            }
        }
    }
}
