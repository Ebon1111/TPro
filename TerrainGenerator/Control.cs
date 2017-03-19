using System;
using System.Drawing;
using System.Windows.Forms;

namespace TerrainGenerator
{
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
                // access values directly!
                //_game.terrain = new Terrain(   config here   ); // update with form numbers -> terrain struct 'config' as param?
            }
            catch
            {
                (_game = new Game1()).Run(); // failed to update! Game window was closed -> run new with settings
            }
        }
    }
}