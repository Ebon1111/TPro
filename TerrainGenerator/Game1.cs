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
        // Testing Key Down booleans
        public bool leftDown = false;
        public bool rightDown = false;
        public bool upDown = false;
        public bool downDown = false;
        public Point objectLocation = new Point(0, 0);
        // Orbit
        bool orbit;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;

        // Camera
        Vector3 camTarget;
        Vector3 camPosition;

        Matrix viewMatrix;


        // Test 1st person
        Camera camera;
        // cam end

        Effect effect;
        VertexPositionColor[] vertices;
        Matrix projectionMatrix;
        int[] indices;

        private float angle = 0f;
        private int terrainWidth = 100;
        private int terrainHeight = 100;
        private float[,] heightData;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            new Control().Show();
            // IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // Setup Camera
            // camTarget = new Vector3(0f, 0f, 0f);
            camPosition = new Vector3(0f, 5f, -50f);

            // Test 1st Camera
            camera = new Camera(this, camPosition, Vector3.Zero, 10.0f);
            Components.Add(camera);

            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Riemer's XNA Tutorials -- 3D Series 1";

            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            device = graphics.GraphicsDevice;

            effect = Content.Load<Effect>("effects"); SetUpCamera();

            LoadHeightData();
            SetUpVertices();
            SetUpIndices();
        }

        protected override void UnloadContent()
        {
        }

        private void SetUpVertices()
        {
            vertices = new VertexPositionColor[terrainWidth * terrainHeight];
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, heightData[x, y], -y);
                    vertices[x + y * terrainWidth].Color = Color.White;
                }
            }
        }

        private void SetUpIndices()
        {
            indices = new int[(terrainWidth - 1) * (terrainHeight - 1) * 6];
            int counter = 0;
            for (int y = 0; y < terrainHeight - 1; y++)
            {
                for (int x = 0; x < terrainWidth - 1; x++)
                {
                    int lowerLeft = x + y * terrainWidth;
                    int lowerRight = (x + 1) + y * terrainWidth;
                    int topLeft = x + (y + 1) * terrainWidth;
                    int topRight = (x + 1) + (y + 1) * terrainWidth;

                    indices[counter++] = topLeft;
                    indices[counter++] = lowerRight;
                    indices[counter++] = lowerLeft;

                    indices[counter++] = topLeft;
                    indices[counter++] = topRight;
                    indices[counter++] = lowerRight;
                }
            }
        }

        private void LoadHeightData()
        {
            Random rng = new Random();
            heightData = new float[terrainWidth, terrainHeight];

            for (int i = 0; i < terrainHeight; i++)
            {
                for (int j = 0; j < terrainWidth; j++)
                {
                    heightData[j, i] = new Func<float>(() =>
                    {
                        double mantissa = (rng.NextDouble());
                        double exponent = Math.Pow(2.0, rng.Next(1, 3));
                        return (float)(mantissa * exponent);
                    })();
                }
            }
        }

        private void SetUpCamera()
        {
            // viewMatrix = Matrix.CreateLookAt(new Vector3(0, 10, 0), new Vector3(0, 0, 0), new Vector3(0, 0, -1));
            // viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up); // Vector3.Up == Vector(0, 1, 0);
            // orthographic
            // projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);
            projectionMatrix = camera.Projection;
            // Set up in Camera Consrtuctor
            //projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
            //    MathHelper.PiOver4,
            //    device.Viewport.AspectRatio,
            //    0.05f,
            //    1000.0f);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            viewMatrix = camera.viewMatrix;
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

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColor.VertexDeclaration);
            }

            base.Draw(gameTime);
        }
    }
}