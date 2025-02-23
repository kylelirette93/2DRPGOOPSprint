using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _2DRPGOOPSprint
{
    public class Scene
{
        List<GameEntity> entities;

        public Scene()
        {
            entities = new List<GameEntity>();
        }

        public void LoadInitialScene(TextureManager textureManager)
        {
            Tilemap tilemap = new Tilemap();
            tilemap.GenerateTilemap(10, 15);
            Player player = new Player(new Vector2(100, 100));
            player.LoadContent(textureManager);
            foreach (Tile tile in tilemap.tiles)
            {
                tile.LoadContent(textureManager);
                entities.Add(tile);
            }
            entities.Add(player);
            
        }

        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (GameEntity entity in entities)
            {
                if (entity is IDrawable drawable)
                {
                    drawable.Draw(spriteBatch);
                }
            }
        }

        public void UpdateAll(GameTime gameTime)
        {
            foreach (GameEntity entity in entities)
            {
                entity.Update(gameTime);
            }
        }
}
}
