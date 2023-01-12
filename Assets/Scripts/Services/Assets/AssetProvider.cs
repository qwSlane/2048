using UnityEngine;

namespace Services.Assets {

    public class AssetProvider : IAssetProvider {

        public GameObject GetAsset(string path, Vector3 position, Transform parent) {

            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, position, Quaternion.identity, parent);
        }



    }

}