using System.Collections.Generic;

namespace Trees;

public class TreeNode<T>
{
    public T? Data{get; private set;}
    public TreeNode<T>? Parent { get; private set; }
    public List<TreeNode<T>> Children { get; private set; } = [];
    public TreeNode(){
        Data = default(T);
        Parent = null;
    }
    public TreeNode(TreeNode<T> parent, T data){
        Data = data;
        Parent = parent;
    }
    public void AddChild(T nodeData){
        if(ContainsData(nodeData))
            return;
        
        TreeNode<T> newNode = new(this,nodeData);
        Children.Add(newNode);
    }
    public void RemoveChild(TreeNode<T> node){
        Children?.Remove(node);
        node.Parent = null;
    }
    public void SetParent(TreeNode<T> node){
        if(node == null || IsAncestor(node.Data))
            return;

        Parent?.RemoveChild(this);
        node.Children.Add(this);
        Parent = node;
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