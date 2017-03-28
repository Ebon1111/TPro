using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Windows.Forms;

using WinFormCtrl = System.Windows.Forms.Control;
using XNAInput    = Microsoft.Xna.Framework.Input;

namespace TerrainGenerator
{
    // Struct For Control Box to Input Values
    public struct Config
    {
        public Color   WireColour;
        public float   NoiseRange;
        public int     TerrainHeight;
        public int     TerrainWidth;

        public float   CameraSpeed;
        public Vector3 CameraStartingPosition;
        public float   ViewDistance;

        public int     GraphicResolution;
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

        bool                  paused;
        KeyboardState         prev;
        public bool           IsClosed { private set; get; }

        public Control        Controller;
        public Terrain        GameTerrain;

        /// <summary>
        /// Game Constructor: initialize the graphics
        /// </summary>
        public Game1()
        {
            IsClosed = true;
        }

        public Game1(Terrain terrain): this()
        {
            GameTerrain = terrain;

            graphics    = new GraphicsDeviceManager(this);
        }

        /// <summary>
        /// Initialize the game:
        ///     1) Initialize the camera, and add it in the Component
        ///     2) Set up graphics
        ///     3) Set up the title
        /// </summary>
        protected override void Initialize()
        {
           (WinFormCtrl.FromHandle(Window.Handle) as Form).FormClosing += OnExiting;

            Components.Add(
                camera = new Camera(this,
                    camPosition = new Vector3(50f, 5f, -50f), Vector3.Zero, 10.0f));
            
            graphics.PreferredBackBufferWidth  = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen              = true;
            graphics.ApplyChanges();

            IsClosed                           = false;
            Window.Title                       = "World Generator";
            
            base.Initialize();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            IsClosed       = true;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initialize SpriteBatch and terrain, get GraphicDevice, load effect from content
        /// </summary>
        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";

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
            if (Keyboard.GetState().IsKeyUp(XNAInput.Keys.Escape) && prev.IsKeyDown(XNAInput.Keys.Escape))
            {
                paused         = !paused;
                IsMouseVisible = !IsMouseVisible;

                if (paused) Controller.TopMost = true;

            } prev = Keyboard.GetState();

            if (paused) return;

            viewMatrix = camera.viewMatrix;
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the game:
        ///     1) Draw the terrain
        /// </summary>
        /// <param name="gameTime">Game Time</param>
        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.Black);

            RasterizerState rs      = new RasterizerState();
            rs.CullMode             = CullMode.None; // rs.FillMode = FillMode.WireFrame;
            device.RasterizerState  = rs;
            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];

            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            effect.Parameters["xWorld"].SetValue(Matrix.Identity);

            GameTerrain.DrawTerrain(effect, device);

            base.Draw(gameTime);
        }
    }
}