using System;
using System.Collections.Generic;
using System.Text;

namespace Brickwork
{
    //Base class to hold the data
    public abstract class BaseLayer 
    {
        // Holds board data
        public int[,] layerData { get; set; } 
        public int layerX { get; set; } 
        public int layerY { get; set; } 

        public BaseLayer(int x, int y, int[,] layer)
        {
            this.layerX = x;
            this.layerY = y;
            this.layerData = layer;

            this.Validate();
        }

        // Validates if there is any brick that is 3 long or high or if there are holes
        private void Validate() 
        {
            for (int i = 0; i < layerX; i++)
            {
                for (int j = 0; j < layerY; j++)
                {
                    if (layerData[i, j] == 0)
                    {
                        throw new Exception("Invalid brick placement in the layer");
                    }

                    if (i + 2 < layerX)
                    {
                        if (layerData[i, j] == layerData[i + 2, j] && layerData[i, j] == layerData[i + 1, j])
                        {
                            throw new Exception("Brick to big");
                        }
                    }

                    if (j + 2 < layerY)
                    {
                        if (layerData[i, j] == layerData[i, j + 2] && layerData[i, j] == layerData[i, j + 1])
                        {
                            throw new Exception("Brick to big");
                        }
                    }
                }
            }
        }
    }
}
