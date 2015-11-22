﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions
{
    class SplitterParticle
    {
        public float particleSize = 0.01f;
        public Vector2 randomDirection;
        public float maxSpeed = 1f;
        public Texture2D _spark;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 acceleration = new Vector2(0.0f, 0.7f);
        public Vector2 startPos;
        private int particleLifeTime;
        float fade = 1;
        SpriteBatch _spriteBatch;
        Camera _camera;
        public SplitterParticle(Texture2D spark, Random rand, SpriteBatch spriteBatch, Camera camera, float scale, Vector2 StartLocation)
        {
            particleLifeTime = rand.Next(5, 7);
            startPos = StartLocation;
            position = StartLocation;
            acceleration = acceleration * scale;
            particleSize = particleSize * scale;
            _spark = spark;
            _camera = camera;
            _spriteBatch = spriteBatch;
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 1.1f);
            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();
            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxSpeed);
            velocity = randomDirection*scale;
        }
        public void move(float elapsedTime)
        {
            fade -= elapsedTime / particleLifeTime;
            velocity = elapsedTime * acceleration + velocity;
            position = elapsedTime * velocity + position;
            collide();

        }

        public void Draw()
        {
            float scale = _camera.Scale(particleSize, _spark.Width);
            Color color = new Color(fade, fade, fade, fade);
            _spriteBatch.Draw(_spark, _camera.convertToVisualCoords(position, _spark.Width, _spark.Height, scale), null, color, 0, randomDirection, scale, SpriteEffects.None, 0.2f);
        }
       
        //for funzies
        public void collide()
        {
            if(position.Y > startPos.Y+0.1)
            {
                velocity.Y = -velocity.Y/2;
                velocity.X = velocity.X * 0.85f;
            }
        }
    }
}
