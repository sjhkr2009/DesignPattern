using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter {
    interface ISkillHandler<T> where T : IWeapon {
        void Activate(T weapon);
    }

    interface IBowSkillHandler : ISkillHandler<Bow> { }
    interface ICainSkillHandler : ISkillHandler<Cain> { }
    interface IOneHandedSwordSkillHandler : ISkillHandler<OneHandedSword> { }
    interface IClawSkillHandler : ISkillHandler<Claw> { }
}
