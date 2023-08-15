using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActraNationalOtokiti
{
    class BonusPoint
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            List<string> wordList = new List<string> { "Words Here" };
            string[] starterWords = { "ANNEX", "LATEX", "CODEX" };
            List<string> wordsToRemove = new List<string>();

            int guesses = 6;
            string computerGuess;
            bool wonGame = false;
            string[] progress = { "_", "_", "_", "_", "_" };

            for (int i = 0; i < guesses; i++)
            {
                string? userFeedback;
                if (i == 0)
                {
                    computerGuess = starterWords[random.Next(0, starterWords.Length)];
                }
                else
                {
                    computerGuess = wordList[random.Next(0, wordList.Count)];
                }
                Console.WriteLine($"{computerGuess}");
                Console.Write("(_/?/!) ");
                userFeedback = Console.ReadLine();

                if (userFeedback != null && userFeedback.Length == 5)
                {
                    if (userFeedback == "!!!!!")
                    {
                        wonGame = true;
                        break;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (userFeedback[j] == '_')
                        {
                            foreach (string word in wordList)
                            {
                                if (word.Contains(computerGuess[j]))
                                {
                                    wordsToRemove.Add(word);
                                }
                            }
                        }
                        else if (userFeedback[j] == '?')
                        {
                            foreach (string word in wordList)
                            {
                                if (word.Contains(computerGuess[j]))
                                {
                                    if (word[j] == computerGuess[j])
                                    {
                                        wordsToRemove.Add(word);
                                    }
                                    else
                                    {
                                        progress[j] = "?";
                                    }
                                }
                                else
                                {
                                    wordsToRemove.Add(word);
                                }
                            }
                        }
                        else if (userFeedback[j] == '!')
                        {
                            foreach (string word in wordList)
                            {
                                if (word.IndexOf(computerGuess[j]) != j)
                                {
                                    wordsToRemove.Add(word);
                                }
                                else
                                {
                                    progress[j] = "!";
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!");
                        }
                        int wordRemoveCount = wordsToRemove.Count;
                        for (int k = 0; k < wordRemoveCount; k++)
                        {
                            try
                            {
                                wordList.Remove(wordsToRemove[k]);
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Guess!");
                }
                wordsToRemove.Clear();
            }
            if (wonGame)
            {
                Console.WriteLine("I guessed it!");
            }
            else
            {
                Console.WriteLine("I didn't guess it...");
            }
        }
    }
}
