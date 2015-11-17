using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartiklarOchSimuleringar
{
    class Camera
    {
        private int sizeOfField;
        private float particleSizeOfField = 0.06f;
        float scale = 1;
        public Camera()
        {

        }
        public void setSizeOfField(Viewport port)
        {
            int windowSizeX = port.Width;
            int windowSizeY = port.Height;
            if (windowSizeX < windowSizeY)
            {
                sizeOfField = windowSizeX;
            }
            else
            {
                sizeOfField = windowSizeY;
            }
        }

        public Vector2 convertToVisualCoords(Vector2 coords, SplitterParticle particle)
        {
            float visualX = coords.X * sizeOfField - (particle._spark.Width/2)*scale;
            float visualY = coords.Y * sizeOfField - (particle._spark.Height / 2)*scale;
            return new Vector2(visualX, visualY);
        }
        public float Scale(SplitterParticle particle)
        {
            scale = sizeOfField * particleSizeOfField / particle._spark.Width;
            return scale;
        }
    }
}
