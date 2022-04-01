using Modules.Resources;

namespace Modules.Account
{
    public class AccountResources
    {
        private readonly Resource _credits = new Resource();
        private readonly Resource _materials = new Resource();
        



        public int GetCredits() => _credits.Get();

        public int GetMaterials() => _materials.Get();
        
        
        public void SetCredits(int value) => _credits.Add(value);
        
        public void SetMaterials(int value) => _materials.Add(value);

        
        public void ResetCredits() => _credits.Reset();

        public void ResetMaterials() => _materials.Reset();
        
        
        public void AddCredits(int value) => _credits.Add(value);

        public void AddMaterials(int value) => _materials.Add(value);

        
        public void TryRemoveCredits(int value, out bool flag)
        {
            if (_credits.IsEnough(value))
            {
                _credits.Remove(value);
                flag = true;
            }
            else flag = false;
        }

        public void TryRemoveMaterials(int value, out bool flag)
        {
            if (_materials.IsEnough(value))
            {
                _materials.Remove(value);
                flag = true;
            }
            else flag = false;
        }
        

    }
}