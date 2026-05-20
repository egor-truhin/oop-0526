using WorkersLib.Models;

namespace MyCollectionLib
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; } // будет использоваться только в двусвязном

        public Node(T data)
        {
            Data = data;
        }
    }
}
