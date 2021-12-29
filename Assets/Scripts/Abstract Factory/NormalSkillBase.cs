using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactory {
    public abstract class NormalSkillBase : SkillBase {
        public override int MaxLevel => 5;

        public override void Activate() {
            RemainCoolDown = OriginCoolDown * Character.GetAbilityReductionPercent();
            Debug.Log($"스킬 사용: {Name} --- 쿨타임 {RemainCoolDown:0.0}로 초기화됨");
        }

        protected NormalSkillBase(Character character) : base(character) { }
    }

    public abstract class QSkillHandler : NormalSkillBase {
        protected QSkillHandler(Character character) : base(character) {
            character.skillQ = this;
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);
            
            if (Input.GetKeyDown(KeyCode.Q)) {
                if (CanUseNow()) Activate();
                else Debug.Log($"{Name}(Q) 쿨타임이 {RemainCoolDown}초 남았습니다.");
            }
        }
    }
    public abstract class WSkillHandler : NormalSkillBase {
        protected WSkillHandler(Character character) : base(character) {
            character.skillW = this;
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);

            if (Input.GetKeyDown(KeyCode.W)) {
                if (CanUseNow()) Activate();
                else Debug.Log($"{Name}(W) 쿨타임이 {RemainCoolDown}초 남았습니다.");
            }
        }
    }
    public abstract class ESkillHandler : NormalSkillBase {
        protected ESkillHandler(Character character) : base(character) {
            character.skillE = this;
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);

            if (Input.GetKeyDown(KeyCode.E)) {
                if (CanUseNow()) Activate();
                else Debug.Log($"{Name}(E) 쿨타임이 {RemainCoolDown}초 남았습니다.");
            }
        }
    }
}
