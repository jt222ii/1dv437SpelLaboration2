﻿using Microsoft.Xna.Framework;
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
                offput.Y = (windowSizeY - sizeOfField)/2;
            }
            else
            {
                sizeOfField = windowSizeY;
                offput.X = (windowSizeX - sizeOfField)/2;
            }
        }

        public Vector2 convertToVisualCoords(Vector2 coords, SplitterParticle particle)
        {
            //I made the offput just to always center the 1:1 ratio field even when widescreen
            //Times the scale because the width of the texture will not be its original size if the scale is anything but 1. (ie 64px scale 0.5 is 32px)
            float visualX = coords.X * sizeOfField - (particle._spark.Width/2)*scale + offput.X;
            float visualY = coords.Y * sizeOfField - (particle._spark.Height / 2) * scale + offput.Y;
            return new Vector2(visualX, visualY);
        }
        public float Scale(SplitterParticle particle)
        {
            scale = sizeOfField * particleSizeOfField / particle._spark.Width;
            return scale;
        }
    }
}
