using System;

namespace Infrastructure.Kernel.Field {

    public class GameData {

        public int ScoreData;
        public Action ScoreChange;

        public GameData() {
            ScoreData = 0;
        }

        public void UpdateScore(int value) {
            ScoreData += value;
            ScoreChange?.Invoke();
        }

    }

}