using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork_4
{
    public static class Path
    {
        public const string fileToRead = @"F:\1 С #\IT ACADEMIA\sample.txt";
        public const string fileToWriteSentenses = @"F:\1 С #\IT ACADEMIA\sampleWriteSentences.txt";
        public const string fileToWriteWords = @"F:\1 С #\IT ACADEMIA\sampleWriteWords.txt";
        public const string fileToPunctuation = @"F:\1 С #\IT ACADEMIA\sampleWritePunctuation.txt";
        public const string fileOfWordsInAlphabeticalOrder = @"F:\1 С #\IT ACADEMIA\sampleWriteWordsInAlphabeticalOrder.txt";
        public const string fileForTheMost = @"F:\1 С #\IT ACADEMIA\sampleWriteTheMost.txt";
    }

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

    class Program
    {
        static async Task Main(string[] args)
        {
            string text = FileWorker.ReadFromFileToString(Path.fileToRead);
            
            //предложения
            var sentencesOfText = GetSentencesFromSrting(text);
            var countOfSentences = sentencesOfText.Count;
            Console.WriteLine($"The number of sentences: {countOfSentences}.");
            FileWorker.WriteStringListToFile(Path.fileToWriteSentenses, sentencesOfText);
            
            //слова
            var wordsOfText = GetWordsFromSrting(text);
            var countOfWords = wordsOfText.Count;                       
            Console.WriteLine($"The number of words: {countOfWords}.");
            FileWorker.WriteStringListToFile(Path.fileToWriteWords, wordsOfText);

            //знаки препинания
            var punctuationOfText = GetPunctuationFromSrting(text);
            var countOfPunctuation = punctuationOfText.Count;
            Console.WriteLine($"The number of punctuations: {countOfPunctuation}.");
            FileWorker.WriteStringListToFile(Path.fileToPunctuation, punctuationOfText);

            // Самое длинное предложение по количеству символов            
            List<string> listOfTheMost = new List<string>();
            List<int> listOfLenghtOfSentensesBySymbols = new List<int>();

            foreach (var item in sentencesOfText)
            {
                var lenghtOfSentence = item.Length;
                listOfLenghtOfSentensesBySymbols.Add(lenghtOfSentence);                 
            }

            var maxLenghtOfSentence = listOfLenghtOfSentensesBySymbols.Max();
            var indexOfMaxLenghtOfSentence = listOfLenghtOfSentensesBySymbols.IndexOf(maxLenghtOfSentence);
                        
            listOfTheMost.Add("The longest sentence:\n"+ sentencesOfText[indexOfMaxLenghtOfSentence]);
            
            // Самое короткое предложение по количеству слов
            List<int> listOfLenghtOfSentensesByWords = new List<int>();

            foreach (var item in sentencesOfText)
            {
                var words = item.Split(' ');                
                var CountOfWordOfSentences = words.Length;
                listOfLenghtOfSentensesByWords.Add(CountOfWordOfSentences);
            }

            var minLenghtOfSentence = listOfLenghtOfSentensesByWords.Min();
            var indexOfMinLenghtOfSentence = listOfLenghtOfSentensesByWords.IndexOf(minLenghtOfSentence);

            listOfTheMost.Add("\nThe shortest sentence:" + sentencesOfText[indexOfMinLenghtOfSentence]);

            // наиболее встречающаяся БУКВА 
            var letters = text.Where(symbol => char.IsLetter(symbol)).Distinct().ToList();

            var lettersAll = text.Where(symbol => char.IsLetter(symbol)).ToList();
            Dictionary<char, int> result = new Dictionary<char, int>();
            lettersAll.Sort();
            for (int i = 0; i < letters.Count(); i++)
            {
                int firstIndex = lettersAll.IndexOf(letters[i]);
                int lastIndex = lettersAll.LastIndexOf(letters[i]);
                int indexNumber = lastIndex - firstIndex + 1;

                result.Add(letters[i], indexNumber);
            }

            var countOfLetter = result.Values.Max();
            var letter = result.FirstOrDefault(x => x.Value == countOfLetter).Key;
            
            listOfTheMost.Add($"\nThe most common letter: {letter}. Number: {countOfLetter}");

            FileWorker.WriteStringListToFile(Path.fileForTheMost, listOfTheMost);

            //Слова в алфавитном порядке
            wordsOfText.Sort();
            Dictionary<string, int> resultOfAlfabet = new Dictionary<string, int>();

            var uniqueWord = wordsOfText.Distinct().ToList();
            for (int i = 0; i < uniqueWord.Count(); i++)
            {
                int firstIndex = wordsOfText.IndexOf(uniqueWord[i]);
                int lastIndex = wordsOfText.LastIndexOf(uniqueWord[i]);
                int indexNumber = lastIndex - firstIndex + 1;

                resultOfAlfabet.Add(uniqueWord[i], indexNumber);
            }
            FileWorker.WriteDictionaryToFile(Path.fileOfWordsInAlphabeticalOrder, resultOfAlfabet);
        }

        //ПРЕДЛОЖЕНИЯ
        static List<string> GetSentencesFromSrting(string text)
        {
            List<string> output = new List<string>();
            
            var myString = Regex.Replace(text.ToString(), @"\s+", " ");// замена нескольких пробелов одним                          
            myString = myString.Trim(); // удаление пробелов в начале и конце               
            char[] separators = new char[] { '!', '.', '?' };                        
            var sentences = myString.Split(separators);

            // из массива строк удаляем нулевые, пробельные и null элементы; сохраняем в лист                     
            var sentencesList = sentences.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();

            foreach (var item in sentencesList)
            {
                output.Add(DeleteSomeElements(item));
            } 
            
            return output;             
        }

        static string DeleteSomeElements(string sentences)
        {
            return sentences.Trim('"', ' ', '\'').Replace("\"", "");            
        }

        //СЛОВА
        static List<string> GetWordsFromSrting(string text)
        {
            List<string> listOfWorlds = new List<string>();

            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var list = text.Split().Select(x => x.Trim(punctuation)).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            var regex = new Regex(@"^([a-z,A-Z])");

            for (int i = 0; i < list.Count; i++)
            {
                if (regex.IsMatch(list[i]))
                {
                    listOfWorlds.Add(list[i]);
                }
            }
            return listOfWorlds;
        }

        //ЗНАКИ ПРЕПИНАНИЯ
        static List<string> GetPunctuationFromSrting(string text)
        {
            return text.Where(Char.IsPunctuation).Select(x => x.ToString()).ToList();
        }
    }
}
