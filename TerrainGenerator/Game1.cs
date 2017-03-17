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

            // Terrain
            terrain = new Terrain(this, device, terrainWidth, terrainHeight);
            Components.Add(terrain);

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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            //angle += 0.005f;

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    camPosition.X += 1f;
            //    camTarget.X += 1f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    camPosition.X -= 1f;
            //    camTarget.X -= 1f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    camPosition.Y += 1f;
            //    camTarget.Y += 1f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    camPosition.Y -= 1f;
            //    camTarget.Y -= 1f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            //{
            //    camPosition.Z += 1f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            //{
            //    camPosition.Z -= 1f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    orbit = !orbit;
            //}

            //if (orbit)
            //{
            //    Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(1f));
            //    camPosition = Vector3.Transform(camPosition, rotationMatrix);
            //}

            // first person cam


            // cam end

            //camPosition.X += Mouse.GetState().X;
            //camTarget.X += Mouse.GetState().X;
            //camPosition.Y += Mouse.GetState().Y;
            //camTarget.Y += Mouse.GetState().Y;

            //Mouse.SetPosition(0, 0);

            viewMatrix = camera.viewMatrix;
            // viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up);


            //#region Constrain mouse to window

            //if (Mouse.GetState().X < 0)

            //    Mouse.SetPosition(0, Mouse.GetState().Y);

            //if (Mouse.GetState().X > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)

            //    Mouse.SetPosition(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, Mouse.GetState().Y);

            //if (Mouse.GetState().Y < 0)

            //    Mouse.SetPosition(Mouse.GetState().X, 0);

            //if (Mouse.GetState().Y > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)

            //    Mouse.SetPosition(Mouse.GetState().X, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);

            //#endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.Black);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;
            device.RasterizerState = rs;

            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];
            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            Matrix worldMatrix = Matrix.Identity;
            effect.Parameters["xWorld"].SetValue(worldMatrix);

            drawTerrain(terrain.Vertices, terrain.Indices);

            base.Draw(gameTime);
        }

        private void drawTerrain(VertexPositionColor[] vertices, int[] indices)
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColor.VertexDeclaration);

                device.DrawUserPrimitives(PrimitiveType.TriangleList, indices, 0, 2, VertexPositionColor.VertexDeclaration);
            }
        }
    }
}