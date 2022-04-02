using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utilities.Extension
{
    public static class SpriteExtension
    {
        public static Sprite GetRandomSpriteFromCollection(List<Sprite> spriteCollection)
        {
            if (spriteCollection == null) throw new Exception("Collection is not initialized");
            if (spriteCollection.Count == 0) throw new Exception("Collection must contain at least one item");

            return spriteCollection[Random.Range(0, spriteCollection.Count)];
        }
    }
}