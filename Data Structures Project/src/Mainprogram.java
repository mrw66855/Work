import java.util.*;
import java.io.*;
public class Mainprogram {
	static Scanner console = new Scanner (System.in);
public static void main(String[] args) {
		charFreq character = new charFreq('\0',0);
		encodingChar encodedcharacter = new encodingChar('\0',"");
		LinkedList<charFreq> letters = new LinkedList<charFreq>();
		LinkedList<encodingChar> encodedletters = new LinkedList<encodingChar> ();
		int index = 0;
		int encodedindex = 0;
		boolean available=false ;
		boolean exist = false;
		BinaryTree<encodingChar> bt = new BinaryTree<encodingChar>();  // Changed to hold encondingChar
		Node p= new Node ();
		fileoperations fo= new fileoperations();
		StringBuilder codes =new StringBuilder();
		String uncompressfilename;
		String compressfilename;
		System.out.println ("welcome to compression and decompression program");
		System.out.println ("compression");
	do 
	{
		System.out.println ("please enter the name of the file you want to compress,without spaces");
		compressfilename=console.next();
		
	}
	while(!compressfilename.equals("finalproject.txt"));
	compressfilename =  "\\"+ compressfilename;
	File f = new File(compressfilename);
	if (f.exists())
	{
		
		System.out.println ("file being compressed");
fo.readfile(character, available, letters, index);
character.Sort(letters);
fo.writefile(letters);
bt.buiencodingdtree(letters);
bt.createtable(p, codes, bt);
fo.writetable(codes);
fo.compression(encodedcharacter, exist, encodedindex, encodedletters);
System.out.println ("file has been compress and is located at the vocation specified above");
	}
	else 
	{
		System.out.println ("Sorry, the file or path doesn't exist. Please restart the program and try again.");
	}
	System.out.println ("decompression");
	do 
	{
		System.out.println ("please enter the name of the file you want to uncompress,without spaces");
		uncompressfilename=console.next();	
	}
	while(!uncompressfilename.equals("uncompressed.txt"));
	uncompressfilename =  "\\"+ uncompressfilename;
	File f2 = new File(uncompressfilename);
	if (f2.exists())
	{
	System.out.println ("file being uncompressed");	
fo.readtable(encodedcharacter, encodedletters);
bt.builddecodingtree(encodedletters);
//fo.decompression(p, bt);

System.out.println ("file has been uncompressed and is located at the vocation specified above");
	}
	else 
	{
		System.out.println ("Sorry, the file or path doesn't exist. Please restart the program and try again.");
	}
}
}