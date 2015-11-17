using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartiklarOchSimuleringar
{
    class SplitterSystem
    {

        public SplitterParticle[] particles;
        private static Random rand = new Random();
        public SplitterSystem(Texture2D spark)
        {
            particles = new SplitterParticle[99];
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i] = new SplitterParticle(spark, rand);
            }
        }
    }
}
