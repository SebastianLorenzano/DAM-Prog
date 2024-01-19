
using System.Security.Cryptography.X509Certificates;

namespace basura12_12_23
{
    public class Graveyard
    {
        private List<Person> _personList = new();

        public int PersonCount => _personList.Count;
      
            

        public List<Person> PersonList => _personList;

         // Indexers
        public void RemovePersonAt(int index)
        {
            if (index > 0 && index < PersonCount)
                _personList.RemoveAt(index);
        }

        public void AddPerson(Person p)
        {
            _personList.Add(p);
        }

        public Person? GetPersonAt(int index)
        {
            if (index > 0 && index < _personList.Count)
                return _personList[index];
            return null;
        }
    }
}
