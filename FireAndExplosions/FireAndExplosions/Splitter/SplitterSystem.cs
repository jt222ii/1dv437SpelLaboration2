using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions
{
    class SplitterSystem
    {
        public SplitterParticle[] particles;
        private static Random rand = new Random();
        public SplitterSystem(Texture2D spark)
        {
            particles = new SplitterParticle[100];
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i] = new SplitterParticle(spark, rand);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            
            foreach (SplitterParticle particle in particles)
            {
                //flytta detta till partikeln i fråga
                float scale = camera.Scale(particle.particleSize, particle._spark);
                spriteBatch.Draw(particle._spark, camera.convertToVisualCoords(particle.position, particle._spark), null, Color.White, 0, particle.randomDirection, scale, SpriteEffects.None, 1f);
            }
        }

        public void Update(float timeElapsed)
        {
            foreach (SplitterParticle particle in particles)
            {
                particle.move(timeElapsed);
            }
        }

    }
}
