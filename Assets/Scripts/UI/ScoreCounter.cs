using Infrastructure.Kernel.Field;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace UI {

    public class ScoreCounter : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI score;
        private GameData _gameData;
        
        [Inject]
        public void Initialize(GameData gameData) {
            _gameData = gameData;
            _gameData.ScoreChange += UpdateScore;
        }

        private void UpdateScore() {
            score.text = $"{_gameData.ScoreData}";
        }

    }

}