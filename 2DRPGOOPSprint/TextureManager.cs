using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2DRPGOOPSprint
{
    public class TextureManager
    {
        private Dictionary<string, Texture2D> textures;
        private ContentManager _content;

        public TextureManager(ContentManager content)
        {
            _content = content;
            textures = new Dictionary<string, Texture2D>();
        }

        public Texture2D GetTexture(string textureName)
        {
            if (!textures.ContainsKey(textureName))
            {
                try
                {
                    textures[textureName] = _content.Load<Texture2D>(textureName);
                }
                catch (ContentLoadException ex)
                {
                    throw new Exception($"Texture {textureName} not found.", ex);
                }
            }
            return textures[textureName];
        }
    }
}
