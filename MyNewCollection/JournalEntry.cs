using System;
using System.Collections.Generic;
using System.Text;

namespace MyNewCollectionLib
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string ItemData { get; set; }

        public JournalEntry(string name, string type, string data)
        {
            CollectionName = name;
            ChangeType = type;
            ItemData = data;
        }

        public override string ToString()
        {
            return $"{CollectionName} | {ChangeType} | {ItemData}";
        }
    }
}
