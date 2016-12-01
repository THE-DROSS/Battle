
namespace DROSS {
    class BattleUnit {
        int PlaceY;
        int PlaceX;
        int MaxHitPoint;
        int HitPoint;
        int OffensivePower;
        int DiffencePower;
        int Agile;
        int AgileGauge;
        //1:DeadFlg
        //2:EscapeFlg
        private uint StatsFlag;

        public BattleUnit(int setHitPoint , int setOffensivePower , int setDiffencePower,int setAgile,int setPlaceY,int setPlaceX) {
            setPlaceX = PlaceX;
            setPlaceY = PlaceY;
            MaxHitPoint = setHitPoint;
            HitPoint = setHitPoint;
            OffensivePower = setOffensivePower;
            DiffencePower = setDiffencePower;
            Agile = setAgile;
            StatsFlag = StatsFlag & 0;
        }

        public int Attack(BattleUnit target) {
            int damage = this.OffensivePower - target.DiffencePower;
            target.HitPoint -= damage;
            return damage;
        }

        public void UpdateAgileGauge() {
            this.AgileGauge = +this.Agile;  
        }

        public int GetHP() {
            return this.HitPoint;
        }

        public int GetAgileGague() {
            return this.AgileGauge;
        }

        public void Dead() {
            StatsFlag = this.StatsFlag | 0x80000000;
        }

        public void Revive() {
            StatsFlag = this.StatsFlag ^ 0x80000000;
        }

        public void Escape() {
            StatsFlag = this.StatsFlag | 0x40000000;
        }

        public void Back() {
            StatsFlag = this.StatsFlag ^ 0x40000000;
        }


        public bool IsDead() {
            var FlgChk = StatsFlag & 0x80000000;
            if(FlgChk == 0x80000000) {
                return true;
            }else {
                return false;
            }
        }

        public bool IsEscape() {
            var FlgChk = StatsFlag & 0x40000000;
            if(FlgChk == 0x40000000) {
                return true;
            }else {
                return false;
            }
        }
    }
}
