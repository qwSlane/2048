using System;
using UnityEngine;

namespace Services {

    public class InputService : MonoBehaviour, IInputService {

        private Vector2 _startPosition;
        public event Action<Vector2> Swipe;

        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                _startPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }

            if (Input.GetMouseButtonUp(0)) {
                Vector2 worldPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Swipe?.Invoke((worldPosition - _startPosition).normalized);
            }
        }

    }

}