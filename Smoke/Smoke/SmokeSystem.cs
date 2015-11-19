using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke
{
    class SmokeSystem
    {
        public List<SmokeParticle> particles = new List<SmokeParticle>();
        public int maxParticles = 100;
        public int particlesLifeTime = 5;
        private static Random rand = new Random();

        public void addSmoke(Texture2D smoke)
        {
            if (particles.Count < maxParticles)
            {
                particles.Add(new SmokeParticle(smoke, rand, particlesLifeTime));
            }
        }
        public void Update(float elapsedTime)
        {
            foreach (SmokeParticle particle in particles)
            {
                particle.move(elapsedTime);
                if(particle.lifeIsOver())
                {
                    particle.initOrResetParticle();
                }
            }      
            ////Initially wanted to just delete the ones that are done and create new ones...
            //var particlesToDelete = particles.SingleOrDefault(p => p.lifeIsOver());
            //if(particlesToDelete != null)
            //{
            //    particles.Remove(particlesToDelete);
            //}
        }
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin();
            foreach (SmokeParticle particle in particles)
            {
                particle.Draw(spriteBatch, camera);
            }
            spriteBatch.End();
        }
    }
}
