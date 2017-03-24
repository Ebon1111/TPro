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
        public Color lineColour;
        public float noiseRange;
        public int heightTerrain;
        public int widthTerrain;

        public float cameraSpeed;
        public Vector3 cameraStartingPosition;

        public int graphicResolution;
        public float visibility;
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

        bool                  Paused;
        public bool           isClosed { private set; get; }

        public Control        Ctroller;
        public Terrain        GameTerrain;

        /// <summary>
        /// Game Constructor: initialize the graphics
        /// </summary>
        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics              = new GraphicsDeviceManager(this);
            isClosed              = true;

            (WinFormCtrl.FromHandle(Window.Handle) as Form).FormClosing += OnExiting;
        }

        public Game1(Terrain terrain): base()
        {
            GameTerrain = terrain;
        }

        /// <summary>
        /// Initialize the game:
        ///     1) Initialize the camera, and add it in the Component
        ///     2) Set up graphics
        ///     3) Set up the title
        /// </summary>
        protected override void Initialize()
        {            
            Components.Add(
                camera = new Camera(this,
                    camPosition = new Vector3(50f, 5f, -50f), Vector3.Zero, 10.0f));

            
            graphics.PreferredBackBufferWidth  = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen              = true;
            graphics.ApplyChanges();
            isClosed                           = false;
            Window.Title                       = "World Generator";
            
            base.Initialize();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            isClosed = true;
        }

        /// <summary>
        /// Initialize SpriteBatch and terrain, get GraphicDevice, load effect from content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(device = graphics.GraphicsDevice);
            effect      = Content.Load<Effect>("effects");

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
            if (Keyboard.GetState().IsKeyDown(XNAInput.Keys.Escape))
            {
                Paused         = !Paused;
                IsMouseVisible = !IsMouseVisible;                
            }

            if (Paused) return;

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