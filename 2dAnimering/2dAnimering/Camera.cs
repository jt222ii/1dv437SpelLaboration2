using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2dAnimering
{
    class Camera
    {
        private int sizeOfField;
        int windowSizeX;
        int windowSizeY;
        Vector2 offput = Vector2.Zero;
        Viewport port;
        public Camera(Viewport Port)
        {
            port = Port;
            setSizeOfField();
        }
        public void setSizeOfField()
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

        public Vector2 convertToVisualCoords(Vector2 coords, Explosion explosion)
        {
            //I made the offput just to always center the 1:1 ratio field even when widescreen
            float visualX = coords.X * sizeOfField - (explosion.frameWidth / 2) + offput.X;
            float visualY = coords.Y * sizeOfField - (explosion.frameHeight / 2) + offput.Y;
            return new Vector2(visualX, visualY);
        }
    }
}
