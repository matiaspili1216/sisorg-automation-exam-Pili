using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisorg_automation_exam_MP._00.Tools
{
    public static class UtilsMethods
    {
        /// <summary>
        /// Método que valida si un archivo fue descargado en una carpeta específica. Esperandp hasta 30 segundos.
        /// </summary>
        /// <param name="pathFolder">Carpeta de descarga</param>
        /// <param name="searchPattern">Criterio de búsqueda</param>
        /// <param name="fileName">Nombre del archivo encontrado</param>
        /// param name="deleteFile">Indica si se debe eliminar el archivo encontrado</param>
        /// <returns></returns>
        public static bool ValidateDownloadFile(string pathFolder, string searchPattern, out string fileName, bool deleteFile = true)
        {
            Stopwatch Time = new Stopwatch();
            DirectoryInfo DirectoryInWhichToSearch = new DirectoryInfo(pathFolder);

            Time.Start();
            while (Time.Elapsed < TimeSpan.FromSeconds(30) && Time.IsRunning)
            {
                try
                {
                    FileInfo[] filesInDir = DirectoryInWhichToSearch.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
                    if (filesInDir.Length > 0)
                    {
                        fileName = filesInDir[0].Name;

                        return !deleteFile || DeleteFile(filesInDir[0], out _);
                    }
                }
                catch (Exception)
                {
                    fileName = "";
                    return false;
                }
            }
            Time.Stop();
            fileName = "";
            return false;
        }

        private static bool DeleteFile(FileInfo fileToDelete, out string detail)
        {
            try
            {
                if (!fileToDelete.Exists) { detail = "No existe el archivo a eliminar"; return true; }
                else if (fileToDelete.IsReadOnly) { detail = "El archivo a eliminar es de Solo lectura"; return true; }

                fileToDelete.Delete();

                detail = "";
                return true;
            }
            catch (Exception e)
            {
                detail = e.Message;
                return false;
            }
        }
    }
}
