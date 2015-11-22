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
        public SplitterSystem(Texture2D spark, Texture2D secondSpark, SpriteBatch spriteBatch, Camera camera, float scale, Vector2 startLocation)
        {
            particles = new SplitterParticle[300];
            for (int i = 0; i < particles.Length; i++)
            {
                if(i%2 == 0)
                    particles[i] = new SplitterParticle(spark, rand, spriteBatch, camera, scale, startLocation);
                else
                    particles[i] = new SplitterParticle(secondSpark, rand, spriteBatch, camera, scale, startLocation);
            }
        }

        public void Draw()
        {
            foreach (SplitterParticle particle in particles)
            {
                particle.Draw();
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
