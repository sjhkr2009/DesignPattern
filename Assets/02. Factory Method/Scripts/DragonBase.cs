using UnityEngine;

namespace FactoryMethod {
    public abstract class DragonBase {
        public abstract int Type { get; protected set; }
        public abstract float AttackDamage { get; protected set; }
        public abstract float AttackSpeed { get; protected set; }
        public abstract float Hp { get; protected set; }
        public abstract float RespawnCooldown { get; protected set; }
        public abstract void Attack(IUnit target);

        public virtual void OnHit(float damage) {
            Hp -= damage;
        }
    }
    
    public interface IUnit {
        GameObject GetGameObject();
        Vector3 GetPosition();
        float GetHp();
        void OnHit(float damage);
    }

    public static class DragonSpawnTimer {
        public static void OnSlainDragon(DragonBase target) {
            Debug.Log($"<color=cyan>드래곤이 처치되었습니다. {target.RespawnCooldown}초 후에 재생성됩니다.</color>");
        }
    }
}
