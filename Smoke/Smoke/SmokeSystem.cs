using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke
{
    class SmokeSystem
    {
        public SmokeParticle[] particles;
        private static Random rand = new Random();
        public SmokeSystem(Texture2D smoke)
        {
            particles = new SmokeParticle[100];
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i] = new SmokeParticle(smoke, rand);
            }
        }
    }
}
