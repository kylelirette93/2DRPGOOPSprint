using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DRPGOOPSprint
{
    public class Tile : GameEntity, IDrawable
    {
        private Texture2D _texture;
        private Vector2 _position;
        private string _tileType;
        public Texture2D Texture { get => _texture; }
        public Vector2 Position { get => _position; }
        public TileType Type { get; set; }

        public Tile(Vector2 position, TileType type)
        {
            _position = position;
            Type = type;
            _tileType = type.ToString();
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
            _texture = textureManager.GetTexture(_tileType);
        }
    }
    public enum TileType
    {
        ground,
    }

}
