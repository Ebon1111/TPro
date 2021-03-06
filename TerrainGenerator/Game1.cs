﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Windows.Forms;

using WinFormCtrl = System.Windows.Forms.Control;
using XNAInput = Microsoft.Xna.Framework.Input;

namespace TerrainGenerator
{
    // Struct For Control Box to Input Values
    public struct Config
    {
        public Color WireColour;
        public float NoiseRange;
        public int TerrainHeight;
        public int TerrainWidth;
        public int TerrainLength;
        public Color ChosenShade;
        public float CameraSpeed;
        public Vector3 CameraStartingPosition;
        public float ViewDistance;
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
        GraphicsDeviceManager graphics;
        Effect                effect;
        SpriteBatch           spriteBatch;

        int graphicResolutionX, graphicResolutionY;

        Camera camera;
        Matrix viewMatrix;

        public Matrix projectionMatrix;

        bool          paused;
        KeyboardState prev;

        public bool        IsClosed { private set; get; }
        public static bool isFlipped;


        public object  CameraObject { get { return camera; } set { camera = (Camera) value; } }
        public Control Controller;
        public Terrain GameTerrain;
        public Terrain Sea;

        public Song bgMusic;

        private Config mainConfig;

        /// <summary>
        /// Game Constructor: initialize the graphics
        /// </summary>
        public Game1()
        {
            IsClosed = true;
        }

        public Game1(Config config) : this()
        {
            GameTerrain = new Terrain(this, mainConfig = config);
            Sea         = new Terrain(this, config, "Sea");
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

            graphicResolutionX = 2048;
            graphicResolutionY = 1536;
            graphics.PreferredBackBufferWidth  = graphicResolutionX;
            graphics.PreferredBackBufferHeight = graphicResolutionY;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges(); 

            IsClosed = false;
            Window.Title = "World Generator";

            base.Initialize();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            MediaPlayer.Stop();
            IsMouseVisible = IsClosed = true;
        }

        /// <summary>
        /// Initialize SpriteBatch and terrain, get GraphicDevice, load effect from content
        /// </summary>
        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Content.Load<Song>("main"));

            effect      = Content.Load<Effect>("effects");

            spriteBatch = new SpriteBatch(device = graphics.GraphicsDevice);

            Components.Add(camera = new Camera(this, mainConfig, isFlipped));
        }

        public void flip()
        {
            Components.Clear();
            Components.Add(camera = new Camera(this, mainConfig, isFlipped));

            MediaPlayer.Play(Content.Load<Song>("song"));
        }

        protected override void UnloadContent()
        {
            // unload here, daddy 
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
            device.Clear(Color.SkyBlue);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            device.RasterizerState = rs;
            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];

            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            effect.Parameters["xWorld"].SetValue(Matrix.Identity);

            GameTerrain.DrawTerrain(effect, device);
            Sea.DrawTerrain(effect, device);
            base.Draw(gameTime);
        }
    }
}