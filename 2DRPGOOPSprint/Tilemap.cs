using System.Collections.Generic;
using System.Numerics;

namespace _2DRPGOOPSprint
{
    public class Tilemap
{
        Vector2 tileSize = new(32, 32);
        public List<Tile> tiles = new List<Tile>();

        public void GenerateTilemap(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    TileType tileType = GetTileType(x, y, width, height);
                    Tile tile = new Tile(new Vector2(x * tileSize.X, y * tileSize.Y), tileType);
                    tiles.Add(tile);
                }
            }
        }

        private TileType GetTileType(int x, int y, int width, int height)
        {
            if (x == 0 && y == 0)
                return TileType.top_west_wall; // Top-left corner
            else if (x == width - 1 && y == 0)
                return TileType.top_east_wall; // Top-right corner
            else if (x == 0 && y == height - 1)
                return TileType.bottom_west_wall; // Bottom-left corner
            else if (x == width - 1 && y == height - 1)
                return TileType.bottom_east_wall; // Bottom-right corner
            else if (x == 0)
                return TileType.west_wall; // West wall
            else if (x == width - 1)
                return TileType.east_wall; // East wall
            else if (y == 0)
                return TileType.north_wall; // North wall
            else if (y == height - 1)
                return TileType.south_wall; // South wall

            return TileType.ground; // Default to ground for other tiles
        }
    }
}
