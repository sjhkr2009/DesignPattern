using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Adapter {
    public class Player03 : MonoBehaviour {
        [SerializeField] private CainSkillAdapter adapter;
        [ShowInInspector]
        private float AttackDamage {
            get => weapon?.AttackPower ?? -1;
            set {
                if (weapon == null) weapon = new Cain();
                weapon.AttackPower = value;
            }
        }

        private Cain weapon = new Cain {AttackPower = 100};

        private void Start() {
#if UNITY_EDITOR
            UnityEditor.Selection.activeGameObject = gameObject;
#endif
        }

        [Button("쿼드러플 스로우")]
        void DoQuadrupleThrow() {
            var handler = new QuadrupleThrow();
            var claw = adapter.Convert<Claw>(weapon);
            handler.Activate(claw);
        }

        [Button("레이징 블로우")]
        void DoRaisingBlow() {
            var handler = new RaisingBlow();
            var sword = adapter.Convert<OneHandedSword>(weapon);
            handler.Activate(sword);
        }
        
        [Button("언카운터블 애로우")]
        void DoUncountableArrow() {
            var handler = new UncountableArrow();
            var bow = adapter.Convert<Bow>(weapon);
            handler.Activate(bow);
        }
    }
}
