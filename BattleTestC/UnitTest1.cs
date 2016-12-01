using Microsoft.VisualStudio.TestTools.UnitTesting;
using DROSS;

namespace BattleTestC {
    [TestClass]
    public class UnitTest1 {
        BattleControll battle;
        BattleUnit player1;
        BattleUnit player2;
        BattleUnit enemy1;
        BattleUnit enemy2;

        enum BattleStat {
            Victory, Defeat, PlayerEscape, InBattle
        };

        [TestInitialize]
        public void makeUnit() {
            player1 = new BattleUnit(100, 30, 20, 10000,7,3);
            player2 = new BattleUnit(80, 50, 20, 20000,6,1);
            enemy1 = new BattleUnit(50, 30, 10, 10000,2,3);
            enemy2 = new BattleUnit(60, 20, 20, 5000,5,2);
            BattleUnit[] playerArray = new BattleUnit[] { player1, player2 };
            BattleUnit[] enemyArray = new BattleUnit[] { enemy1, enemy2 };
            battle = new BattleControll(playerArray,enemyArray);
        }

        [TestMethod]
        public void DeadAndEscape() {
            battle.GetPlayerUnit(0).Dead();
            Assert.AreEqual(true, player1.IsDead());
        }

        [TestMethod]
        public void Damage() {
            int damage = player1.Attack(enemy1);
            Assert.AreEqual(20, damage);
            Assert.AreEqual(30, enemy1.GetHP());
            damage = enemy1.Attack(player1);
            Assert.AreEqual(10, damage);
            Assert.AreEqual(90, player1.GetHP());
        }

        [TestMethod]
        public void ArrayTest() {
            Assert.AreEqual(100, battle.GetPlayerUnit(0).GetHP());
            Assert.AreEqual(80,battle.GetPlayerUnit(1).GetHP());
            Assert.AreEqual(50, battle.GetEnemyUnit(0).GetHP());
            Assert.AreEqual(60, battle.GetEnemyUnit(1).GetHP());
        }

        [TestMethod]
        public void Test() {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void EndBattleTest() {
            //全員生存
            Assert.AreEqual((int)BattleStat.InBattle,battle.CheckStat());
            //Player1死亡
            battle.GetPlayerUnit(0).Dead();
            Assert.AreEqual((int)BattleStat.InBattle,battle.CheckStat());
            //Player2死亡
            battle.GetPlayerUnit(1).Dead();
            Assert.AreEqual((int)BattleStat.Defeat, battle.CheckStat());
            //Player1復活、逃亡
            battle.GetPlayerUnit(0).Revive();
            Assert.AreEqual((int)BattleStat.InBattle, battle.CheckStat());
            battle.GetPlayerUnit(0).Escape();
            Assert.AreEqual((int)BattleStat.PlayerEscape, battle.CheckStat());
            //Player2復活、逃亡
            battle.GetPlayerUnit(1).Revive();
            Assert.AreEqual((int)BattleStat.InBattle, battle.CheckStat());
            battle.GetPlayerUnit(1).Escape();
            Assert.AreEqual((int)BattleStat.PlayerEscape, battle.CheckStat());
            //Player1,2 戻る
            battle.GetPlayerUnit(0).Back();
            battle.GetPlayerUnit(1).Back();
            Assert.AreEqual((int)BattleStat.InBattle, battle.CheckStat());

            //Enemy1死亡
            battle.GetEnemyUnit(0).Dead();
            Assert.AreEqual((int)BattleStat.InBattle, battle.CheckStat());
            //Enemy2死亡
            battle.GetEnemyUnit(1).Dead();
            Assert.AreEqual((int)BattleStat.Victory, battle.CheckStat());
            //Enemy1復活、逃亡
            battle.GetEnemyUnit(0).Revive();
            Assert.AreEqual((int)BattleStat.InBattle, battle.CheckStat());
            battle.GetEnemyUnit(0).Escape();
            Assert.AreEqual((int)BattleStat.Victory, battle.CheckStat());
            //Enemy2復活、逃亡
            battle.GetEnemyUnit(1).Revive();
            Assert.AreEqual((int)BattleStat.InBattle, battle.CheckStat());
            battle.GetEnemyUnit(1).Escape();
            Assert.AreEqual((int)BattleStat.Victory, battle.CheckStat());
        }

        [TestMethod]
        public void ATBGauge() {
            battle.UpdateATBGauge();
            Assert.AreEqual(10000, battle.GetPlayerUnit(0).GetAgileGague());
            Assert.AreEqual(20000, battle.GetPlayerUnit(1).GetAgileGague());
            Assert.AreEqual(10000, battle.GetEnemyUnit(0).GetAgileGague());
            Assert.AreEqual(5000, battle.GetEnemyUnit(1).GetAgileGague());
        }

        [TestMethod]
        public void GridMapTest() {

        }
    }
}
