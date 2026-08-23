using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace _100_Prisoners_Rosetta_Code
{
    //Finished on August/20/2026
    
    /*https://rosettacode.org/wiki/100_prisoners
     * The Problem
100 prisoners are individually numbered 1 to 100
A room having a cupboard of 100 opaque drawers numbered 1 to 100, that cannot be seen from outside.
Cards numbered 1 to 100 are placed randomly, one to a drawer, and the drawers all closed; at the start.
Prisoners start outside the room
They can decide some strategy before any enter the room.
Prisoners enter the room one by one, can open a drawer, inspect the card number in the drawer, then close the drawer.
A prisoner can open no more than 50 drawers.
A prisoner tries to find his own number.
A prisoner finding his own number is then held apart from the others.
If all 100 prisoners find their own numbers then they will all be pardoned. If any don't then all sentences stand.

The task
1. Simulate several thousand instances of the game where the prisoners randomly open drawers
2. Simulate several thousand instances of the game where the prisoners use the optimal strategy mentioned in the Wikipedia article, of:
First opening the drawer whose outside number is his prisoner number.
If the card within has his number then he succeeds otherwise he opens the drawer with the same number as that of the revealed card. (until he opens his maximum).
3. Show and compare the computed probabilities of success for the two strategies, here, on this page.


     */

    

    internal class Program
    {

        static void Main(string[] args)
        {
            OneHundredPrisoners prisoners = new OneHundredPrisoners();
            prisoners.SimulateFiveThousandRandomTrials();
            prisoners.SimulateFiveThousandOptimalStrategyTrials();
        }

        public class OneHundredPrisoners
         {
            int[] prisoners;
            int[] drawers;
            int[] randomDrawerOrder;

            float singleTrialWinrate;
            float fiveThousandTrialsWinrate;

            public void SimulateFiveThousandOptimalStrategyTrials()
            {
                float wins = 0;
                float losses = 0;

                for (int i = 0; i < 5000; i++)
                {
                    if (simulateOptimalStrategyTrial())
                    {
                        wins++;
                    }
                    else
                    {
                        losses++;
                    }
                }

                Console.WriteLine("5,000 optimal strategy trials have been simulated. There were " + wins + " wins for the prisoners and " + losses + " losses for the prisoners. The prisoners winrate was therefore " + (wins / (wins + losses)));
            }

            public void SimulateFiveThousandRandomTrials()
            {
                float wins = 0;
                float losses = 0;

                for (int i = 0; i < 5000; i++)
                {
                    if (simulateRandomSingleTrial())
                    {
                        wins++;
                    }
                    else
                    {
                        losses++;
                    }
                }

                Console.WriteLine("5,000 random trials have been simulated. There were " + wins + " wins for the prisoners and " + losses + " losses for the prisoners. The prisoners winrate was therefore " + (wins / (wins + losses)));
            }

            public bool simulateOptimalStrategyTrial()
            {
                ShuffleDrawers();

                foreach (int prisoner in prisoners)
                {
                    bool hasPickedOnce = false;
                    int nextPick = 0;

                    for (int i = 0; i < 50; i++)
                    {
                        //Each prisoner starts by opening the drawer with their own number.
                        if (!hasPickedOnce)
                        {
                            nextPick = prisoner - 1;
                            hasPickedOnce = true;
                        }
                        else
                        {
                            nextPick = drawers[nextPick] - 1;
                        }

                        if (prisoner == drawers[nextPick])
                        {
                            if (prisoner == 100)
                            {
                                return true;
                            }
                            break;
                        }
                        if (i == 49)
                        {
                            return false;
                        }
                    }
                }

                return false;
            }

            public bool simulateRandomSingleTrial()
            {
                ShuffleDrawers();

                foreach (int prisoner in prisoners)
                {
                    ShufflePick();
                    for (int i = 0; i < 50; i++)
                    {
                        if (prisoner == drawers[randomDrawerOrder[i]-1])
                        {
                            if (prisoner == 100)
                            {
                                return true;
                            }
                            break;
                        }
                        if (i == 49)
                        {
                            return false;
                        }
                        
                    }
                }
                //The line below should never run, but I had to include it just to satisfy the compiler because it can't verify that all code paths return a value and apparently this is extremely normal.
                return false;
            }
            public void ShuffleDrawers()
            {
                drawers = MakeShuffledArray();
            }

            public void ShufflePick()
            {
                randomDrawerOrder = MakeShuffledArray();
            }

            public OneHundredPrisoners()
            {
                prisoners = fillInPrisoners();//Prisoners does not need to be an array, it literally is just an index 1-100. Keep in mind that drawers will actually need a shuffled array because the values are the cards.
            }

            int[] fillInPrisoners()
            {
                int[] array = new int[100];

                for (int i = 0; i < 100; i++)
                {
                    array[i] = i + 1;
                }

                return array;
            }

            public int[] MakeShuffledArray()
            {
            /*Fisher–Yates Shuffle
            https://bost.ocks.org/mike/shuffle/
            This means we can do the entire shuffle in-place, without any extra space! We use the back of the array to store the shuffled elements, and the front of the array to store the remaining elements. We don’t care about the order of the remaining elements as long as we sample uniformly when picking!
 */
                int[] array = fillInPrisoners();
                int valueToMoveToBack;
                int valueToMoveToFront;
                int randomNumber;

                for (int i = 0; i < 100; i++)
                {
                    //Pick a random element in the array.
                    randomNumber = Random.Shared.Next(0, 100 - i);
                    valueToMoveToBack = array[randomNumber];
                    valueToMoveToFront = array[100 - i - 1];
                    //Move that random element to the back.
                    array[100 - i - 1] = valueToMoveToBack;
                    array[randomNumber] = valueToMoveToFront;

                    /* Here's what the rest of the method does...

                    //Shrink the size of the array of which elements you can now pick from.

                    //Pick a new random element.

                    //Move that element to the back -1 and so on etc.

                    //Ends when there is only 1 element left in the array to pick from.
                    */

                }
                return array;
            }

           public void WriteArray(int[] array)
            {
                for (int i = 0;  i < 100; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
         
         }
    }
}
