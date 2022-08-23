using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model
{
    public class OMSObservableCollection<T> : ObservableCollection<T>
    {
        protected internal Dictionary<string, int> indecies = new Dictionary<string, int>();
        protected internal Func<T, string> _keySelector;

        public OMSObservableCollection(IEnumerable<T> items, Func<T, string> keySelector) : base(items)
        {
            _keySelector = keySelector;
            BuildIndex(items);
        }

        private void BuildIndex(IEnumerable<T> items)
        {
            for(var i = 0; i < this.Count; i++)
            {
                var item = this[i];
                indecies.Add(_keySelector(item), i);
            }
        }

        protected override void InsertItem(int index, T item)
        {

            if (indecies.ContainsKey(_keySelector(item)))
                throw new DuplicateKeyException(_keySelector(item));

            if (index != this.Count)
            {
                foreach (var k in indecies.Keys.Where(k => indecies[k] >= index).ToList())
                {
                    indecies[k]++;
                }
            }

            base.InsertItem(index, item);
            indecies[_keySelector(item)] = index;
        }
        protected override void ClearItems()
        {
            base.ClearItems();
            indecies.Clear();
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            var key = _keySelector(item);

            base.RemoveItem(index);

            indecies.Remove(key);

            foreach (var k in indecies.Keys.Where(k => indecies[k] > index).ToList())
            {
                indecies[k]--;
            }
        }

        public virtual T this[string key]
        {

            get { return this[indecies[key]]; }
            set
            {
                if (!indecies.ContainsKey(key))
                {
                    this.Add(value);
                    var index = IndexOf(value);
                    indecies.Add(key, index);   
                }
                else
                {
                    var k = indecies[key];
                    //confirm key matches
                    if (!string.Equals(_keySelector(this[k]), key))
                        throw new InvalidOperationException("Key of new value does not match");

                    this[indecies[key]] = value;
                }
            }
        }

        public virtual bool ContainsKey(string key)
        {
            return indecies.ContainsKey(key);
        }

        public virtual void Update(T model)
        {
            this[_keySelector(model)] = model;
        }
    }
}
