using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Windows.Forms;

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
        public bool isClosed { private set; get; }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Matrix projectionMatrix;

        // Camera
        Vector3 camPosition;
        Matrix viewMatrix;
        Camera camera;

        Effect effect;

        // Terrain Size
        //int terrainWidth = 1000;
        //int terrainHeight = 1000;
        public Terrain terrain;

        /// <summary>
        /// Game Constructor: initialize the graphics
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            isClosed = true;

            // IsMouseVisible = true;
        }

        /// <summary>
        /// Initialize the game:
        ///     1) Initialize the camera, and add it in the Component
        ///     2) Set up graphics
        ///     3) Set up the title
        /// </summary>
        protected override void Initialize()
        {
            // Setup 1st Camera
            camPosition = new Vector3(50f, 5f, -50f); // Camera Starting Position
            camera = new Camera(this, camPosition, Vector3.Zero, 10.0f);
            Components.Add(camera);

            // Setup Resolution
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Window.Title = "World Generator";

            isClosed = false;
            (System.Windows.Forms.Control.FromHandle(Window.Handle) as Form).FormClosing += OnExiting;

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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            device = graphics.GraphicsDevice;

            effect = Content.Load<Effect>("effects");

            //terrain = new Terrain(this, 1000, 1000);
            Components.Add(terrain);

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
            // Press ESC to Exit the Game
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                terrain = null;
                camera = null;
                IsMouseVisible = true;
                this.Exit(); // Will cause the form freeze -- bug
                // Exit();
            }
            else
            {
                // Sometimes, NullReference will occur -- bug

                // Set the view as camera's view
                viewMatrix = camera.viewMatrix;

                // Pause Function Testing
                //if (!this.IsActive)
                //    BeginPause(true);

                base.Update(gameTime);
            }

        }

        /// <summary>
        /// Draw the game:
        ///     1) Draw the terrain
        /// </summary>
        /// <param name="gameTime">Game Time</param>
        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.Black);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            // rs.FillMode = FillMode.WireFrame;
            device.RasterizerState = rs;

            Matrix worldMatrix = Matrix.Identity;
            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];
            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            effect.Parameters["xWorld"].SetValue(worldMatrix);

            terrain.DrawTerrain(effect, device);

            base.Draw(gameTime);
        }
    }
}