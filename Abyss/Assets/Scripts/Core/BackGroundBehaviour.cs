using Events;

namespace Core
{
    public class BackGroundBehaviour : ObjectBehaviour
    {
        protected override void Initialize()
        {
            BackGroundEvents.DestroyBackground.AddListener(DestroyItSelf);
        }

        protected override void Execute()
        {
            
        }

        private void DestroyItSelf()
        {
            BackGroundEvents.DestroyBackground.RemoveListener(DestroyItSelf);
            Destroy(gameObject);
        }
    }
}