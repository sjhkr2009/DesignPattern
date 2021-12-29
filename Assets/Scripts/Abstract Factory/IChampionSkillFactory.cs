namespace AbstractFactory {
    public interface IChampionSkillFactory {
        QSkillHandler CreateSkillQ(Character character);
        WSkillHandler CreateSkillW(Character character);
        ESkillHandler CreateSkillE(Character character);
    }

    public class EzrealSkillFactory : IChampionSkillFactory {
        public QSkillHandler CreateSkillQ(Character character) {
            return new MysticShot(character);
        }

        public WSkillHandler CreateSkillW(Character character) {
            return new EssenceFlux(character);
        }

        public ESkillHandler CreateSkillE(Character character) {
            return new ArcaneShift(character);
        }
    }
    public class LuluSkillFactory : IChampionSkillFactory {
        public QSkillHandler CreateSkillQ(Character character) {
            return new Glitterlance(character);
        }

        public WSkillHandler CreateSkillW(Character character) {
            return new Whimsy(character);
        }

        public ESkillHandler CreateSkillE(Character character) {
            return new HelpPix(character);
        }
    }
}
