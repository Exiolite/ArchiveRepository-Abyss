using UnityEngine;

namespace System.Health
{
    [Serializable]
    public class Damage
    {
        public int GetDamage()
        {
            if (_damage > 0)
            {
                return _damage;
            }

            throw new Exception("Damage must be bigger than zero");
        }

        [SerializeField] private int _damage;
    }
}