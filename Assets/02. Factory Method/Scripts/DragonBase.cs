using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethod {
    public abstract class DragonBase {
        public abstract int Type { get; protected set; }
        public abstract float AttackDamage { get; protected set; }
        public abstract float AttackSpeed { get; protected set; }

        public abstract void Attack(IUnit target);
    }
    
    public interface IUnit {
        GameObject GetGameObject();
        Vector3 GetPosition();
        float GetHp();
        void OnHit(float damage);
    }
}
