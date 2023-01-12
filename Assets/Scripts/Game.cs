using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField] private GameField Field;
    private void Awake() {
        Field.Initialize();
    }

}