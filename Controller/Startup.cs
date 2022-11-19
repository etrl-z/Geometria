using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    class Startup
    {
        public static void Execute(CRUD crud)
        {
            while (true)
            {
                int choice = GestioneIO.Menu();
                switch (choice)
                {
                    //CREATE
                    case 1:
                        var figura = GestioneIO.MaskSceltaFig();
                        switch (figura)
                        {
                            case 1:
                                Quadrato q = new Quadrato();
                                FiguraGeom f = GestioneIO.MaskCreazione(q);
                                crud.InserisciFig(f);
                                break;
                            case 2:
                                Rettangolo r = new Rettangolo();
                                f = GestioneIO.MaskCreazione(r);
                                crud.InserisciFig(f);
                                break;
                            case 3:
                                Triangolo t = new Triangolo();
                                f = GestioneIO.MaskCreazione(t);
                                crud.InserisciFig(f);
                                break;
                            case 4:
                                Cerchio c = new Cerchio();
                                f = GestioneIO.MaskCreazione(c);
                                crud.InserisciFig(f);
                                break;
                        }
                        break;

                    //READ
                    case 2:
                        List<FiguraGeom> lista = crud.GetLista();
                        GestioneIO.MaskVisualizza(lista);
                        break;

                    //UPDATE
                    case 3:
                        lista = crud.GetLista();
                        if (lista.Count == 0)
                        {
                            GestioneIO.EmptyList();
                            break;
                        }
                        FiguraGeom fToMod = GestioneIO.MaskScegliMod(lista);
                        GestioneIO.MaskModifica(fToMod);
                        break;

                    //DELETE
                    case 4:
                        lista = crud.GetLista();
                        if (lista.Count == 0)
                        {
                            GestioneIO.EmptyList();
                            break;
                        }
                        FiguraGeom fToDel = GestioneIO.MaskScegliMod(lista);
                        if (GestioneIO.MaskElimina(fToDel) == "s")
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
                        FiguraGeom fToTest = GestioneIO.MaskScegliMod(lista);
                        GestioneIO.MaskTest(fToTest);
                        break;

                    //COMPARE
                    case 6:
                        lista = crud.GetLista();
                        if (lista.Count == 0)
                        {
                            GestioneIO.EmptyList();
                            break;
                        }
                        GestioneIO.MaskConfronta(lista);
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
