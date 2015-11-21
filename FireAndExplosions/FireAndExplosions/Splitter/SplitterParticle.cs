using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions
{
    class SplitterParticle
    {
        public float particleSize = 0.02f;
        public Vector2 randomDirection;
        public float maxSpeed = 1f;
        public Texture2D _spark;
        public Vector2 position = new Vector2(0.5f, 0.8f);
        public Vector2 velocity;
        public Vector2 acceleration = new Vector2(0.0f, 0.7f);
        public SplitterParticle(Texture2D spark, Random rand)
        {
            _spark = spark;
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 1.1f);
            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();
            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxSpeed);
            velocity = randomDirection;
        }
        public void move(float elapsedTime)
        {
            velocity = elapsedTime * acceleration + velocity;
            position = elapsedTime * velocity + position;
        }
    }
}
