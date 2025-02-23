using System.Collections.Generic;
using System.Numerics;

namespace _2DRPGOOPSprint
{
    public class Tilemap
{
        Vector2 tileSize = new Vector2(32, 32);
        public List<Tile> tiles = new List<Tile>();

        public void GenerateTilemap(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x < width && y < height)
                    {
                        Tile tile = new Tile(new Vector2(x * tileSize.X, y * tileSize.Y), TileType.ground);
                        tiles.Add(tile);
                    }
                }
            }
        }
}
}
