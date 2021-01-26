using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParagraphChecker
{
    public class ProcessFile
    {
        public string ReadFile(string path)
        {
            StringBuilder sbOutput = new StringBuilder();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                    sbOutput.AppendLine(line);
            }
            
            return sbOutput.ToString();
        }

        public void WriteFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}
