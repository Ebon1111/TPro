using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        GraphicsDevice device;

        VertexPositionColor[] vertices;
        public VertexPositionColor[] Vertices
        {
            get
            {
                return vertices;
            }
        }

        int[] indices;
        public int[] Indices
        {
            get
            {
                return indices;
            }
        }

        float[,] heightData;
        int terrainWidth;
        int terrainHeight;

        List<Color> colours = new List<Color>();

        /// <summary>
        /// Terrain Constructor
        /// </summary>
        /// <param name="game">Current Game</param>
        /// <param name="device">Current Graphic Device</param>
        /// <param name="terrainWidth">Width for Terrain</param>
        /// <param name="terrainHeight">Height for Terrain</param>
        public Terrain(Game game, GraphicsDevice device, int terrainWidth, int terrainHeight) 
            : base(game)
        {
            this.device = device;
            this.terrainWidth = terrainWidth;
            this.terrainHeight = terrainHeight;

            LoadHeightData();
            SetUpVertices();
            SetUpIndices();
        }

        ///<summary>
        ///Generate vertices based on terrainWidth and terrainHeight
        ///</summary>
        private void SetUpVertices()
        {
            int counter = 0;
            CreateColour();
            vertices = new VertexPositionColor[terrainWidth * terrainHeight];
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, heightData[x, y], -y);
                    
                    vertices[x + y * terrainWidth].Color = colours[counter];

                    if (counter < (colours.Count - 1))
                        counter++;
                    else
                        counter = 0;
                }
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

            for (int i = 0; i < terrainHeight; i++)
            {
                for (int j = 0; j < terrainWidth; j++)
                {
                    heightData[j, i] = new Func<float>(() =>
                    {
                        double mantissa = (rng.NextDouble());
                        double exponent = Math.Pow(2.0, rng.Next(0, 1));
                        return (float)(mantissa * exponent);
                    })();
                }
            }
        }

        /// <summary>
        /// Generate the default colour set
        /// </summary>
        private void CreateColour()
        {
            int r = 255;
            int g = 252;
            int b = 111;
            while (r != 0)
            {
                colours.Add(new Color(r--, g, b));
                if (g > 0)
                    g--;
                if (b > 255)
                    b--;
                    
            }
        }
    }
}
