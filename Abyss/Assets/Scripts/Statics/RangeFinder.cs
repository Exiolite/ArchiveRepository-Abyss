using Objects.SpaceObjects;
using UnityEngine;

namespace Statics
{
    public static class RangeFinder
    {
        public static float CalculateDistance(Transform parent, SpaceObject target)
        {
            return Vector3.Distance(parent.position, target.transform.position);
        }
    }
}