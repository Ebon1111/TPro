using System;
using System.Drawing;
using System.Windows.Forms;

namespace TerrainGenerator
{
    public partial class Control : Form
    {
        Game1 _game;

        /* Terrain variables */
        public Color terrainBase   { private set; get; }
        public float terrainNoise  { private set; get; }
        public int   terrainHeight { private set; get; }
        public int   terrainWidth  { private set; get; }

        /* Camera variables */
        public float cameraSpeed { private set; get; }
        
        /* View variables */
        public int   resX       { private set; get; }
        public int   resY       { private set; get; }
        public float visibility { private set; get; }

        public Control()
        {
            InitializeComponent();
            
            // set defaults
            btnBaseColour.BackColor = terrainBase = Color.LightBlue;
        }

        /*  CAMERA  */

        private void cameraSpeed_ValueChanged(object sender, EventArgs e)
        {
            cameraSpeed = (float)(sender as NumericUpDown).Value;
        }

        /*  TERRAIN  */

        private void baseColour_Click(object sender, EventArgs e)
        {
            using (var d = new ColorDialog())
                if (d.ShowDialog() == DialogResult.OK)
                    (sender as Button).BackColor = terrainBase = d.Color;
        }

        private void terrainNoise_ValueChanged(object sender, EventArgs e)
        {
            terrainNoise = (float)(sender as NumericUpDown).Value;
        }

        private void terrainHeight_ValueChanged(object sender, EventArgs e)
        {
            terrainHeight = (int)(sender as NumericUpDown).Value;
        }

        private void terrainWidth_ValueChanged(object sender, EventArgs e)
        {
            terrainWidth = (int)(sender as NumericUpDown).Value;
        }

        /*  VIEW  */

        private void viewVisibility_ValueChanged(object sender, EventArgs e)
        {
            visibility = (float)(sender as NumericUpDown).Value;
        }

        private void viewResolutionX_ValueChanged(object sender, EventArgs e)
        {
            resX = (int)(sender as NumericUpDown).Value;
        }

        private void viewResolutionY_ValueChanged(object sender, EventArgs e)
        {
            resY = (int)(sender as NumericUpDown).Value;
        }

        /*  GENERATE  */
        private void generate_Click(object sender, EventArgs e)
        {
            try
            {
                //_game.terrain = new Terrain(   shit here   ); // update with form settings 
            }
            catch
            {
                (_game = new Game1()).Run(); // run with form settings
            }
        }
    }
}