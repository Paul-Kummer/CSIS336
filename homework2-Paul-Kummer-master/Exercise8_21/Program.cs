using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8_21
{
    class Program
    {
        static void Main()
        {
            // Declare Variables
            var graph = new Graph();
            var turtle = new Turtle("Paul");          
            int issuedCommand, startX, startY;
            string turtleName;
            
            // Heading for the program and what it does
            Console.WriteLine("\t[ WELCOME TO TURTLE GRAPHICS MANIPULATOR ]" +
                            "\n\n*Control the turtles movements by issueing it a command from the command bar" +
                            "\n*When you are done drawing enter the number NINE (9)\n");

            // User provides properties for their turtle
            Console.Write("What is your turtles name: ");
            turtleName = Console.ReadLine();

            Console.Write("\nWhat X Coordinate Should your turtle Start (0-19): ");
            while(! int.TryParse(Console.ReadLine(), out startX) || startX < 0 || startX > 19)
            {
                Console.WriteLine("\t! Invalid Entry !");
                Console.Write("Enter Number: ");
            }
         
            Console.Write("\nWhat Y Coordinate Should your turtle Start (0-19): ");
            while (!int.TryParse(Console.ReadLine(), out startY) || startY < 0 || startY > 19)
            {
                Console.WriteLine("\t! Invalid Entry !");
                Console.Write("Enter Number: ");
            }


            // Give the turtle user selected values
            turtle.Name = turtleName;
            turtle.XPos = startX;
            turtle.YPos = startY;

            // clear the console
            Console.Clear();

            // place the turtle on the floor
            turtle.Place(graph);

            // Show the user the graph with turtle as well as command they can execute until 9 is entered
            do
            {
                if (graph.GraphOn)
                {
                    Console.WriteLine(graph.Display());
                }
                
                // Tell the user the current status of the turtle
                Console.WriteLine($"\n--- ({turtle.Name} is facing {turtle.Direction}), " +
                                    $"(Pen active: {turtle.PenDown}), " +
                                    $"(Eraser active: {turtle.EraserDown}) ---\n");

                // Show possible commands
                Console.WriteLine("\t\t[ ---COMMANDS--- ]\n" +
                                    "(0:Toggle Eraser) " +
                                    "(1 or 2:Toggle Pen) " +
                                    "(3:Turn Right) " +
                                    "(4:Turn Left) " +
                                    "(5:Move Spaces) " +
                                    "(6:Toggle Display) " +
                                    "(9:Finished)");

                Console.Write("\n\tWhat Command Would You Like To Issue: ");

                while(! int.TryParse(Console.ReadLine(), out issuedCommand) 
                    || issuedCommand < 0 
                    || (issuedCommand > 6 && issuedCommand != 9))
                {
                    Console.WriteLine("\t! Please Enter a Valid Command !");
                }

                // Use method to determine what to do with the turtle
                ExecuteCommand(issuedCommand, graph, turtle);

                // clear the console to update what the user did
                Console.Clear();
            } while (issuedCommand != 9);
        }

        // executes commands on the turtle or graph
        static void ExecuteCommand(int command, Graph tmpG,  Turtle tmpT)
        {
            switch(command)
            {
                case 0: // eraser
                    tmpT.ToggleEraser();
                    break;

                case 1: // toggle pen 
                case 2: // toggle pen, the book wanted 2 to toggle pen too
                    tmpT.TogglePen();
                    break;

                case 3: // turn right
                    tmpT.Turn(3);
                    break;

                case 4: // turn left
                    tmpT.Turn(4);
                    break;

                case 5: // move, I didn't want to slice the string so I asked for another input
                    int tmp;

                    Console.Write("\tHow Many Spaces: ");

                    while (! int.TryParse(Console.ReadLine(), out tmp) || tmp < 0)
                    {
                        Console.Write("( *** INVALID *** )  Enter a Number: ");
                    }

                    tmpT.Move(tmp, tmpG);
                    break;

                case 6: // hides the graph
                    tmpG.ToggleGraph();
                    break;

                default:
                    break;
            }
        }
    }
}
