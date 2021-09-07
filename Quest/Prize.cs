using System;

namespace Quest
{
    public class Prize
    {
        //private field
        private string _text { get; set; }
        //constructor
        public Prize (string text)
        {
            _text = text;
        }
        //method
        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness <= 0)
            {
                Console.WriteLine("You suck.");
            }
            else 
            {
                for (int i = 0; i < (adventurer.Awesomeness + 1); i++)
                {
                    Console.WriteLine(_text);
                }
            }
        }
    }
}