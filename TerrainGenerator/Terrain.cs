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
    /// </summary>
    public class Terrain : GameComponent
    {
        VertexPositionColor[] vertices;

        int[] indices;

        float[,] heightData;
        int terrainWidth;
        int terrainHeight;

        string type = null;

        List<Color> colours = new List<Color>();
        List<Color> seaColour = new List<Color>();

        /// <summary>
        /// Terrain Constructor
        /// </summary>
        /// <param name="game">Current Game</param>
        /// <param name="terrainWidth">Width for Terrain</param>
        /// <param name="terrainHeight">Height for Terrain</param>
        public Terrain(Game game, int terrainWidth, int terrainHeight)
            : base(game)
        {
            this.terrainWidth = terrainWidth;
            this.terrainHeight = terrainHeight;

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

            LoadHeightData();
            SetUpVertices();
            SetUpIndices();
        }

        public Terrain(Game game, Config config, string type)
            : base(game)
        {
            terrainHeight = config.TerrainHeight / 2;
            terrainWidth = config.TerrainWidth / 2;
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
            //CreateColour();
            vertices = new VertexPositionColor[terrainWidth * terrainHeight];
            // float hOffset = 0f;
            //float xOffset = 0f;
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, heightData[x, y], -y);

                    //vertices[x + y * terrainWidth].Color = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));

                    //vertices[x + y * terrainWidth].Color = colours[counter];

                    vertices[x + y * terrainWidth].Color = getSingleColor(heightData[x,y]);
                    //if (counter < (colours.Count - 1))
                    //    counter++;
                    //else
                    //    counter = 0;
                }
                //xOffset += 0.2f;
                // hOffset += 0.2f;
            }
        }

        private Color getSingleColor(float y)
        {
            if (y < 1.3f)
            {
                return new Color(139, 69, 19);
            }
            else if (y < 1.5f)
            {
                return new Color(0, 100, 0);
            }
            else if(y < 1.8f){
                return new Color(34, 139, 34);

            }
            else if(y < 2.2f)
            {
                return new Color(50, 205, 50);
            }
            else return new Color(255, 255, 255);
        }

        private void SetUpSeaVertices()
        {
            //Random rng = new Random();
            int counter = 0;
            GenerateSeaColour();
            vertices = new VertexPositionColor[terrainWidth * terrainHeight];
            // float hOffset = 0f;
            // float xOffset = 0f;
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, 0.8f, -y);

                    //vertices[x + y * terrainWidth].Color = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));

                    vertices[x + y * terrainWidth].Color = seaColour[counter];

                    if (counter < (colours.Count - 1))
                        counter++;
                    else
                        counter = 0;
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
            indices = new int[(terrainWidth - 1) * (terrainHeight - 1) * 6];
            int counter = 0;
            for (int y = 0; y < terrainHeight - 1; y++)
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
            heightData = new float[terrainWidth, terrainHeight];
            float fOff = 0.2f;
            float hOff = 0.02f;
            float frequency = 3.0f / (float)terrainWidth + fOff;
            float[,] noises = Noise.Calc2D(terrainWidth, terrainHeight, frequency);
            for (int i = 0; i < terrainHeight; i++)
            {
                //float[] noises = Noise.Calc1D(terrainWidth, frequency);
                for (int j = 0; j < terrainWidth; j++)
                {
                   heightData[j, i] = noises[j,i]/100 + hOff;
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
                hOff += 0.01f;
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
            // Yellow Test Set
            int r = 255;
            int g = 247;
            int b = 176;
            while (r != 0)
            {

                colours.Add(new Color(r--, g, b));

                //if (g > 10)
                //    g--;
                //else if (g < 247)
                //    g++;

                //if (b > 0)
                //    b--;
                //else if (b < 176)
                //    b++;

            }

            // Green Test Set
            //int r = 128;
            //int g = 253;
            //int b = 114;
            //while (r != 0)
            //{
            //    colours.Add(new Color(r--, g, b));
            //    if (g > 0)
            //        g--;
            //    if (b > 0)
            //        b--;
            //}
        }

        private void GenerateSeaColour()
        {
            int r = 110;
            int g = 132;
            int b = 255;
            while (g <= 255)
            {
                seaColour.Add(new Color(r, g++, b));
                if (r > 0)
                    r--;
                else
                    r++;
                //if (b < 255)
                //    b--;
            }
            while (g >= 0)
            {
                seaColour.Add(new Color(r, g--, b));
                if (r < 250)
                    r++;
                else
                    r--;
                //if (b < 255)
                //    b--;
            }

        }
    }
}
