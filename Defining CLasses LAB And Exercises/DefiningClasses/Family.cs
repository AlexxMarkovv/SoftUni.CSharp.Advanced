using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Family
    {
        private List<Person> members;

        public Family()
        {
            this.Members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }

        public void AddMember(Person member)
        {
             members.Add(member);
        }

        public Person GetOldestMember(List<Person> members)
        {
            return members.MaxBy(m => m.Age);
        }
    }
}
