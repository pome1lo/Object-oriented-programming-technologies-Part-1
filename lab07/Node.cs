
namespace lab_03_list
{
    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T> NextNode { get; set; }

        public Node(T Data = default, Node<T> NextNode = null)
        {
            this.Data = Data;
            this.NextNode = NextNode;
        }
    }
}
