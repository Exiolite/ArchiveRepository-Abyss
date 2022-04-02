using UnityEngine;

namespace Utilities
{
    public static class Randomizer
    {
        public static Vector3 GenerateDotOfInterest(float minRange, float maxRange)
        {
            Vector3 position;
            do
            {
                position = new Vector3(Random.Range(-maxRange,maxRange),Random.Range(-maxRange,maxRange),0);
            } while (Vector3.Distance(new Vector3(0,0,0), position) < minRange);
            return position;
        }
        
        public static Vector3 GetVector3InCircle(float minRange, float maxRange)
        {
            Vector3 position;
            do
            {
                position = new Vector3(Random.Range(-maxRange*2,maxRange*2),Random.Range(-5.0f,5.0f),Random.Range(-maxRange*2,maxRange*2));

            }while (Vector3.Distance(Vector3.zero, position) < minRange || Vector3.Distance(Vector3.zero, position) > maxRange);
            
            return position;
        }
    }
}