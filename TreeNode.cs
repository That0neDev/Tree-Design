using System.Collections.Generic;

namespace Trees;

public class TreeNode<T>
{
    public TreeNode(){
        Data = default(T);
        Parent = null;
    }
    public TreeNode(TreeNode<T> parent, T data){
        Data = data;
        Parent = parent;
    }
    public T? Data{get; private set;}
    public TreeNode<T>? Parent { get; private set; }
    public List<TreeNode<T>> Children { get; private set; } = [];

    public void AddChild(T nodeData){
        if(ContainsData(nodeData))
            return;
        
        TreeNode<T> newNode = new(this,nodeData);
        Children.Add(newNode);
    }

    public void RemoveChild(TreeNode<T> Node){
        Children?.Remove(Node);
        Node.Parent = null;
    }

    public void SetParent(TreeNode<T> Node){
        if(Node == null || IsAncestor(Node.Data))
            return;

        Parent?.RemoveChild(this);
        Node.Children.Add(this);
        Parent = Node;
    }

    public void SetData(T newData){
        Data = newData;
    }

    public bool ContainsData(T nodeData){
        return Children.Exists(node => {return node.Data != null && node.Data.Equals(nodeData);});
    }

    public bool IsAncestor(T? nodeData){
        TreeNode<T>? current = this;
        while (current != null)
        {
            if(current.ContainsData(nodeData!))
                return true;
            
            current = current.Parent;
        }

        return false;
    }
}