using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TerrainGenerator
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Matrix projectionMatrix;

        // Camera
        Vector3 camPosition;
        Matrix viewMatrix;
        Camera camera;

        Effect effect;
        Texture2D texture;

        // Terrain Size
        private int terrainWidth = 1000;
        private int terrainHeight = 1000;
        Terrain terrain;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // IsMouseVisible = true;

        }

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

            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            device = graphics.GraphicsDevice;

            effect = Content.Load<Effect>("effects");

            // Terrain
            terrain = new Terrain(this, device, terrainWidth, terrainHeight);
            Components.Add(terrain);

            SetUpCamera();
        }

        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Pass the camera's projecction to game
        /// </summary>
        private void SetUpCamera()
        {
            projectionMatrix = camera.Projection;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            viewMatrix = camera.viewMatrix;
            
            base.Update(gameTime);
        }

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
            effect.Parameters["xTexture"].SetValue(texture);

            drawTerrain(terrain.Vertices, terrain.Indices);

            base.Draw(gameTime);
        }

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