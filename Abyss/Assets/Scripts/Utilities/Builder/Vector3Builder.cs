using UnityEngine;

namespace Utilities.Builder
{
    public class Vector3Builder
    {
        private Vector3 _vector3;
        
        public Vector3Builder()
        {
            _vector3 = new Vector3();
        }
        
        public Vector3Builder SetRandomRangeOfX(int start, int end)
        {
            _vector3.x = Random.Range(start, end);
            return this;
        }
        
        public Vector3Builder SetRandomRangeOfY(int start, int end)
        {
            _vector3.y = Random.Range(start, end);
            return this;
        }
        
        public Vector3Builder SetRandomRangeOfZ(int start, int end)
        {
            _vector3.z = Random.Range(start, end);
            return this;
        }

        public Vector3 ToVector()
        {
            return _vector3;
        }
    }
}