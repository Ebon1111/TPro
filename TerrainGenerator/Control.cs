using System;
using System.Windows.Forms;

namespace TerrainGenerator
{
    /// <summary>
    /// Purpose: Control the values of the world
    /// Input: Terrain Size (int)
    ///        Terrain Noise(float)
    ///        Terrain Base Line Colour(color)
    ///        Screen Resolution(int)
    ///        Camera Speed(float)
    ///        Camera Srating Position(float)
    ///        Visibility(float)
    /// Output: Generate required world
    /// Author: Franics
    /// Date: 2017/03/17
    /// Updated by: Franics
    /// Date: 2017/03/20
    /// </summary>
    public partial class Control : Form
    {
        Config config;
        Game1  game;

        private static int generateCount;

        public Control()
        {
            config = new Config();
            game   = new Game1();

            InitializeComponent();
        }

        /// <summary>
        /// When a colour is selected, change the background colour of colour button
        /// </summary>
        /// <param name="sender">Colour Button</param>
        /// <param name="e">Clicked</param>
        private void btnColour_Click(object sender, EventArgs e)
        {
            using (var d = new ColorDialog())
                if (d.ShowDialog() == DialogResult.OK)
                    (sender as Button).BackColor = d.Color;
        }

        /// <summary>
        /// Create the world when the button is clicked.
        /// If the world doesn't exist, create one
        /// If the world exists, update the terrain object
        /// </summary>
        /// <param name="sender">Generate World Button</param>
        /// <param name="e">Clicked</param>
        private void generate_Click(object sender, EventArgs e)
        {
            config.TerrainHeight = (int)   terrainHeight.Value;
            config.TerrainWidth  = (int)   terrainWidth.Value;
            config.NoiseRange    = (float) terrainNoise.Value;
            config.CameraSpeed   = (float) cameraSpeed.Value;
            config.ViewDistance  = (float) visibility.Value;
            
            if (game.IsClosed)
            {
                game.Dispose();
               (game = new Game1(config)).Controller = this;
                game.Sea = new Terrain(game, config, "Sea");
                game.Run();
            }
            game.GameTerrain.Dispose();
            game.Sea.Dispose();

            game.GameTerrain  = new Terrain(game, config);
            game.Sea          = new Terrain(game, config, "Sea");
            
           (game.CameraObject as Camera).CameraSpeed  = (float) cameraSpeed.Value;
           (game.CameraObject as Camera).ViewDistance = (float) visibility.Value;

            // Easter Egg: Flip the world
            if (++generateCount == 5)
                Game1.isFlipped = true;
        }
    }
}