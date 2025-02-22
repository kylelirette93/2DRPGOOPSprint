using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DRPGOOPSprint
{
    public interface IDrawable
    {
        Vector2 Position { get; }
        Texture2D Texture { get; }
        void Draw(SpriteBatch spriteBatch);
        void LoadContent(TextureManager textureManager);

    }
    public static class DrawableExtensions
    {
        public static void EasyDraw(this IDrawable drawable, SpriteBatch spriteBatch, Color color)
        {
            Rectangle rectangle = new((int)drawable.Position.X, (int)drawable.Position.Y, drawable.Texture.Width, drawable.Texture.Height);
            spriteBatch.Draw(drawable.Texture, rectangle, color);
        }
    }
}
