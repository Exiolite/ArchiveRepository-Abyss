namespace Modules.Resources
{
    public class Resource
    {
        private int _resource;
        
        
        public int Get() => _resource;
        
        public void Reset() => _resource = 0;
        
        public void Add(int value) => _resource += value;

        public void Remove(int value) => _resource -= value;

        public bool IsEnough(int value) => value <= _resource;
    }
}