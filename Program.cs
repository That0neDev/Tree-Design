using System;

namespace Trees;

class Program
{
    static void Main(string[] args)
    {
        Tree<string> Hierarchy = new();
        var Root = Hierarchy.Root;
        Root.SetData("Root");
        Hierarchy.AddChildToNode(Root,"A");
        Hierarchy.AddChildToNode(Root,"B");
        Hierarchy.AddChildToNode(Hierarchy.GetNode(Root,"A")!,"C");
        Hierarchy.AddChildToNode(Hierarchy.GetNode(Root,"B")!,"D");
        Hierarchy.AddChildToNode(Hierarchy.GetNode(Root,"D")!,"E");

        Hierarchy.Traverse(Root,node => {
            if(node.Parent != null)
                Console.WriteLine($"I am {node.Data}, and my parent is {node.Parent.Data}!");
            else Console.WriteLine($"I am Root and i do not have a parent!");
        });
    }
}