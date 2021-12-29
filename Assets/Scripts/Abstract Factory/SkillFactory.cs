using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactory {
    public enum ChampionIndex {
        Ezreal,
        Lulu
    }

    public static class SkillFactory {
        public static IChampionSkillFactory Create(ChampionIndex championIndex)
        {
            switch (championIndex) {
                case ChampionIndex.Ezreal:
                    return new EzrealSkillFactory();
                case ChampionIndex.Lulu:
                    return new LuluSkillFactory();
            }

            return null;
        }
    }
}
