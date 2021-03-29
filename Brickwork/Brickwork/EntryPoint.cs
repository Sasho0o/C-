using System;

namespace Brickwork
{
    /*
     Assignment 2: Brickwork

    The builders must cover a rectangular area of size M × N (M and N are even numbers)
    with two layers of bricks that are rectangles of size 1 × 2. The first layer of the bricks has
    already been completed. The second layer (in an effort to make the brickwork really
    strong) must be created in a way that no brick in it lies exactly on a brick from the first
    layer. However, it is allowed half of the same brick to lie on the same brick on the second
    layer.
    Create a console app that accepts input parameters for the given layout of the bricks for
    the first layer, determine the possible layout of the second one, or prove that it is
    impossible to create the second layer and print it in the console.
     */

    class EntryPoint
    {
        static void Main(string[] args)
        {
            int gridX;
            int gridY;

            Console.WriteLine("Whats the width and height of the layer you wish to create [X Y] (even numbers 0<x/y<100):");

            // Current line of the user input
            string gridSizeInput = Console.ReadLine();
            gridX = int.Parse(gridSizeInput.Split(" ")[0]);
            gridY = int.Parse(gridSizeInput.Split(" ")[1]);

            // Validates the user input
            Validate(gridX, gridY);

            Console.WriteLine("Fill the layer:");

            // First layer of bricks
            int[,] inputLayer = new int[gridX, gridY];

            // Filling the first layer(array) with input numbers
            for (int i = 0; i < gridX; i++)
            {
                int[] row = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < gridY; j++)
                    inputLayer[i, j] = row[j];
            }
            Console.WriteLine("\nThis is the 2nd layer:");

            // Creates the next layer and puts outlines on each brick
            LayerGenerator secondLayer = new LayerGenerator(gridX, gridY, inputLayer);

            Console.ReadKey();
        }


        // Validates user input for width and height of the layer
        public static void Validate(int gridX, int gridY)
        {
            if (gridX < 2 || gridX > 98 || gridX % 2 == 1 || gridY < 2 || gridY > 98 || gridY % 2 == 1)
            {
                throw new Exception("Invalid X or Y");
            }
        }
    }
}
