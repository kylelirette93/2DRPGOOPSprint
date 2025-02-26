using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DRPGOOPSprint
{
    public interface IDrawable
    {
        Vector2 Position { get; }
        Texture2D Texture { get; }
        void Draw(SpriteBatch spriteBatch);
        void LoadContent(TextureManager textureManager);
        Rectangle Bounds { get; }

        void OnCollision(IDrawable other);

    }
    public static class DrawableExtensions
    {
        public static void EasyDraw(this IDrawable drawable, SpriteBatch spriteBatch, Color color)
        {           
            spriteBatch.Draw(drawable.Texture, drawable.Bounds, color);
        }
    }
}
