using UnityEngine;

namespace AbstractFactory {
    public abstract class SkillBase
    {
        public Character Character { get; }

        public SkillBase(Character character) {
            Character = character;
        }
        
        public abstract string Name { get; protected set; }
        public abstract int MaxLevel { get; }
        protected int currentLevel = 1;

        public virtual int CurrentLevel {
            get => currentLevel;
            set => currentLevel = Mathf.Clamp(value, 0, MaxLevel);
        }
        
        protected float cost = 0f;
        public virtual float Cost {
            get => cost;
            set => cost = Mathf.Max(value, 0f);
        }

        protected float remainCooldown = 0f;
        public virtual float RemainCoolDown {
            get => remainCooldown;
            set => remainCooldown = Mathf.Clamp(value, 0f, OriginCoolDown);
        }
    
        public abstract float OriginCoolDown { get; }

        public virtual void Update(float deltaTime) {
            RemainCoolDown -= deltaTime;
        }

        public virtual bool CanUseNow() {
            return Mathf.Approximately(RemainCoolDown, 0f);
        }
        public abstract void Activate();
    }
}
