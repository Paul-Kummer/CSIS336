using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_36
{
    class Program
    {
        //             Hanoi Tower
        // Stack of disks in descending size must be moved from 
        // peg 1 to peg 3 and remain in descending order.
        //   -Only one disk can move at a time
        //   -Disk must be on top to move
        //   -Disk can only be placed on nothing or larger Disk

        enum Status
        {
            Exit, Continue, Complete
        }

        static void Main(string[] args)
        {
            Status Tower = Status.Continue;
            Peg startPeg = new Peg(true, false, false);
            Peg stagePeg = new Peg(false, false, true);
            Peg finishPeg = new Peg(false, true, false);
            int diskCount = 0, tmp; 
            var pegOptions = new List<int> { 0, 1, 2, 3 };
            var diskList = new List<Disk> { };
    


            Console.WriteLine("\t[   Tower of Hanoi Sover   ]\n");
            Console.WriteLine("Stack of disks in descending size must be moved from a peg another and remain in descending order." +
                "\n\t-Only one disk can move at a time" +
                "\n\t-Disks must be on top to move" +
                "\n\t-Disks can only be placed on nothing or larger Disk" +
                "\n\t-There are only Three Pegs\n");
            do
            {
                SetStartPeg();
                if (Tower == Status.Exit) // exits program if zero entered
                {
                    continue;
                }

                SetFinishPeg();
                if (Tower == Status.Exit) // exits program if zero entered
                {
                    continue;
                }

                SetStagingPeg();

                CreateDisks();
                if (Tower == Status.Exit) // exits program if zero entered
                {
                    continue;
                }

                SolveTower(diskCount, startPeg, finishPeg, stagePeg);

                Console.Write("\nSolve Another Tower (Y for yes, other keys exit):\n\n");
                Tower = Console.ReadKey(true).Key == ConsoleKey.Y ? Status.Continue : Status.Exit;
                pegOptions.Add(1);
                pegOptions.Add(2);
                pegOptions.Add(3);

                
            } while (Tower != Status.Exit && Tower == Status.Continue);

            void CreateDisks()
            {
                do 
                {
                    Console.Write("\n\t(Enter Positive Integer; 0 Exits), How Many Disks: ");
                } while (!int.TryParse(Console.ReadLine(), out diskCount) || diskCount < 0);

                Tower = diskCount == 0 ? Status.Exit : Status.Continue;
                if (diskCount != 0)
                {
                    startPeg.Height = diskCount;
                    stagePeg.Height = diskCount;
                    finishPeg.Height = diskCount;

                    for(int diskRange = diskCount; diskRange > 0;)
                    {
                        diskList.Add(new Disk(diskRange));
                        startPeg.TopDisk = diskList.Last();
                        --diskRange;
                    }               
                }
            }

            void SetStartPeg()
            {
                do
                {
                    Console.Write("\n\t([1,2,3]; 0 Exits), What is the Starting peg: ");
                } while (!int.TryParse(Console.ReadLine(), out tmp) || !pegOptions.Contains(tmp));

                if (tmp != 0)
                {
                    startPeg.PegPos = tmp;
                    startPeg.Name = $"Start Peg: {tmp}";
                    pegOptions.Remove(tmp);
                }

                else
                {
                    Tower = Status.Exit;
                }
            }

            void SetFinishPeg()
            {
                do
                {
                    Console.Write("\n\t([1,2,3]; 0 Exits), What is the Finishing peg: ");
                } while (!int.TryParse(Console.ReadLine(), out tmp) || !pegOptions.Contains(tmp));

                if(tmp != 0)
                {
                    finishPeg.PegPos = tmp;
                    finishPeg.Name = $"Finish Peg: {tmp}";
                    pegOptions.Remove(tmp);
                }

                else
                {
                    Tower = Status.Exit;
                }
            }

            void SetStagingPeg()
            {
                tmp = pegOptions.Max();
                stagePeg.PegPos = tmp;
                stagePeg.Name = $"Stage Peg: {tmp}";
                pegOptions.Remove(tmp);              
            }

            void SolveTower(int numOfDisks, Peg start, Peg finish, Peg stage)
            {
                if (numOfDisks > 0)
                {
                    SolveTower(numOfDisks - 1, start, stage, finish);
                    Disk movingDisk = start.RemoveDisk(start.TopDisk);
                    finish.TopDisk = movingDisk;
                    if (movingDisk != null)
                    {
                        string diskMoved = $"Disk {movingDisk.Size} moved from ({start.Name}) to ({finish.Name})";
                        string diagram = $"[ {start.PegPos} ------> {finish.PegPos} ]";
                        Console.WriteLine($"{diagram,13} | {diskMoved,50}");
                    }                   
                    SolveTower(numOfDisks - 1, stage, finish, start);
                    Tower = Status.Complete;
                }               
            }
        }
    }
}
