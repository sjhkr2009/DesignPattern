using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FactoryMethod {
    public class DragonHandler : MonoBehaviour {
        [HideInInspector] public DragonImplBase dragon;
        [ShowInInspector, ReadOnly] private GameObject Target => CurrentTarget?.GetGameObject();
        [SerializeField, ReadOnly] private float attackCooldown;
        
        public IUnit CurrentTarget { get; private set; }
        
        public void SetTarget(IUnit target) {
            CurrentTarget = target;
        }

        public void ReleaseTarget() {
            CurrentTarget = null;
        }

        private void Update() {
            if (attackCooldown > 0f) {
                attackCooldown -= Time.deltaTime;
                return;
            }

            if (CurrentTarget == null || dragon == null) {
                return;
            }
            
            dragon.Attack(CurrentTarget);
            attackCooldown += (1f / dragon.AttackSpeed);
        }
    }
}
