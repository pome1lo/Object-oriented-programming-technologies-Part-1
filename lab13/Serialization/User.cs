using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    public class Users
    {
        public List<User> UserList { get; set; } = new List<User>();
    }
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }

        public User() { }
        public User(string Name, int Sex, int Age)
        {
            this.Name = Name;
            this.Sex = Sex;
            this.Age = Age;
        }
        public User(string Name, int Sex, int Age, bool Cool)
        {
            this.Name = Name;
            this.Sex = Sex;
            this.Age = Age;
            this.Cool = Cool;
        }
        [JsonIgnore]
        [SoapIgnore]
        [XmlIgnore]
        public bool Cool { get; set; } = false;
    }
}
