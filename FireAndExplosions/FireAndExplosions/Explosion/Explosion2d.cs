﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions.Explosion
{
    class Explosion2d
    {
        float timeElapsed;
        float maxTime = 1f;
        int numberOfFrames = 40;
        int numFramesX = 10;
        int numFramesY = 4;
        SpriteBatch _spriteBatch;
        Texture2D _explosion;
        public int frameWidth;
        public int frameHeight;
        public float size = 0.2f;
        float secondScale;
        Camera _camera;
        Vector2 location;
        public Explosion2d(SpriteBatch spriteBatch, Texture2D explosionTexture, Camera camera, float SecondScale, Vector2 startLocation)
        {
            location = startLocation;
            secondScale = SecondScale;
            size = size * secondScale;
            _camera = camera;
            timeElapsed = 0;
            _spriteBatch = spriteBatch;
            _explosion = explosionTexture;
            frameWidth = _explosion.Width / numFramesX;
            frameHeight = _explosion.Height / numFramesY;
        }
        public void Draw(float elapsedTime)
        {
            timeElapsed += elapsedTime;
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);
            int frameX = frame % numFramesX;
            int frameY = frame / numFramesX;
            int frameWidth = _explosion.Width / numFramesX;
            int frameHeight = _explosion.Height / numFramesY;

            Rectangle rect = new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight);
            float scale = _camera.Scale(size, frameWidth)*2;
            _spriteBatch.Draw(_explosion, _camera.convertToVisualCoords(location, frameWidth, frameHeight, scale), rect, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
        }
    }
}
