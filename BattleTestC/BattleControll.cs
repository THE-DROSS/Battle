namespace DROSS{
    class BattleControll {
        private BattleUnit[] EnemyArray;
        private BattleUnit[] PlayerArray;
        private int EnemyCount;
        private int PlayerCount;

        enum BattleStat {
            Victory,Defeat,PlayerEscape,InBattle
        };

        public BattleControll(BattleUnit[] playerArray, BattleUnit[] enemyArray) {
            this.PlayerArray = playerArray;
            this.EnemyArray = enemyArray;
            this.PlayerCount = playerArray.Length;
            this.EnemyCount = enemyArray.Length;
        }

        public void UpdateATBGauge() {
            foreach(BattleUnit unit in EnemyArray) {
                unit.UpdateAgileGauge();
            }

            foreach(BattleUnit unit in PlayerArray) {
                unit.UpdateAgileGauge();
            }
        }
        
        public int CheckStat(){

            if(AllEnemyDead() || AllEnemyEscape()) {
                return (int)BattleStat.Victory;
            }

            if (AllPlayerDead()) {
                return (int)BattleStat.Defeat;
            }

            if (AllPlayerEscape()) {
                return (int)BattleStat.PlayerEscape;
            }

            return (int)BattleStat.InBattle;
        }

        public BattleUnit GetPlayerUnit(int index) {
            return PlayerArray[index];
        }

        public BattleUnit GetEnemyUnit(int index) {
            return EnemyArray[index];
        }

        bool AllEnemyDead() {
            foreach (BattleUnit unit in EnemyArray) {
                if (!unit.IsDead()) {
                    return false;
                };

            };
            return true;
        }

        bool AllEnemyEscape() {
            foreach(BattleUnit unit in EnemyArray) {
                if(!unit.IsDead() && !unit.IsEscape()) {
                    return false;
                } 
            }
            if (!AllEnemyDead()) {
                return true;
            }else {
                return false;
            }
        }

        bool AllPlayerDead() {
            foreach(BattleUnit unit in PlayerArray) {
                if (!unit.IsDead()) {
                    return false;
                }
            }

            return true;
        }

        bool AllPlayerEscape() {
            foreach(BattleUnit unit in PlayerArray) {
                if(!unit.IsDead() && !unit.IsEscape()) {
                    return false;
                }
            }

            if (!AllPlayerDead()) {
                return true;
            }else {
                return false;
            }

        }
    }
}