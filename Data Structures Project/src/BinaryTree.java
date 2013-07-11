import java.util.LinkedList;
import java.util.Stack;

public class BinaryTree<T> {

	private Node<T> root;
	private Node<T> current;
	private int size;

	public static enum location {
		leftChild, rightChild, parent, root
	};

	public BinaryTree(Node<T> n) {
		root = n;
		current = root;
		size = 0;
	}

	public BinaryTree() {
		root = null;
		current = null;
		size = 0;
	}

	public Node<T> getRoot() {
		return root;
	}

	public T getCurrent() {
		return current.getElelemnt();
	}

	public int getSize() {
		return size;
	}

	public void destroy(Node<T> n) {

		if (n != null) {
			destroy(n.getLeft());
			destroy(n.getRight());
			n = null;
			size--;
		}
	}

	public boolean leaf() {
		boolean leaf = false;
		leaf = (current.getLeft() == null && current.getRight() == null);
		return leaf;
	}

	private Node<T> findParent(Node<T> n) {
		Stack<Node<T>> s = new Stack<Node<T>>();
		n = root;
		while (n.getLeft() != current && n.getRight() != current) {
			if (n.getLeft() != null) {
				n = n.getLeft();
			}
			if (n.getRight() != null) {
				s.push(n.getRight());
			} else {
				n = s.pop();
			}
		}
		s.clear();
		return n;
	}

	public boolean moveTo(location locate) {
		boolean found = false;
		switch (locate) {
		case leftChild:
			if (current.getLeft() != null) {
				current = current.getLeft();
				found = true;
			}
			break;
		case rightChild:
			if (current.getRight() != null) {
				current = current.getRight();
				found = true;
			}
			break;
		case parent:
			if (current != root) {
				current = findParent(current);
				found = true;
			}
			break;
		case root:
			if (root != null) {
				current = root;
				found = true;
			}
			break;
		}

		return found;
	}

	public boolean add(T value, location locate) {
		boolean inserted = true;
		Node<T> node = null;
		if ((locate == BinaryTree.location.leftChild && current.getLeft() != null)
				|| (locate == BinaryTree.location.rightChild && current
						.getRight() != null)) {
			inserted = false;
		} else {

			node = new Node<T>(value);
			switch (locate) {
			case leftChild:
				current.setLeft(node);
				break;
			case rightChild:
				current.setRight(node);
				break;
			case root:
				if (root == null) {
					root = node;
					current = root;
					break;
				}

			}
			size++;
		}
		return inserted;
	}

	public void Update(T e) {
		current.setElement(e);
	}

	public void preorder(Node<T> p) {
		if (p != null) {
			System.out.print(p.getElelemnt().toString());
			size++;
			preorder(p.getLeft());
			preorder(p.getRight());
		}
	}

	public void postorder(Node<T> p) {
		if (p != null) {
			postorder(p.getLeft());
			postorder(p.getRight());
			System.out.print(p.getElelemnt().toString());
			size++;
		}
	}

	public boolean Empty() {
		return root == null;
	}

	public BinaryTree buiencodingdtree(LinkedList<charFreq> letters) {

		LinkedList<Node<charFreq>> leafs = new LinkedList<Node<charFreq>>();
		Node<charFreq> first;
		Node<charFreq> second;
		Node<charFreq> combine = null;
		Node n;

		for (int i = 0; i < letters.size(); i++)// for each charFrequency object
		{
			n = new Node(letters.get(i));// create new node charFreq object
			leafs.add(n);// add to link list of nodes
		}
		while (leafs.size() > 1)// wwhile list of nodes greater than one
		{
			first = leafs.get(0);// node 1 = first note in list
			leafs.remove(0);// remove from list
			second = leafs.get(0);// node to equals first element in list
			leafs.remove(0);// remove from list
			combine = new Node(new charFreq('\0', first.getElelemnt()
					.getCount() + second.getElelemnt().getCount()));
			combine.setLeft(first);// set left of new node to first
			combine.setRight(second);// set right of new node to second

			leafs.add(combine);// add new note to link list of nodes

		}
		BinaryTree encodingtree = new BinaryTree(leafs.get(0));
		return encodingtree;
	}

	public BinaryTree builddecodingtree(LinkedList<encodingChar> encodedletters) {  // Changed to be a linkedlist of encodingCharacters instead of charFreq
		Node<T> Top; // Changed to generic T node

		Top = new Node<T>(); // Changed to generic T node

		Node<T> n = null;
		String line = "";

		BinaryTree decodingtree = new BinaryTree(Top);

		for (int i = 0; i < encodedletters.size(); i++)// for each charFrequency
														// object
		{
			line = encodedletters.get(0).getEncodingnumber();
			for (int j = 0; j < line.length(); j++)

			{
				if (line.charAt(j) == '0') {
					if (current.getLeft() == null) {
						n = new Node<T>();// Changed to generic T node using the
											// default constructor

						current.setLeft(n);// here is where Java wants me to
											// change n to a generic
						current = current.getLeft();
					} else if (current.getRight() == null) {
						n = new Node<T>(); // Changed to generic T node using
											// the default constructor
						current.setRight(n); // fixed - here is where Java wants
												// me to change n to a generic
						current = current.getRight();
					}
				}

			}
		}

		if (current.getLeft() == null && current.getRight() == null) {
	
		}

		return decodingtree;
	}

	public StringBuilder createtable(Node<T> p, StringBuilder codes,
			BinaryTree encodingtree) {

		if (p != null) {
			codes.append('0');
			createtable(p.getLeft(), codes, encodingtree);
			codes.append(',');
			codes.deleteCharAt(codes.length() - 1);
			codes.append('1');
			createtable(p.getRight(), codes, encodingtree);
			codes.deleteCharAt(codes.length() - 1);

		}

		return codes;
	}
}
