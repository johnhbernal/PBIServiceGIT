using System;
using System.IO;

namespace PBIServices.Ldap
{
    public static class Funciones
    {
        public static void Logs(string nombreArchivo, string descripcion)
        {
            try
            {
                var root = Path.Combine(Path.GetTempPath(), "PBIServices", "logs",
                    DateTime.UtcNow.ToString("yyyy"),
                    DateTime.UtcNow.ToString("MM"),
                    DateTime.UtcNow.ToString("dd"));
                Directory.CreateDirectory(root);
                var path = Path.Combine(root, nombreArchivo + ".txt");
                File.AppendAllText(path,
                    DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " >>> " + descripcion + Environment.NewLine);
            }
            catch
            {
                // Never fail the request because of file logging.
            }
        }
    }
}
