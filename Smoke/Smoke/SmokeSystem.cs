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
        private static Random rand = new Random();
        public void addSmoke(Texture2D smoke)
        {
            particles.Add(new SmokeParticle(smoke, rand));
        }
        public void moveAllSmokes(float elapsedTime)
        {
            foreach (SmokeParticle particle in particles)
            {
                particle.move(elapsedTime);
            }
        }
    }
}
