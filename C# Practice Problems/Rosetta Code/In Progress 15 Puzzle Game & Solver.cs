using System.Diagnostics.Metrics;

namespace Rosetta_Code__4____5_15_Puzzle_Game___Fifteen_Puzzle_Solver
{

    /* #4 Implement the Fifteen Puzzle Game.
    https://rosettacode.org/wiki/15_puzzle_game

    * #5 Your task is to write a program that finds a solution in the fewest moves possible single moves to a random Fifteen Puzzle Game.
      For this task you will be using the following puzzle:

      15 14  1  6
      9 11  4 12
      0 10  7  3
      13  8  5  2


      Solution:

      1  2  3  4
      5  6  7  8
      9 10 11 12

    The output must show the moves' directions, like so: left, left, left, down, right... and so on.
    There are two solutions, of fifty-two moves:
    rrrulddluuuldrurdddrullulurrrddldluurddlulurruldrdrd
    rrruldluuldrurdddluulurrrdlddruldluurddlulurruldrrdd

    Finding either one, or both is an acceptable result.

    Extra credit.
    Solve the following problem:

    0 12  9 13
    15 11 10 14
    3  7  2  5
    4  8  6  1
    https://rosettacode.org/wiki/15_puzzle_solver
*/

    internal class Program
    {
        static void Main(string[] args)
        {
          GameController gameController = new GameController();
          gameController.RunGame();
        }

        public class Board
        {
            int[,] board = new int[4, 4];
            int emptyTilePosX = 0;
            int emptyTilePosY = 0;

            public void SetBoardToDefault()
            {
                int counter = 1;

                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        
                        if (counter != 16)
                        {
                            board[x, y] = counter;
                        }
                        else
                        {
                            board[x, y] = -1;
                            emptyTilePosX = x;
                            emptyTilePosY = y;
                        }

                        counter++;
                    }
                }
            }

            public void DrawBoard()
            {
                //Value inside the board represented as strings from left to right, top to bottom.
                string[] boardValues = new string[16];
                int counter = 0;

                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (board[x, y] < 10 && board[x, y] != -1)
                        {
                            boardValues[counter] = "0" + board[x, y];
                        }
                        else
                        {
                            boardValues[counter] = board[x, y].ToString();
                        }
                        
                        counter++;
                    }
                }

                int newLineCounter = 0;

                foreach (string value in boardValues)
                {
                    if (value != "-1")
                    {
                        Console.Write(@$"{value} ");
                    }
                    else
                    {
                        Console.Write(@$"__ ");
                    }

                    newLineCounter++;

                    if (newLineCounter == 4)
                    {
                        Console.WriteLine("");
                        newLineCounter = 0;
                    }
                }
            }

            public void SlideDown()
            {
                if (emptyTilePosY != 0)
                {
                    board[emptyTilePosX, emptyTilePosY] = board[emptyTilePosX, emptyTilePosY - 1];
                    board[emptyTilePosX, emptyTilePosY - 1] = -1;
                    emptyTilePosY--;
                }
            }

            public void SlideUp()
            {
                if (emptyTilePosY != 3)
                {
                    board[emptyTilePosX, emptyTilePosY] = board[emptyTilePosX, emptyTilePosY + 1];
                    board[emptyTilePosX, emptyTilePosY + 1] = -1;
                    emptyTilePosY++;
                }
            }

            public void SlideLeft()
            {
                if (emptyTilePosX != 0)
                {
                    board[emptyTilePosX, emptyTilePosY] = board[emptyTilePosX - 1, emptyTilePosY];
                    board[emptyTilePosX - 1, emptyTilePosY] = -1;
                    emptyTilePosX--;
                }
            }

            /*
* 1234
* 5678
* 9 10 11 12
* 13 14 15 _
*/
            public void SlideRight()
            {
                if (emptyTilePosX != 3)
                {
                    board[emptyTilePosX, emptyTilePosY] = board[emptyTilePosX + 1, emptyTilePosY];
                    board[emptyTilePosX + 1, emptyTilePosY] = -1;
                    emptyTilePosX++;
                }
                
            }
            
        }

        public class GameController
        {
            public void RunGame()
            {
                Board board = new Board();
                board.SetBoardToDefault();
                while (true)
                {
                    Console.Clear();
                    board.DrawBoard();
                    Console.WriteLine();
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();
                    if (key.Key == ConsoleKey.S)
                    {
                        board.SlideDown();
                    }
                    else if (key.Key == ConsoleKey.W)
                    {
                        board.SlideUp();
                    }
                    else if (key.Key == ConsoleKey.A)
                    {
                        board.SlideRight();
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        board.SlideLeft();
                    }

                }
            }
        }

    }
}
