using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactory {
    public class CharacterStat {
        public float attackDamage;
        public float abilityPower;
        public float movementSpeed;
        public float health;
        public float cost;
        public float armor;
        public float magicResistance;
        public float abilityHaste;

        public static CharacterStat BasiCharacterStat
            => new CharacterStat() {
                attackDamage = 60,
                abilityPower = 0,
                movementSpeed = 325,
                health = 550,
                cost = 400,
                armor = 24,
                magicResistance = 30,
                abilityHaste = 0
            };
    }
}


