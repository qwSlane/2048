using System;
using UnityEngine;

namespace Services {

    public interface IInputService {

        public event Action<Vector2> Swipe;

    }

}