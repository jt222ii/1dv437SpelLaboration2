using FireAndExplosions.Explosion;
using FireAndExplosions.Smoke;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions
{
    class ExplosionView
    {
        ContentManager _content;
        Camera _camera;
        SpriteBatch _spriteBatch;
        Texture2D splitterTexture;
        Texture2D splitterSecondTexture;
        Texture2D smokeTexture;
        Texture2D shockwaveTexture;
        Texture2D explosionTexture;

        SplitterSystem splitterSystem;
        SmokeSystem smokeSystem;
        Explosion2d explosion;
        public ExplosionView(ContentManager content, Camera camera, SpriteBatch spriteBatch)
        {
            _content = content;
            _camera = camera;
            _spriteBatch = spriteBatch;
        }
        public void createExplosion(Vector2 startLocation, float scale)
        {
            splitterSecondTexture = _content.Load<Texture2D>("Spark2");
            splitterTexture = _content.Load<Texture2D>("Spark3");
            splitterSystem = new SplitterSystem(splitterTexture, splitterSecondTexture, _spriteBatch, _camera, scale, startLocation);

            smokeTexture = _content.Load<Texture2D>("particlesmokepng");
            smokeSystem = new SmokeSystem(smokeTexture, scale, startLocation);
            //shockwaveTexture = Content.Load<Texture2D>("");
            explosionTexture = _content.Load<Texture2D>("ExplosionSprite");
            explosion = new Explosion2d(_spriteBatch, explosionTexture, _camera, scale, startLocation);
        }
        public void UpdateExplosion(GameTime gameTime)
        {
            float timeElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            splitterSystem.Update(timeElapsedSeconds);
            smokeSystem.Update(timeElapsedSeconds);
        }
        public void DrawExplosion(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            splitterSystem.Draw();
            smokeSystem.Draw(_spriteBatch, _camera);
            explosion.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your drawing code here
            _spriteBatch.End();
        }
    }
}
