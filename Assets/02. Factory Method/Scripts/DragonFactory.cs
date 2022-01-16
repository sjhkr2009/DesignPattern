using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethod {
    public abstract class DragonFactory {
        public abstract DragonBase MakeDragon(int type);
    }
}
