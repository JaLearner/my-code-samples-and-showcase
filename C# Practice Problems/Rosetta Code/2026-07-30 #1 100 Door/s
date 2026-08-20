using System.Security.Cryptography.X509Certificates;

namespace _100_Doors_Rosetta_Code
{
    //Solved on July/25/2026

    /* https://rosettacode.org/wiki/100_doors
There are 100 doors in a row that are all initially closed.

You make 100 passes by the doors.

The first time through, visit every door and toggle the door (if the door is closed, open it; if it is open, close it).

The second time, only visit every 2nd door (door #2, #4, #6, ...), and toggle it.

The third time, visit every 3rd door (door #3, #6, #9, ...), etc, until you only visit the 100th door.

Task
Answer the question: what state are the doors in after the last pass? Which are open, which are closed?
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] doors = new bool[100];
            int nextDoorToOpen = 1;
            int currentDoorOpen = 0;

            while (nextDoorToOpen <= 100)
            {
                while (currentDoorOpen < 100)
                {
                    if (doors[currentDoorOpen] == false)
                    {
                        doors[currentDoorOpen] = true;
                    }
                    else
                    {
                        doors[currentDoorOpen] = false;
                    }
                    currentDoorOpen += nextDoorToOpen;
                }
                nextDoorToOpen++;
                currentDoorOpen = nextDoorToOpen - 1;
            }

            Console.WriteLine(FinalResultofDoors());

            //I already solved the problem, but now I want to generate a bunch of door objects just for reasons of wastefullness and pedagogy (ie. just to practice making a bunch of objects programmatically).

            Door[] mySillyDoorArray = new Door[100];

            for (int i = 0; i < 100; i++ )
            {
                mySillyDoorArray[i] = new Door(i+1);
            }

            string FinalResultofDoors()
            {
                string stringOfDoors = "";

                for (int i = 0; i < 100; i++)
                {
                    if (doors[i] == false)
                    {
                        stringOfDoors += "Door #" + (i + 1) + ": " + "closed\n";
                    }
                    else
                    {
                        stringOfDoors += "Door #" + (i + 1) + ": " + "open\n";
                    }
                }

                return stringOfDoors;
            }

        }
    }
    
    public class Door
    {
        bool isOpen;
        readonly int doorNumber;
        string sillyDoor = "This is a silly useless door. It has nothing to do with solving the problem. I just wanted to make doors afterwards, but Legion keeps making me do more stuff for some reason...";

        public Door(int doorNumber)
        {
            this.doorNumber = doorNumber;
        }

        public void ToggleDoor (bool isOpen)
        {
                isOpen = !isOpen;    
        }

        public string GetDoorNumber ()
        {
            return '#' + doorNumber.ToString();
        }

        public override string ToString()
        {
            return $"Door {GetDoorNumber()}: {(isOpen ? "Open" : "Closed")}";
        }
    }

}
