using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions
{
    class Camera
    {
        private int sizeOfField;
        int windowSizeX;
        int windowSizeY;
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
        public Vector2 convertToVisualCoords(Vector2 coords, Texture2D particle)
        {
            float visualX = coords.X * sizeOfField - (particle.Width / 2) * scale + offput.X;
            float visualY = coords.Y * sizeOfField - (particle.Height / 2) * scale + offput.Y;
            return new Vector2(visualX, visualY);
        }

        public float Scale(float size, Texture2D texture)
        {
            scale = sizeOfField * size / texture.Width;
            return scale;
        }
    }
}
