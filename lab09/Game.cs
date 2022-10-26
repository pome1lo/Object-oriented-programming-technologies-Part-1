using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab09
{
    internal class Game : IEnumerable
    {
        public Game()
        {

        }
        public Game(string Name, string Genre)
        {
            this.Genre = Genre;
            this.Name = Name;
        }
        private string Genre = "there is no information";
        private string Name = "there is no information";

        public string PropName
        {
            get { return Name; }
            set { Name = value; }
        }
        public string PropGenre
        {
            get { return Genre; }
            set { Genre = value; }
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
