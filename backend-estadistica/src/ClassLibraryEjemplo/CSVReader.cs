using System;
using System.Collections.Generic;
using System.IO;

namespace TuProyecto.Biblioteca
{
    public class CSVReader
    {
        public IEnumerable<string[]> LeerArchivoCSV(string filePath)
        {
            var resultados = new List<string[]>();

            try
            {
                // Verificar si el archivo existe
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("El archivo no existe.");
                }

                // Leer el archivo CSV
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        // Añadir los valores leídos a la lista de resultados
                        resultados.Add(values);
                    }
                }
            }
            catch (IOException ioEx)
            {
                throw new Exception($"Error de E/S: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }

            return resultados;
        }
    }
}
