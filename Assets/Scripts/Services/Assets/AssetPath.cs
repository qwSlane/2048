using System.Collections.Generic;

namespace Services.Assets {

    public static class AssetPath {

        public static Dictionary<int, string> Tiles = new Dictionary<int, string>() {
            { 2, "Tiles/Tile" },
            { 4, "Tiles/Tile4" },
            { 8, "Tiles/Tile8" },

        };

        public const string CellPath = "Cells/Cell";

    }

}