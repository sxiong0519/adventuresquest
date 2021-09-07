using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("What is your name?");
            string AdventurerName = Console.ReadLine();

            Console.WriteLine("What are the color(s) of your robe?");
            string color = Console.ReadLine();
            List<string> colors = new List<string>();
            colors.Add(color);

            Console.WriteLine("What is the length?");
            int length = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("What is the level of your hat's shininess?");
            int level = Convert.ToInt32(Console.ReadLine());

            //instance of robe
            Robe robe = new Robe();
            Robe.ColorOfTheRobe = colors;
            Robe.Length = length;

            Hat hat = new Hat();
            Hat.ShininessLevel = level;
            
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);
            
            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge multiplyBy = new Challenge("What is 121 * 79?", 9559, 10);

            Challenge tomato = new Challenge(
                "Do you think tomato is a fruit? 1)Yes! 2)No.", 2, 35);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                    1) John
                    2) Paul
                    3) George
                    4) Ringo
                ",
                4, 20
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(AdventurerName, robe, hat);
            theAdventurer.GetDescriptions();
            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                multiplyBy,
                tomato
            };

            Prize prize = new Prize("diamonds");
            

            goOnAnAdventure();

            void goOnAnAdventure()
            {   theAdventurer.ResetSuccessRate();
                var shuffled = challenges.OrderBy(x => Guid.NewGuid()).ToList().Take(5);
                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in shuffled)
                {   
                    Console.WriteLine($"{theAdventurer.Awesomeness}");
                    challenge.RunChallenge(theAdventurer);
                    
                }
                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                Console.WriteLine($"{theAdventurer.Awesomeness} Your prizes are: "); 
                prize.ShowPrize(theAdventurer);
                playAgain();
            }


            void playAgain()
            {
                Console.WriteLine("Would you like to play again? Y/N");
                string playAgain = Console.ReadLine().ToLower();
                if (playAgain == "y" )
                {
                    theAdventurer.DoublePointsPlayAgain();
                    goOnAnAdventure();
                }
                else 
                {
                    Console.WriteLine("Thank you for playing! See ya.");
                }
            }
        }
    }
}


//I think what is to happen is you are Jack and you will go through the challenges.. if you successfully complete the quest
//you will get points which will then be added up in the theAdeventurer.Awesomeness... then at the end if you get at least 100 points 
//total you get "YOU DID IT"... if not then you get Get out of my sight... or I guess you did ok... 