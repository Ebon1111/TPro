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
        Config _config;
        Game1  _game; 
        
        public Control()
        {
            _config = new Config();
            _game   = new Game1();

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
            _config.heightTerrain = (int)terrainHeight.Value;
            _config.widthTerrain  = (int)terrainWidth.Value;

            if (_game.isClosed)
            {
                (_game = new Game1()).terrain = new Terrain(_game, _config);
                 _game.Run();
            }
                
            _game.terrain.Dispose();
            _game.terrain = new Terrain(_game, _config);
        }
    }
}