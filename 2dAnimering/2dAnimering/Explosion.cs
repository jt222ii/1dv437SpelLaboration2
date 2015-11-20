using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2dAnimering
{
    class Explosion
    {
        float timeElapsed;
        float maxTime = 0.5f;
        int numberOfFrames = 48;
        int numFramesX = 4;
        int numFramesY = 8;
        SpriteBatch _spriteBatch;
        Texture2D _explosion;
        public int frameWidth;
        public int frameHeight;
        Camera _camera;
        public Explosion(SpriteBatch spriteBatch, Texture2D explosionTexture, Camera camera)
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
            if(timeElapsed >= maxTime)
            {
                timeElapsed = 0;
            }
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);
            int frameX = frame % numFramesX;
            int frameY = frame / numFramesX;
            int frameWidth = _explosion.Width / numFramesX;
            int frameHeight = _explosion.Height / numFramesY;

            Rectangle rect = new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_explosion, _camera.convertToVisualCoords(new Vector2(0.5f, 0.5f), this), rect, Color.White,0,Vector2.Zero,1,SpriteEffects.None, 0);
            _spriteBatch.End();
        }
    }
}
