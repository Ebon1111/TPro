using System;
using System.Drawing;
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
     ///       Visibility(float)
    /// Output: Generate required world
    /// Author: Franics
    /// Date: 2017/03/17
    /// Updated by: Franics
    /// Date: 2017/03/20
    /// </summary>
    public partial class Control : Form
    {
        Game1 _game; // private member

        public Control()
        {
            InitializeComponent();
        }

        private void btnColour_Click(object sender, EventArgs e)
        {
            using (var d = new ColorDialog())
                if (d.ShowDialog() == DialogResult.OK)
                    (sender as Button).BackColor = d.Color; // some fx 
        }

        private void generate_Click(object sender, EventArgs e)
        {
            try
            {
                _game.Exit();
                // access values directly!
                //_game.terrain = new Terrain(   config here   ); // update with form numbers -> terrain struct 'config' as param?
            }
            catch
            {
                //(_game = new Game1()).Run(); // failed to update! Game window was closed -> run new with settings
            }
            (_game = new Game1()).Run();
        }
    }
}