using System;
using System.IO;

namespace PBIServices.Ldap
{
    public class Funciones
    {
        public Funciones()
        {
        }

        public static void Logs(string nombre_archivo, string descripcion)
        {
            //string directorio = AppDomain.CurrentDomain.BaseDirectory + "logs/" +
            string directorio = "C:/Errores/" + "logs/" +
            DateTime.Now.Year.ToString() + "/" +
            DateTime.Now.Month.ToString() + "/" +
            DateTime.Now.Day.ToString();

            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            StreamWriter mi_archivo = new StreamWriter(directorio + "/" + nombre_archivo + ".txt", true);

            string cadena = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " >>> " + descripcion;

            mi_archivo.WriteLine(cadena);
            mi_archivo.Close();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}