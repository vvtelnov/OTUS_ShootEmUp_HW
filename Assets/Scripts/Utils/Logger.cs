using System;
using System.IO;

namespace Utils
{
    public class Logger
    {
        private readonly string _path;
        
        public Logger(string path, string fileName, string fileExtension = ".txt")
        {
            _path = Path.Combine(path, string.Concat(fileName, fileExtension));
        }
        
        public void WriteHeader(string firstHeader, string secondHeader)
        {
            using var writer = new StreamWriter(File.Open(_path, FileMode.Append));

            writer.WriteLine($"{"",10}{firstHeader,-30} {secondHeader,-30}\n");
        }
        
        public void WriteHeader(string firstHeader, string secondHeader, string thirdHeader)
        {
            using var writer = new StreamWriter(File.Open(_path, FileMode.Append));

            writer.WriteLine($"{"",10}{firstHeader,-30} {secondHeader,-30} {thirdHeader,-30}\n");
        }

        public void AppendStringsToFile(string[] firstColumn, string[] secondColumn)
        {
            if (firstColumn.Length != secondColumn.Length)
            {
                throw new ArgumentException("Logger (AppendStringsToFile): two passed arrays must be equal in size");
            }

            using var writer = new StreamWriter(File.Open(_path, FileMode.Append));
            
            for (int i = 0; i < firstColumn.Length; i++)
            {
                writer.WriteLine($"{"",10}{firstColumn[i],-30} {secondColumn[i],-30}");
            }
            
            writer.WriteLine("\n");
        }

        public void AppendStringsToFile(string firstColumn, string secondColumn, string thirdColumn)
        {
            using var writer = new StreamWriter(File.Open(_path, FileMode.Append));
            
            writer.WriteLine($"{"",10}{firstColumn,-30} {secondColumn,-30} {thirdColumn,-30}");
        }
    }
}