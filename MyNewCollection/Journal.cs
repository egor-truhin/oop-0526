using MyNewCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNewCollectionLib
{
    public class Journal
    {
        private List<JournalEntry> entries = new();

        public void Handler(object source, CollectionHandlerEventArgs args)
        {
            entries.Add(new JournalEntry(
                args.CollectionName,
                args.ChangeType,
                args.ItemData
            ));
        }

        public void Print()
        {
            foreach (var e in entries)
                Console.WriteLine(e);
        }
    }
}
