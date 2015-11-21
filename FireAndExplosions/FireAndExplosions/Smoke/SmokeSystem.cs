using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions.Smoke
{
    class SmokeSystem
    {
        private List<SmokeParticle> particles = new List<SmokeParticle>();
        private int maxParticles = 100;
        private int particlesLifeTime = 4;
        private float time = 0;
        private static Random rand = new Random();
        private Texture2D smoke;

        public SmokeSystem(Texture2D smokeTexture)
        {
            smoke = smokeTexture;
            while (particles.Count<maxParticles)
            {
                addSmoke();
            }
        }
        private void addSmoke()
        {
            if (particles.Count < maxParticles)
            {
                particles.Add(new SmokeParticle(smoke, rand, particlesLifeTime));
            }
        }
        public void Update(float elapsedTime)
        {
            // I want it to continously add smokeparticles. If the lifetime of a particle is 5 seconds and only 10 are to be rendered they should be added spread out over those 10 seconds
            //time += elapsedTime;
            //if (time >= (float)particlesLifeTime / (float)maxParticles)
            //{
            //    addSmoke();
            //    time = 0;
            //}
            foreach (SmokeParticle particle in particles)
            {
                particle.move(elapsedTime);
                if (particle.lifeIsOver())
                {
                    particle.initOrResetParticle();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (SmokeParticle particle in particles)
            {
                particle.Draw(spriteBatch, camera);
            }
        }
    }
}
