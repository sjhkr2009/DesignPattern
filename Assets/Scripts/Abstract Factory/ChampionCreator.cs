using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactory {
    public class ChampionCreator : MonoBehaviour {
        [SerializeField] private ChampionIndex selectedChampion;
        [SerializeField, Range(1, 5)] private int skillLevel = 1;
        [SerializeField, Range(0, 300)] private int attackDamage;
        [SerializeField, Range(0, 500)] private int abilityPower;
        [SerializeField, Range(0, 120)] private int abilityHaste;

        private ChampionIndex currentChampion;
        
        private Character myCharacter;
        private List<SkillBase> skills;
        
        private void Start() {
            CreateCharacter();
            UpdateStat();
        }

        void CreateCharacter() {
            myCharacter = new Character(selectedChampion);
            var factory = SkillFactory.Create(selectedChampion);

            skills = new List<SkillBase>();
            skills.Add(factory.CreateSkillQ(myCharacter));
            skills.Add(factory.CreateSkillW(myCharacter));
            skills.Add(factory.CreateSkillE(myCharacter));

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
                Debug.Log($"<color=lime>챔피언 변경: {prev} -> {currentChampion}\n" +
                          $"스킬셋이 변경됩니다: {myCharacter.skillQ.Name}(Q), {myCharacter.skillW.Name}(W), {myCharacter.skillE.Name}(E)</color>");
            }
        }
    }
}
