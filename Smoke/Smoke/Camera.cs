using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke
{
    class Camera
    {
        private int sizeOfField;
        int windowSizeX;
        int windowSizeY;
        private float particleSizeOfField = 0.02f;
        Vector2 offput = Vector2.Zero;
        float scale = 1;
        public void setSizeOfField(Viewport port)
        {
            windowSizeX = port.Width;
            windowSizeY = port.Height;
            if (windowSizeX < windowSizeY)
            {
                sizeOfField = windowSizeX;
                offput.Y = (windowSizeY - sizeOfField) / 2;
            }
            else
            {
                sizeOfField = windowSizeY;
                offput.X = (windowSizeX - sizeOfField) / 2;
            }
        }

        public Vector2 convertToVisualCoords(Vector2 coords, SmokeParticle particle)
        {
            float visualX = coords.X * sizeOfField - (particle._smoke.Width / 2) * scale + offput.X;
            float visualY = coords.Y * sizeOfField - (particle._smoke.Height / 2) * scale + offput.Y;
            return new Vector2(visualX, visualY);
        }
        public float Scale(SmokeParticle particle)
        {
            scale = sizeOfField * particleSizeOfField / particle._smoke.Width;
            return scale;
        }
    }
}
