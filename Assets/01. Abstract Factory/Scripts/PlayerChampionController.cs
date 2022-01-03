using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace AbstractFactory {
    public class PlayerChampionController : MonoBehaviour {
        [SerializeField] private ChampionIndex selectedChampion;
        [SerializeField, Range(1, 5)] private int skillLevel = 1;
        [SerializeField, Range(0, 300)] private int attackDamage;
        [SerializeField, Range(0, 500)] private int abilityPower;
        [SerializeField, Range(0, 120)] private int abilityHaste;

        private ChampionIndex currentChampion;

        public Character myCharacter;
        private List<SkillBase> skills;
        
        private void Start() {
            CreateCharacter();
            UpdateStat();
        }

        void CreateCharacter() {
            var factory = CharacterFactory.Create(selectedChampion);
            myCharacter = new Character(factory);

            skills = myCharacter.GetSkillList;
            currentChampion = selectedChampion;
        }

        void UpdateStat() {
            myCharacter.AdditionalStat.attackDamage = attackDamage;
            myCharacter.AdditionalStat.abilityPower = abilityPower;
            myCharacter.AdditionalStat.abilityHaste = abilityHaste;
        }

        private void Update() {
            UpdateStat();
            foreach (var skill in skills) {
                skill.CurrentLevel = skillLevel;
                skill.Update(Time.deltaTime);
            }

            if (selectedChampion != currentChampion) {
                var prev = currentChampion;
                CreateCharacter();
                attackDamage = 0;
                abilityPower = 0;
                abilityHaste = 0;
                UpdateStat();
                Debug.Log($"<color=cyan>챔피언 변경: {prev} -> {currentChampion}</color>");
            }
        }
    }
}
