using FireAndExplosions.Explosion;
using FireAndExplosions.Shockwave;
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
        shockwave shockwave;
        public ExplosionView(ContentManager content, Camera camera, SpriteBatch spriteBatch, Vector2 startLocation, float scale)
        {
            _content = content;
            _camera = camera;
            _spriteBatch = spriteBatch;

            splitterSecondTexture = _content.Load<Texture2D>("Spark2");
            splitterTexture = _content.Load<Texture2D>("Spark3");
            splitterSystem = new SplitterSystem(splitterTexture, splitterSecondTexture, _spriteBatch, _camera, scale, startLocation);

            smokeTexture = _content.Load<Texture2D>("Smoketest");
            smokeSystem = new SmokeSystem(smokeTexture, scale, startLocation);

            explosionTexture = _content.Load<Texture2D>("Fixforshittyschoolcomputer");
            explosion = new Explosion2d(_spriteBatch, explosionTexture, _camera, scale, startLocation);


            shockwaveTexture = _content.Load<Texture2D>("Shockwave2");
            shockwave = new shockwave(_spriteBatch, shockwaveTexture, _camera, scale, startLocation);
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
            shockwave.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            _spriteBatch.End();
        }
    }
}
