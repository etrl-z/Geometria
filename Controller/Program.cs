using System;
using System.Collections.Generic;

namespace Geometria
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD crud = CRUD.Instance;
            Startup.Execute(crud);
        }
    }
}
