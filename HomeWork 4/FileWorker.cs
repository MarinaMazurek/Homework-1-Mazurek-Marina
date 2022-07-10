using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork_4
{
    public static class FileWorker
    {
        public static string ReadFromFileToString(string path)
        {
            var text = string.Empty;

            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            return text;
        }

        public static void WriteStringListToFile(string path, List<string> elements)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (var item in elements)
                {
                    writer.WriteLine(item);
                }
                Console.WriteLine($"Data was written to the file \"{path}\".\n");  // указать файл
            }
        }

        public static void WriteDictionaryToFile(string path, Dictionary<string, int> elements)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (var item in elements)
                {
                    writer.WriteLine(item);
                }
                Console.WriteLine($"Data was written to the file \"{path}\".\n");  // указать файл
            }
        }
    }
}
