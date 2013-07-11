
public class Node<T> 
{
	private Node<T> left;
	private Node<T> right;
	private T element;
	
	

public Node(T e)
{
	left = null;
	right = null;
	this.element = e;
}
public Node()
{
	left = null;
	right = null;
	this.element = element;
}

public T getElelemnt()
{
	return this.element;
}

public void setElement(T e)
{
	this.element = e;
}

public Node<T> getLeft()
{
	return left;
}

public Node<T> getRight()
{
	return right;
}

public void setLeft( Node<T> n )
{	
	this.left = n;
}

public void setRight( Node<T> n )
{	
	this.right = n;
}

public boolean isLeaf()
{
	return (left == null && right == null);
}

}
