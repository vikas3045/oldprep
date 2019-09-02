using System;
using System.Collections.Generic;

namespace Design
{
    public class Person
    {
        private List<int> friends = new List<int>();

        public int ID { get; internal set; }
        public string Info { get; set; }

        public Person(int personID)
        {
            ID = personID;
        }

        public Person(int personID, string info)
        {
            ID = personID;
            Info = info;
        }

        public List<int> GetFriends()
        {
            return friends;
        }

        public void AddFriend(int ID)
        {
            friends.Add(ID);
        }
    }
}