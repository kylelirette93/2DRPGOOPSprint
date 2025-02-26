using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DRPGOOPSprint
{
    public class Tile : GameEntity, IDrawable
    {
        public Texture2D Texture { get; private set; } // No need for a backing field
        public Vector2 Position { get; private set; }
        public TileType Type { get; private set; }

        public bool IsCollidable => Type != TileType.ground;

        public Rectangle Bounds => new((int)Position.X, (int)Position.Y, Texture?.Width ?? 32, Texture?.Height ?? 32);

        public Tile(Vector2 position, TileType type)
        {
            Position = position;
            Type = type;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.EasyDraw(spriteBatch, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
             // Update tiles here, for animations and stuff.
        }

        public void LoadContent(TextureManager textureManager)
        {
            Texture = textureManager.GetTexture(Type.ToString());
        }

        public bool Intersects(IDrawable other)
        {
            if (other is Player player)
            {
                return Bounds.Intersects(player.Bounds);
            }
            return false;
        }

        public void OnCollision(IDrawable other)
        {
            
        }
    }
    public enum TileType
    {
        ground,
        east_wall,
        top_west_wall,
        top_east_wall,
        bottom_west_wall,
        bottom_east_wall,
        west_wall,
        north_wall,
        south_wall
    }
}
