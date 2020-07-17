using System;

namespace Model
{
    [Serializable]
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
    }
}
