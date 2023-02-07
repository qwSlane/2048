using System.Collections.Generic;

namespace Services.Assets {

    public static class AssetPath {

        public static Dictionary<int, string> Tiles = new Dictionary<int, string>() {
            { 2, "Prefabs/Tiles/Tile" },
            { 4, "Prefabs/Tiles/Tile4" },
            { 8, "Prefabs/Tiles/Tile8" },
            { 16, "Prefabs/Tiles/Tile16" },
            { 32, "Prefabs/Tiles/Tile32" },
            { 64, "Prefabs/Tiles/Tile64" },
            { 128, "Prefabs/Tiles/Tile128" },
            { 256, "Prefabs/Tiles/Tile256" },
            { 512, "Prefabs/Tiles/Tile512" },
            { 1024, "Prefabs/Tiles/Tile1024" },
            { 2048, "Prefabs/Tiles/Tile2048" },
        };

        public const string CellPath = "Prefabs/Cells/Cell";

    }

}