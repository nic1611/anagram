using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagrama
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.readArchive();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // ** Pode ser usado esse metodo para verificar cada palavra do anagrama **

        //public bool dictionaryEnglish(string wordToCheck)
        //{
        //    WordDictionary oDict = new WordDictionary();

        //    oDict.DictionaryFile = "en-US.dic";
        //    oDict.Initialize();
        //    Spelling oSpell = new Spelling();

        //    oSpell.Dictionary = oDict;
        //    if (!oSpell.TestWord(wordToCheck))
        //    {
        //        //Word does not exist in dictionary
        //        return false;
        //    }
        //    return true;
        //}

        public void readArchive()
        {
            Console.WriteLine("Informe o caminho do arquivo");
            string caminhoArquivo = Console.ReadLine();

            string[] lines = System.IO.File.ReadAllLines(caminhoArquivo);

            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                anagram(line);
            }
        }

        public void anagram(string letters)
        {
            Random rnd = new Random();
            List<string> datalist = new List<string>();
            List<string> compare = new List<string>();
            datalist.AddRange(letters.Select(c => c.ToString()));
            string result = string.Join("", datalist);
            string possibles = "";
            compare.Add(result);
            int i = 0;
            int j = 0;

            while (i <= 120)
            {
                while (compare.Contains(result))
                {
                    result = string.Join("", datalist.OrderBy(x => rnd.Next()));
                    j++;
                    if (j >= 120)
                        break;
                }
                if (j >= 120)
                    break;
                compare.Add(result);
                possibles += $" {result}";
                i++;

            }

            Console.WriteLine($"\n[{letters}]\n\t -> {possibles}");

        }
    }
}

