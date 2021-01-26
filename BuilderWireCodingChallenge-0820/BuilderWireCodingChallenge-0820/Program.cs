using ParagraphChecker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderWireCodingChallenge_0820
{
    class Program
    {
        static void Main(string[] args)
        {
            string articlePath = string.Empty;
            string wordPath = string.Empty;

            try
            {
                articlePath = @"C:\Users\CARL\Desktop\BuilderWireCodingChallenge-0820\Input\Article.txt";
                wordPath = @"C:\Users\CARL\Desktop\BuilderWireCodingChallenge-0820\Input\Words.txt";

                Console.Write("Enter article path: ");
                //articlePath = Console.ReadLine();

                Console.Write("Enter words path: ");
                //wordPath = Console.ReadLine();

                Console.WriteLine("Processing...");
                
                //Read Article and Words
                ProcessFile pf = new ProcessFile();
                string paragraphText = pf.ReadFile(articlePath);
                string wordsText = pf.ReadFile(wordPath);

                //Parse paragraph
                Paragraph paragraph = new Paragraph();
                string output = paragraph.Parse(paragraphText, wordsText);

                //Write output file
                string fileName = string.Format("{0}\\{1}", Path.GetDirectoryName(articlePath),"OUTPUT.txt"); 
                pf.WriteFile(fileName, output);

                Console.WriteLine("Done.");

                //List of invalid words
                if (paragraph.InvalidWords.Count > 0)
                {
                    string invalidWords = string.Empty;
                    Console.WriteLine("Invalid word(s):");

                    foreach (string word in paragraph.InvalidWords)
                    {
                        invalidWords += string.Format("* {0}\n", word);
                    }
                    Console.WriteLine(invalidWords);

                    //Export Invalid words
                    Console.Write("Do you want to export invalid words? (Y/N) : ");
                    string isExport = Console.ReadLine();

                    if (isExport == "Y")
                    {
                        string fileNameInvalidWord = string.Format("{0}\\{1}", Path.GetDirectoryName(articlePath), "INVALID_WORDS.txt");
                        pf.WriteFile(fileNameInvalidWord, invalidWords);

                        Console.WriteLine("Invalid word has been exported.");
                    }
                }

                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
