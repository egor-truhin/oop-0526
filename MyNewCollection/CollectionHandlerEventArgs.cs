namespace MyNewCollection
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string ItemData { get; set; }

        public CollectionHandlerEventArgs(string name, string type, string data)
        {
            CollectionName = name;
            ChangeType = type;
            ItemData = data;
        }

        public override string ToString()
        {
            return $"{CollectionName}: {ChangeType} -> {ItemData}";
        }
    }
}
