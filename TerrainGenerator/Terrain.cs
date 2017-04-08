using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Simplex;
using System;
using System.Collections.Generic;

namespace TerrainGenerator
{
    /// <summary>
    /// Purpose: Generate Terrain
    /// Input: Width, height, world, and graphic device
    /// Output: Terrain
    /// Author: Franics
    /// Date: 2017/03/09
    /// Updated by: Ebon
    /// Date: 2017/03/20
    /// Source:
    ///     Generating Random Fractal Terrain. 
    ///     Retrieved from http://www.gameprogrammer.com/fractal.html
    /// </summary>
    public class Terrain : GameComponent
    {
        VertexPositionColor[] vertices;
        public float MaxHeight = -999f;

        int[] indices;

        float[,] heightData;
        int terrainWidth;
        int terrainHeight;
        int terrainLength;

        float noiseRange;

        string type = null;

        List<Color> darkGreens = new List<Color>();
        List<Color> colours = new List<Color>();
        List<Color> seaColour = new List<Color>();

        /// <summary>
        /// Terrain Constructor
        /// </summary>
        /// <param name="game">Current Game</param>
        /// <param name="terrainWidth">Width for Terrain</param>
        /// <param name="terrainHeight">Height for Terrain</param>
        public Terrain(Game game, int terrainWidth, int terrainLength, int terrainHeight)
            : base(game)
        {
            this.terrainWidth = terrainWidth;
            this.terrainHeight = terrainHeight;
            this.terrainLength = terrainLength;

            LoadHeightData();
            SetUpVertices();
            SetUpIndices();
        }

        /// <summary>
        /// Using control-box to terrain
        /// </summary>
        /// <param name="game">Current Game</param>
        /// <param name="config">Control Box Values</param>
        public Terrain(Game game, Config config)
            : base(game)
        {
            terrainHeight = config.TerrainHeight;
            terrainWidth = config.TerrainWidth;
            terrainLength = config.TerrainHeight;
            //terrainLength = config.TerrainLength;

            noiseRange = 1.0f;

            LoadHeightData();
            SetUpVertices();
            SetUpIndices();
        }

        public Terrain(Game game, Config config, string type)
            : base(game)
        {
            terrainHeight = config.TerrainHeight ;
            terrainWidth = config.TerrainWidth;
            terrainLength = terrainHeight;
            //terrainLength = config.TerrainLength / 2;
            this.type = type;

            LoadHeightData();
            SetUpSeaVertices();
            SetUpIndices();
        }

        ///<summary>
        ///Generate vertices based on terrainWidth and terrainHeight
        ///</summary>
        private void SetUpVertices()
        {
            //Random rng = new Random();
            //int counter = 0;
            CreateColour();
            Random rnd = new Random();
            vertices = new VertexPositionColor[terrainWidth * terrainLength];
            // float hOffset = 0f;
            //float xOffset = 0f;
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainLength; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, heightData[x, y], -y);

                    //vertices[x + y * terrainWidth].Color = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));

                    //vertices[x + y * terrainWidth].Color = colours[counter];
                    int i = rnd.Next(1, darkGreens.Count);

                    vertices[x + y * terrainWidth].Color = getSingleColor(heightData[x,y],i);
                    //if (counter < (colours.Count - 1))
                    //    counter++;
                    //else
                    //    counter = 0;
                }
                //xOffset += 0.2f;
                // hOffset += 0.2f;
            }
        }

        private Color getSingleColor(float y,int i)
        {
            
            if (y < 1.6f)
            {
                
                return darkGreens[i]; //dark green

            }
            //else if (y < 1.5f)
            //{
            //    return new Color(34, 139, 34); //green
            //}
            else if(y < 2.0f){
                return new Color(50, 205, 50);//light green
            }
            else if(y < 2.4f)
            {
                return new Color(139, 69, 19);//brown
            }
            else return new Color(255, 255, 255);
        }

        private void SetUpSeaVertices()
        {
            //Random rng = new Random();
            int counter = 0;
            GenerateSeaColour();
            vertices = new VertexPositionColor[terrainWidth * terrainLength];
            // float hOffset = 0f;
            // float xOffset = 0f;
            Random rnd = new Random();
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainLength; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, 0.8f, -y);

                    //vertices[x + y * terrainWidth].Color = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
                    int i = rnd.Next(1, seaColour.Count);
                    vertices[x + y * terrainWidth].Color = seaColour[i];

                   
                }
                // xOffset += 0.2f;
                // hOffset += 0.2f;
            }
        }

        /// <summary>
        /// Set up the indices position
        /// </summary>
        private void SetUpIndices()
        {
            indices = new int[(terrainWidth - 1) * (terrainLength - 1) * 6];
            int counter = 0;
            for (int y = 0; y < terrainLength - 1; y++)
            {
                for (int x = 0; x < terrainWidth - 1; x++)
                {
                    int lowerLeft = x + y * terrainWidth;
                    int lowerRight = (x + 1) + y * terrainWidth;
                    int topLeft = x + (y + 1) * terrainWidth;
                    int topRight = (x + 1) + (y + 1) * terrainWidth;

                    indices[counter++] = topLeft;
                    indices[counter++] = lowerRight;
                    indices[counter++] = lowerLeft;

                    indices[counter++] = topLeft;
                    indices[counter++] = topRight;
                    indices[counter++] = lowerRight;
                }
            }
        }

        /// <summary>
        /// Randomly generate vertices position value (Noise)
        /// </summary>
        private void LoadHeightData()
        {
            Random rng = new Random();
            heightData = new float[terrainWidth, terrainLength];
            float fOff = 0.2f;
            float hOff = 0.02f;
            float frequency = noiseRange / (float)terrainWidth + fOff;
            float[,] noises = Noise.Calc2D(terrainWidth, terrainLength, frequency);
            for (int i = 0; i < terrainLength; i++)
            {
                //float[] noises = Noise.Calc1D(terrainWidth, frequency);
                for (int j = 0; j < terrainWidth; j++)
                {
                    heightData[j, i] = noises[j,i]/100 + hOff;
                    if (heightData[j, i] > MaxHeight)
                        MaxHeight = heightData[j, i];
                    //heightData[j, i] = new Func<float>(() =>
                    //{
                    //    double mantissa = (rng.NextDouble());
                    //    double exponent = Math.Pow(2.0, rng.Next(0, 3));

                    //    float result =  (float)(mantissa + exponent + frequency);
                    //    Console.WriteLine(result);
                    //    return result;
                    //})();
                    //heightData[j, i] = (heightData[j, i] + 1) / 2;
                    
                }
                fOff += 0.1f;
               // hOff += 0.01f;
            }
        }

        /// <summary>
        /// Draw terrain
        /// </summary>
        /// <param name="effect">Game Effect</param>
        /// <param name="device">Graphics Device</param>
        public void DrawTerrain(Effect effect, GraphicsDevice device)
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColor.VertexDeclaration);
            }
        }

        /// <summary>
        /// Generate the default colour set
        /// </summary>
        private void CreateColour()
        {
          //  Color mainDGreen = new Color(0, 100, 0);
            int r = 0;
            int g = 50;
            int b = 0;
            while(g<120){
                darkGreens.Add(new Color(r, g, b));
                if(r > (g - 20) && b > (g - 20))
                {
                    r = 0;
                    b = 0;
                    g = g + 5;
                }
                r = r + 5;
                b = b + 5;

            }
            Console.WriteLine("Size of darkGreens List is" + darkGreens.Count);
        }

        private void GenerateSeaColour()
        {
            int r = 0;
            int g = 0;
            int b = 150;

            while (b < 255)
            {
                seaColour.Add(new Color(r, g, b));

                b = b + 5;
                r = r + 5;
                g = g + 5;
            }
            

        }
    }
}
