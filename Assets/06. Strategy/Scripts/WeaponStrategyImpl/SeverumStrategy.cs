using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strategy {
    public class SeverumStrategy : IWeaponStrategy {
        public WeaponType WeaponType => WeaponType.Severum;

        public void ApplyPassive(IPlayerContext player) {
            Debug.Log("<color=red>무기를 절단검(Severum)으로 교체합니다.</color>");
            Debug.Log("<color=red>가한 피해량의 일부만큼 체력을 회복합니다.</color>");
            player.LifeSteal += 10;
        }

        public void Reset(IPlayerContext player) {
            player.LifeSteal -= 10;
        }

        public void OnAttack(Transform origin, Transform target) {
            Debug.Log("<color=red>절단검 기본 공격</color>");
        }

        public void OnSkill(Transform origin, Vector3 targetPoint) {
            Debug.Log("<color=red>절단검 Q - 맹공</color>");
        }
    }
}
