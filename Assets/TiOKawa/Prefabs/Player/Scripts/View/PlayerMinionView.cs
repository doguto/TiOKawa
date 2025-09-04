using System.Collections.Generic;
using TiOKawa.Scripts.View;
using UnityEngine;

namespace TiOKawa.Prefabs.Player.Scripts.View
{
    public class PlayerMinionView : MonoView
    {
        [SerializeField] PlayerView playerView;

        Transform myTransform;
        List<PlayerView> players = new();

        // 軍団配置設定
        [Header("Formation Settings")]
        [SerializeField] float unitSpacing = 0.5f; // ユニット間の基本間隔
        [SerializeField] float formationRadius = 2f; // 軍団の最大半径
        [SerializeField] int unitsPerRing = 8; // 1つのリングに配置するユニット数
        [SerializeField] float randomOffset = 0.1f; // ランダムな位置オフセット

        void Awake()
        {
            myTransform = transform;
        }

        public void MoveTo(Vector3 targetPosition)
        {
            myTransform.position = targetPosition;
        }

        public void SpawnPlayer()
        {
            Debug.Log("hogehogehogeho");
            
            var createdPlayer = Instantiate(playerView, myTransform);
            
            // 軍団配置位置を計算
            Vector3 spawnPosition = CalculateFormationPosition(players.Count);
            createdPlayer.transform.localPosition = spawnPosition;
            
            players.Add(createdPlayer);
        }
        
        /// <summary>
        /// 複数のプレイヤーを一度に生成（軍団として配置）
        /// </summary>
        /// <param name="count">生成するプレイヤー数</param>
        public void SpawnPlayers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                SpawnPlayer();
            }
        }
        
        /// <summary>
        /// 軍団配置の位置を計算
        /// </summary>
        /// <param name="index">プレイヤーのインデックス</param>
        /// <returns>配置位置（ローカル座標）</returns>
        private Vector3 CalculateFormationPosition(int index)
        {
            // 最初のユニットは中心に配置
            if (index == 0)
            {
                return Vector3.zero;
            }
            
            // リング番号と角度を計算
            int ring = Mathf.CeilToInt(index / (float)unitsPerRing);
            int indexInRing = (index - 1) % unitsPerRing;
            int unitsInCurrentRing = Mathf.Min(unitsPerRing * ring, index);
            
            // リングの半径を計算（内側から外側へ）
            float radius = unitSpacing * ring;
            radius = Mathf.Min(radius, formationRadius);
            
            // 角度を計算（均等配置）
            float angleStep = 360f / unitsInCurrentRing;
            float angle = angleStep * indexInRing;
            
            // 六角形配置のオフセット（より自然な軍団感）
            if (ring % 2 == 0)
            {
                angle += angleStep * 0.5f;
            }
            
            // 極座標から直交座標へ変換
            float radian = angle * Mathf.Deg2Rad;
            Vector3 position = new Vector3(
                radius * Mathf.Cos(radian),
                0,
                radius * Mathf.Sin(radian)
            );
            
            // ランダムなオフセットを追加（自然な配置感）
            if (randomOffset > 0)
            {
                position.x += Random.Range(-randomOffset, randomOffset);
                position.z += Random.Range(-randomOffset, randomOffset);
            }
            
            return position;
        }
        
        /// <summary>
        /// 軍団の配置を再編成
        /// </summary>
        public void ReformFormation()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] != null)
                {
                    Vector3 targetPosition = CalculateFormationPosition(i);
                    players[i].transform.localPosition = targetPosition;
                }
            }
        }
        
        /// <summary>
        /// プレイヤーを削除
        /// </summary>
        /// <param name="playerToRemove">削除するプレイヤー</param>
        public void RemovePlayer(PlayerView playerToRemove)
        {
            if (players.Contains(playerToRemove))
            {
                players.Remove(playerToRemove);
                Destroy(playerToRemove.gameObject);
                
                // 軍団を再編成
                ReformFormation();
            }
        }
    }
}
