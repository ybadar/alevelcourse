using System;

namespace guessing
{
    class Program
    {

        static void Main(string[] args)
        {
            string wordguessed = ("");
            wordguessed = getplayer1guess();
            takefiveguesses(wordguessed);
            guesstheword(wordguessed);
        }

        static string getplayer1guess()
        {
            string word = ("");
            do
            {
                Console.WriteLine("Player 1 enter a 4 letter word");
                word = Console.ReadLine();
            }
            while (word.Length > 4);
            {
                return word;
            }
        }
        static void takefiveguesses(string word)
        {
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine("Player 2 guess a letter in that word");
                char Letter = Console.ReadLine()[0];
                string wordguessed = (word);
                bool letterguessed = word.Contains(Letter);
                if (letterguessed == true)
                {
                    Console.WriteLine("That letter is in the word, Well done!");
                    int score = 0;
                    score++;
                    Console.WriteLine("your score is :"+ score);
                }
                else
                {
                    Console.WriteLine(" That letter is not in the word");
                }
            }
        }
        static void guesstheword(string word)
        {

        }
    }
}
