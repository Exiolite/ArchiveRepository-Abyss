using Events;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects.BackGrounds
{
    public class StarsHandler : MonoBehaviour
    {
        [SerializeField] private Transform _star;

        private readonly Transform[] _masStars = new Transform[120];


        private void Start()
        {
            CreateStars();
            SetStars();
            LevelEvent.DestroyAllExcludePlayer.AddListener(UpdateStars);
        }

        private void CreateStars()
        {
            for (int i = 0; i < 120; i++)
            {
                _masStars[i] = Instantiate(_star, transform);
            }
        }

        private void UpdateStars(Ship ship)
        {
            SetStars();
        }
        
        private void SetStars()
        {
            for (int i = 0; i < 120; i++)
            {
                _masStars[i].transform.localPosition = new Vector3(Random.Range(-5000,5000), Random.Range(-5000,5000), 0);
                var scale = Random.Range(0.1f, .4f);
                _masStars[i].transform.localScale = new Vector3(scale,scale,0);
            }
        }
    }
}