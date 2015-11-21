using Microsoft.Xna.Framework;
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
        int numFramesX = 40;
        int numFramesY = 1;
        SpriteBatch _spriteBatch;
        Texture2D _explosion;
        public int frameWidth;
        public int frameHeight;
        public float size = 0.2f;
        Camera _camera;
        public Explosion2d(SpriteBatch spriteBatch, Texture2D explosionTexture, Camera camera)
        {
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
            //if (timeElapsed >= maxTime)
            //{
            //    timeElapsed = 0;
            //}
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);
            int frameX = frame % numFramesX;
            int frameY = frame / numFramesX;
            int frameWidth = _explosion.Width / numFramesX;
            int frameHeight = _explosion.Height / numFramesY;

            Rectangle rect = new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight);
            float scale = _camera.Scale(size, _explosion);
            _spriteBatch.Draw(_explosion, _camera.convertToVisualCoordsForExplosion(new Vector2(0.5f, 0.8f), this), rect, Color.White, scale, Vector2.Zero, 2, SpriteEffects.None, 1f);
        }
    }
}
