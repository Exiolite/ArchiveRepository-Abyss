using UnityEngine;

namespace Utilities.Extension
{
    public static class Vector3Extension
    {
        public static Vector3 GetRandomVector3InRangeOfSquare(float minRange, float maxRange)
        {
            Vector3 position;
            do
            {
                position = new Vector3(Random.Range(-maxRange,maxRange),Random.Range(-maxRange,maxRange),0);
            } while (Vector3.Distance(Vector3.zero, position) < minRange);
            return position;
        }
        
        public static Vector3 GetRangedVector3InShapeOfCircle(float minRange, float maxRange)
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