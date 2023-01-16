using System.Collections.Generic;

namespace Services.Assets {

    public static class AssetPath {

        public static Dictionary<int, string> Tiles = new Dictionary<int, string>() {
            { 2, "Prefabs/Tiles/Tile" },
            { 4, "Prefabs/Tiles/Tile4" },
            { 8, "Prefabs/Tiles/Tile8" },
        };

        public const string CellPath = "Prefabs/Cells/Cell";

    }

}