using UnityEngine;

namespace Services.Assets {

    public interface IAssetProvider {
        GameObject GetAsset(string path, Vector3 position, Transform parent);
    }

}