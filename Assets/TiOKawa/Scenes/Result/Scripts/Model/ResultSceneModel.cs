using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Infra;
using TiOKawa.Scripts.Repository;

namespace TiOKawa.Scenes.Result.Scripts.Model
{
    public class ResultSceneModel
    {
        public BattleResult Result { get; private set; }

        public ResultSceneModel()
        {

            var hoge = GameDatabase.Temporary.BattleResult;
            
            int diedTiokawaCount = hoge.DiedTiokawaCount;
            int level = hoge.Level;
            int defeatedEnemyCount = hoge.DefeatedEnemyCount;
            int tiokawaCount = hoge.TiokawaCount;

            Result = new BattleResult(diedTiokawaCount, level, defeatedEnemyCount, tiokawaCount);
        }
        public int GetLevel()
        {
            return Result.Level;
        }

        public int GetDiedTiokawaCount()
        {
            return Result.DiedTiokawaCount;
        }

        public int GetDefeatedEnemyCount()
        {
            return Result.DefeatedEnemyCount;
        }
        
        public int GetTiokawaCount()
        {
            return Result.TiokawaCount;
        }
    }
}
