using System;
using System.Collections.Generic;
using System.Text;

namespace Brickwork
{
    public class LayerGenerator : BaseLayer
    {
        // Used to fill the array 
        public int currentNumber { get; private set; } 

        public LayerGenerator(int x, int y, int[,] layer) : base(x, y, layer)
        {
            // Creates 2nd layer of bricks
            this.CreateLayer();

            // Outlines each brick of the 2nd layer and outputs it
            this.OutputOutlinedBricks(); 
        }

        public void OutputOutlinedBricks()
        {
            string[] outputOutlinedBricks;

            // Puts outline on the bricks in the 2nd layer and outputs it
            outputOutlinedBricks = OutlineBricks();
            foreach (string str in outputOutlinedBricks)
            {
                Console.WriteLine(str);
            }
        }

        // Creates 2nd layer of bricks
        public void CreateLayer() 
        {
            int[,] arrayPlaceholder = new int[layerX, layerY];
            currentNumber = 1;

            for (int i = 0; i < layerX - 1; i += 2)
            {
                for (int j = 0; j < layerY - 1; j += 2) 
                {
                    // Looks at the previous layer determines the next layer
                    if (layerData[i, j] == layerData[i + 1, j] || layerData[i, j + 1] == layerData[i + 1, j + 1])
                    {
                        arrayPlaceholder[i, j] = currentNumber;
                        arrayPlaceholder[i, j + 1] = currentNumber;
                        currentNumber++;
                        arrayPlaceholder[i + 1, j] = currentNumber;
                        arrayPlaceholder[i + 1, j + 1] = currentNumber;
                        currentNumber++;
                    }
                    else
                    {
                        arrayPlaceholder[i, j] = currentNumber;
                        arrayPlaceholder[i + 1, j] = currentNumber;
                        currentNumber++;
                        arrayPlaceholder[i, j + 1] = currentNumber;
                        arrayPlaceholder[i + 1, j + 1] = currentNumber;
                        currentNumber++;
                    }
                }
            }

            // Assigning the converted array to the main array
            for (int i = 0; i <= layerX - 1; i += 1)
            {
                for (int j = 0; j <= layerY - 1; j += 1)
                {
                    layerData[i, j] = arrayPlaceholder[i, j];
                }
            }
        }

        // Puts an outline on each bricks
        public string[] OutlineBricks()
        {
            // Contains the string that will be outputed 
            string[] outlinedBricks = new string[layerX * 2 + 1];
            outlinedBricks[0] = new string('*', layerY * 2 + 1);

            var TopRow = new StringBuilder();
            var BottomRow = new StringBuilder();

            for (int i = 0; i < layerX; i++)
            {
                TopRow.Append("*");
                BottomRow.Append("*");

                for (int j = 0; j < layerY; j++)
                {
                    TopRow.Append(layerData[i, j].ToString());
                    if (j + 1 < layerY)
                    {
                        if (layerData[i, j] == layerData[i, j + 1])
                        {
                            TopRow.Append(" ");
                        }
                        else
                        {
                            TopRow.Append("*");
                        }
                    }
                    else
                    {
                        TopRow.Append("*");
                    }

                    if (i + 1 < layerX)
                    {
                        if (layerData[i, j] == layerData[i + 1, j])
                        {
                            BottomRow.Append(" ");
                        }
                        else
                        {
                            BottomRow.Append("*");
                        }
                    }
                    else
                    {
                        BottomRow.Append("*");
                    }
                    BottomRow.Append("*");
                }

                outlinedBricks[i * 2 + 1] = TopRow.ToString();
                outlinedBricks[i * 2 + 2] = BottomRow.ToString();
                TopRow.Clear();
                BottomRow.Clear();
            }

            return outlinedBricks;
        }
    }
}
