using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactory {
    public class Character {
        public Character(ChampionIndex championIndex) {
            ChampionIndex = championIndex;
            OriginStat = CharacterStat.BasiCharacterStat;
        }
        
        public virtual ChampionIndex ChampionIndex { get; }
        public virtual CharacterStat OriginStat { get; }
        public virtual CharacterStat AdditionalStat { get; } = new CharacterStat();

        public virtual QSkillHandler skillQ { get; set; }
        public virtual WSkillHandler skillW { get; set; }
        public virtual ESkillHandler skillE { get; set; }

        public virtual float GetAbilityReductionPercent() {
            float totalHaste = OriginStat.abilityHaste + AdditionalStat.abilityHaste;
            float per = 100f / (100f + totalHaste);
            return per;
        }

        public virtual float TotalAttackDamage => OriginStat.attackDamage + AdditionalStat.attackDamage;

        public virtual float TotalAbilityPower => OriginStat.abilityPower + AdditionalStat.abilityPower;
    }
}
