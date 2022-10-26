using Entity_Movie_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Movie_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieCRUD sc = new MovieCRUD();

            sc.StartProgram();
        }

    }
}