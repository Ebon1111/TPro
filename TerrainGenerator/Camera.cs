using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TerrainGenerator
{
    /// <summary>
    /// Purpose: Provide view for the user
    /// Input: Move the camera by keyboard
    /// Output: Moveable camera object
    /// Author: Ebon
    /// Date: 2017/03/11
    /// Source: 
    ///     [XNA] First-Person Camera Tutorial. 
    ///     Retrieved from https://www.youtube.com/watch?v=XkpZLzT5OV4
    /// Updated by: Ebon
    /// Date: 2017/03/20
    /// </summary>
    class Camera : GameComponent
    {
        // Vector3 camTarget; // For flight in the future
        Game    game;
        Vector3 camPosition;
        Vector3 camOrigin;

        public Matrix viewMatrix
        {
            get
            {
                return Matrix.CreateLookAt(camPosition, camLookAt, Vector3.Up);
            }
        }

        public float CameraSpeed;
        public float ViewDistance
        {
            get
            {
                return ViewDistance;
            }
            set
            {
                (game as Game1).projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                Game.GraphicsDevice.Viewport.AspectRatio,
                1.0f,
                value);
            }
        }

        Vector3 camRotation;
        Vector3 camLookAt;

        public Vector3 Position
        {
            get
            {
                return camPosition;
            }
            set
            {
                camPosition = value;
                UpdateLookAt();
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return camRotation;
            }
            set
            {
                camRotation = value;
                UpdateLookAt();
            }
        }

        public Matrix Projection
        {
            get; set;
        }

        // Mouse
        private Vector3 mouseRotationBuffer;
        private MouseState currentMouseState;
        private MouseState prevMouseState;

        private float terrainMaxHeight;

        public Camera(Game game, Config config, bool flipped)
            : base(game)
        {
            this.game = game;

            CameraSpeed  = config.CameraSpeed;
            ViewDistance = config.ViewDistance;

            MoveTo(camOrigin = new Vector3(50f, (flipped) ? -5f : (game as Game1).GameTerrain.MaxHeight + 20f, -50f), Vector3.Zero);
            // Update Mouse State
            prevMouseState = Mouse.GetState();            
        }

        /// <summary>
        /// Using control-box to create cemara
        /// </summary>
        /// <param name="game">Current Game</param>
        /// <param name="config">Control Box Values</param>
        /// <param name="rotation">Initializing Rotation</param>
        public Camera(Game1 game, Config config, Vector3 rotation) : base(game)
        {
            CameraSpeed = config.CameraSpeed;
            Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                Game.GraphicsDevice.Viewport.AspectRatio,
                1.0f,
                config.ViewDistance); // Visibility of Distance

            // Set camera position and rotation;
            MoveTo(config.CameraStartingPosition, rotation);

            prevMouseState = Mouse.GetState();

            // Find the terrain below
            terrainMaxHeight = game.GameTerrain.MaxHeight;
        }

        /// <summary>
        /// Update camLookAt field for getting the correct view
        /// </summary>
        private void UpdateLookAt()
        {
            // Build a rotation matrix
            Matrix rotationMatrix = Matrix.CreateRotationX(camRotation.X) * Matrix.CreateRotationY(camRotation.Y);
            // Build look at offset vector
            Vector3 lookAtOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);
            // Update our cam's look at vector
            camLookAt = camPosition + lookAtOffset;
        }

        /// <summary>
        /// Set the position and rotation
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        private void MoveTo(Vector3 pos, Vector3 rot)
        {
            Position = pos;
            Rotation = rot;
        }

        /// <summary>
        /// Move to location
        /// </summary>
        /// <param name="scale">the range of movement</param>
        private void Move(Vector3 scale)
        {
            MoveTo(PreviewMove(scale), Rotation);
        }

        /// <summary>
        /// Calculate the next position
        /// </summary>
        /// <param name="amount">the range of movement</param>
        /// <returns>cameraPosition + movement</returns>
        private Vector3 PreviewMove(Vector3 amount)
        {
            // Create a rotate matrix
            Matrix rotate = Matrix.CreateRotationY(camRotation.Y);
            // Create a movement vector
            Vector3 movement = new Vector3(amount.X, amount.Y, amount.Z);
            movement = Vector3.Transform(movement, rotate);
            // Return the value of camera position + movement vector
            return camPosition + movement;
        }

        /// <summary>
        /// Update the camera position
        /// </summary>
        /// <param name="gameTime">GameTime</param>
        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentMouseState = Mouse.GetState();

            KeyboardState ks = Keyboard.GetState();
            Vector3 moveVector = Vector3.Zero;
            if (ks.IsKeyDown(Keys.W))
            {
                moveVector.Z = 1;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                moveVector.Z = -1;
            }
            if (ks.IsKeyDown(Keys.A))
            {
                moveVector.X = 1;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                moveVector.X = -1;
            }
            if (ks.IsKeyDown(Keys.Space))
            {
                if (!Game1.isFlipped)
                    moveVector.Y = 1;
                else if (Game1.isFlipped && (Position.Y < -5.0f))
                    moveVector.Y = 1;
                    
            }
            if (ks.IsKeyDown(Keys.X))
            {
                if (!Game1.isFlipped && (Position.Y - 1f) > (terrainMaxHeight + 20f))
                    moveVector.Y = -1;
                else if (Game1.isFlipped && (Position.Y - 1f) < 20f)
                    moveVector.Y = -1;
            }
            if (moveVector != Vector3.Zero)
            {
                // normalize the vector; so that we don't move faster diagonally
                moveVector.Normalize();
                // Add in smooth and speed
                moveVector *= (dt * CameraSpeed);
                // Move camera
                Move(moveVector);
            }
            if (ks.IsKeyDown(Keys.Back))
                MoveTo(camOrigin, Rotation);

            // Handle Mouse movement
            float deltaX;
            float deltaY;
            if (currentMouseState != prevMouseState)
            {
                // Cache mouse location
                deltaX = currentMouseState.X - (Game.GraphicsDevice.Viewport.Width / 2);
                deltaY = currentMouseState.Y - (Game.GraphicsDevice.Viewport.Height / 2);

                mouseRotationBuffer.X -= 0.01f * deltaX * dt;
                mouseRotationBuffer.Y -= 0.01f * deltaY * dt;

                //if (mouseRotationBuffer.X < MathHelper.ToRadians(-75.0f))
                //    mouseRotationBuffer.X = mouseRotationBuffer.X - (mouseRotationBuffer.X - MathHelper.ToRadians(-75.0f));
                //if (mouseRotationBuffer.X < MathHelper.ToRadians(75.0f))
                //    mouseRotationBuffer.X = mouseRotationBuffer.X - (mouseRotationBuffer.X - MathHelper.ToRadians(75.0f));

                Rotation = new Vector3(
                    -MathHelper.Clamp(
                        mouseRotationBuffer.Y,
                        MathHelper.ToRadians(-75.0f),
                        MathHelper.ToRadians(75.0f)),
                    MathHelper.WrapAngle(mouseRotationBuffer.X), 0);
                deltaX = 0;
                deltaY = 0;
            }

            Mouse.SetPosition(Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2);
            prevMouseState = currentMouseState;

            base.Update(gameTime);
        }
    }
}
