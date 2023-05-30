/*
* Unlike Python C# does not support a list of lists style Binary Tree
* structure. The following uses a linked lists approach instead.
* This produces a tree with the followinf structure...
*
*   ROOT
*   / \
*  A   B
* / \ / 
*C  D E
*
*/


BinaryTree myTree = new BinaryTree("ROOT");
myTree.insertLeft("A");
myTree.insertRight("B");
myTree.Left.insertLeft("C");
myTree.Left.insertRight("D");
myTree.Right.insertLeft("E");
myTree.inOrderTraversal();
myTree.levelOrderTraversal();

public class BinaryTree
{
    public string Root { get; set; }
    public BinaryTree? Left { get; set; }
    public BinaryTree? Right { get; set; }

    // Constructor
    public BinaryTree(string input)
    {
        Root = input;
    }

    public void insertLeft(string input)
    {
        BinaryTree leftSubTree = new BinaryTree(input);
        if(this.Left == null)
        {
            this.Left = leftSubTree;
        }
        else
        {
            leftSubTree.Left = this.Left;
            this.Left = leftSubTree;
        }
    }

    public void insertRight(string input)
    {
        BinaryTree rightSubTree = new BinaryTree(input);
        if(this.Right == null)
        {
            this.Right = rightSubTree;
        }
        else
        {
            rightSubTree.Right = this.Right;
            this.Right = rightSubTree;
        }
    }

    string getRootValue()
    {
        return this.Root;
    }

    BinaryTree? getLeftChild()
    {
        return this.Left;
    }

    BinaryTree? getRightChild()
    {
        return this.Right;
    }

    public void inOrderTraversal()
    {
        if(this.Left != null)
        {
            this.Left.inOrderTraversal();
        }

        Console.WriteLine(this.Root);
        if(this.Right != null)
        {
            this.Right.inOrderTraversal();
        }
    }

    // Bing chat provided this levelOrderTranversal function
    public void levelOrderTraversal()
    {
        Queue<BinaryTree> currentLevel = new Queue<BinaryTree>();
        Queue<BinaryTree> nextLevel = new Queue<BinaryTree>();
        currentLevel.Enqueue(this);
        int depth = 0;
        while (currentLevel.Count != 0)
        {
            BinaryTree currentNode = currentLevel.Dequeue();
            if (currentNode != null)
            {
                Console.Write(currentNode.Root + " ");
                nextLevel.Enqueue(currentNode.Left);
                nextLevel.Enqueue(currentNode.Right);
            }
            else
            {
                Console.Write("  ");
                nextLevel.Enqueue(null);
                nextLevel.Enqueue(null);
            }
            if (currentLevel.Count == 0)
            {
                Console.WriteLine();
                depth++;
                if (depth == 5) break;
                Queue<BinaryTree> temp = currentLevel;
                currentLevel = nextLevel;
                nextLevel = temp;
            }
        }
    }
}


