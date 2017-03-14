﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TerrainGenerator
{
    class Camera : GameComponent
    {
        // Vector3 camTarget;
        Vector3 camPosition;

        public Matrix viewMatrix
        {
            get
            {
                return Matrix.CreateLookAt(camPosition, camLookAt, Vector3.Up);
            }
        }

        Vector3 camRotation;
        float camSpeed;
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
            get;
            set;
        }

        // Mouse
        private Vector3 mouseRotationBuffer;
        private MouseState currentMouseState;
        private MouseState prevMouseState;

        public Camera(Game game, Vector3 position, Vector3 rotation, float speed)
            : base(game)
        {
            camSpeed = speed;
            //camPosition = position;
            //camRotation = rotation;
            Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                Game.GraphicsDevice.Viewport.AspectRatio,
                0.05f,
                100.0f);

            // Set camera position and rotation;
            MoveTo(position, rotation);

            prevMouseState = Mouse.GetState();
        }

        private void UpdateLookAt()
        {
            // Build a rotation matrix
            Matrix rotationMatrix = Matrix.CreateRotationX(camRotation.X) * Matrix.CreateRotationY(camRotation.Y);
            // Build look at offset vector
            Vector3 lookAtOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);
            // Update our cam's look at vector
            camLookAt = camPosition + lookAtOffset;
        }

        private void MoveTo(Vector3 pos, Vector3 rot)
        {
            Position = pos;
            Rotation = rot;
        }

        private void Move(Vector3 scale)
        {
            MoveTo(PreviewMove(scale), Rotation);
        }

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
                moveVector.Y = 1;
            }
            if (ks.IsKeyDown(Keys.X))
            {
                moveVector.Y = -1;
            }
            if (moveVector != Vector3.Zero)
            {
                // normalize the vector
                // so that we don't move faster diagonally
                moveVector.Normalize();
                // Add in smooth and speed
                moveVector *= (dt * camSpeed);
                // Move cam
                Move(moveVector);
            }

            //KeyboardState ks = Keyboard.GetState();
            //if (ks.IsKeyDown(Keys.W))
            //{
            //    camPosition.Z += 1;
            //}
            //if (ks.IsKeyDown(Keys.S))
            //{
            //    camPosition.Z += -1;
            //}
            //if (ks.IsKeyDown(Keys.A))
            //{
            //    camPosition.X += 1;
            //}
            //if (ks.IsKeyDown(Keys.D))
            //{
            //    camPosition.X += -1;
            //}
            //if (ks.IsKeyDown(Keys.X))
            //{
            //    camPosition.Y += -1;
            //}
            //if (ks.IsKeyDown(Keys.Space))
            //{
            //    camPosition.Y += 1;
            //}

            //camPosition = Vector3.Transform(camPosition, Matrix.CreateRotationX(camRotation.X) * Matrix.CreateRotationY(camRotation.Y));

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

                //if (mouseRotationBuffer.Y < MathHelper.ToRadians(-75.0f))
                //    mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(-75.0f));
                //if (mouseRotationBuffer.Y < MathHelper.ToRadians(75.0f))
                //    mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(75.0f));

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
