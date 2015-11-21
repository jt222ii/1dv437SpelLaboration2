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
        public SplitterSystem(Texture2D spark, Texture2D secondSpark)
        {
            particles = new SplitterParticle[300];
            for (int i = 0; i < particles.Length; i++)
            {
                if(i%2 == 0)
                    particles[i] = new SplitterParticle(spark, rand);
                else
                    particles[i] = new SplitterParticle(secondSpark, rand);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            
            foreach (SplitterParticle particle in particles)
            {
                //flytta detta till partikeln i fråga
                float scale = camera.Scale(particle.particleSize, particle._spark);
                spriteBatch.Draw(particle._spark, camera.convertToVisualCoords(particle.position, particle._spark), null, Color.White, 0, particle.randomDirection, scale, SpriteEffects.None, 0.2f);
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
