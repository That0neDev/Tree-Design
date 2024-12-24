using System;

namespace Trees;

public class Tree<T>(){
    public TreeNode<T> Root = new();
    public TreeNode<T>? GetNode(TreeNode<T> rootNode, T target){
        
        if(rootNode == null)
            return null;
        
        if(rootNode.ContainsData(target))
            return rootNode.Children.Find(x => x.Data!.Equals(target));
        
        foreach (TreeNode<T> Node in rootNode.Children)
        {
            if (Node == null || Node.Data == null)
                continue;
            
            TreeNode<T>? result = GetNode(Node, target);
            if (result != null)
                return result;
        }

        return null;
    }
    public void AddChildToNode(TreeNode<T> Node, T data){
        Node.AddChild(data);
    }
    public void RemoveChildFromNode(TreeNode<T> node){
        node.RemoveChild(node);
    }
    public void Traverse(TreeNode<T> root, Action<TreeNode<T>> visitAction)
    {
        if(root == null)
            return;

        visitAction(root);
        foreach (TreeNode<T> child in root.Children)
        {
            Traverse(child, visitAction);
        }
    }
}