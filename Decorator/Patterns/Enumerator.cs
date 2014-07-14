using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Patterns
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    public class PersonList : IEnumerable
    {
        private readonly Person[] _people;

        public PersonList(Person[] people)
        {
            _people = new Person[people.Length];

            for (var i = 0; i < people.Length; i++)
            {
                _people[i] = people[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PersonEnumerator GetEnumerator()
        {
            return new PersonEnumerator(_people);
        }
    }

    public class PersonEnumerator : IEnumerator
    {
        private readonly Person[] _people;
        private int _currentPosition = -1;

        public PersonEnumerator(Person[] people)
        {
            _people = people;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _people[_currentPosition];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            _currentPosition++;
            return (_currentPosition < _people.Length);
        }

        public void Reset()
        {
            _currentPosition = -1;
        }
    }


}
