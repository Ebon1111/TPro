using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace TerrainGenerator
{
    public struct Config
    {
        public Color   lineColour;
        public float   noiseRange;
        public int     terrainHeight;
        public int     terrainWidth;

        public float   cameraSpeed;
        public Vector3 cameraStart;

        public int     graphicResolution;
        public float   visibility;
    }

    /// <summary>
    /// Purpose: 1) Practice programming in c# with XNA library.
    ///          2) Practice creating objects and 3D environment
    /// Input: User can input values for generating the world
    /// Output: Generate the required or default world
    /// Author: Francis, Chandu, & Ebon
    /// Date: 2017/03/02
    /// Updated by: Ebon
    /// Date: 2017/03/20
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDevice        device;
        Effect                effect;
        GraphicsDeviceManager graphics;
        SpriteBatch           spriteBatch;

        Camera                camera;
        Vector3               camPosition;
        Matrix                projectionMatrix;
        Matrix                viewMatrix;
        
        public Terrain        GameTerrain;
        public bool           IsClosed { private set; get; }

        /// <summary>
        /// Game Constructor: initialize the graphics
        /// </summary>
        public Game1()
        {
            IsClosed              = true;
            Content.RootDirectory = "Content";
            graphics              = new GraphicsDeviceManager(this);
            IsMouseVisible        = true;
        }

        /// <summary>
        /// Initialize the game:
        ///     1) Initialize the camera, and add it in the Component
        ///     2) Set up graphics
        ///     3) Set up the title
        /// </summary>
        protected override void Initialize()
        {
            IsClosed                           = false;
            Components.Add(
                camera = new Camera(this,
                    camPosition = new Vector3(50f, 5f, -50f), Vector3.Zero, 10.0f));

            //graphics.IsFullScreen              = true;
            graphics.PreferredBackBufferWidth  = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            (System.Windows.Forms.Control.FromHandle(Window.Handle) as Form).FormClosing += OnExit;

            Window.Title = "World Generator";

            base.Initialize();
        }

        protected void OnExit(object sender, FormClosingEventArgs args)
        {
            IsClosed = true;

            base.OnExiting(sender, args);
        }

        /// <summary>
        /// Initialize SpriteBatch and terrain, get GraphicDevice, load effect from content
        /// </summary>
        protected override void LoadContent()
        {
            effect      = Content.Load<Effect>("effects");
            spriteBatch = new SpriteBatch(device = graphics.GraphicsDevice);
            
            SetUpCamera();
        }

        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Pass the camera's projection to game
        /// </summary>
        private void SetUpCamera()
        {
            projectionMatrix = camera.Projection;
        }

        /// <summary>
        /// Update the game: 
        ///     1) set the view as camera's view
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {              
            viewMatrix = camera.viewMatrix;
            
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the game:
        ///     1) Draw the terrain
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.Black);

            var rs = new RasterizerState();

            rs.CullMode = CullMode.None;
            // rs.FillMode = FillMode.WireFrame;
            device.RasterizerState = rs;

            Matrix worldMatrix = Matrix.Identity;

            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];

            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            effect.Parameters["xWorld"].SetValue(worldMatrix);

            drawTerrain(GameTerrain.Vertices, GameTerrain.Indices);

            base.Draw(gameTime);
        }

        /// <summary>
        /// Draw terrain from vertices and indices
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="indices"></param>
        private void drawTerrain(VertexPositionColor[] vertices, int[] indices)
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColor.VertexDeclaration);
            }
        }
    }
}