import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.*;

public class fileoperations 
{
public void readfile (charFreq character, boolean available,LinkedList<charFreq> letters, int index ) 
{
try {
	  

		String path = System.getProperty("user.dir");

		BufferedReader in = new BufferedReader(new FileReader(path+ File.separatorChar + "bin" + File.separatorChar+ "finalproject.txt"));

		int value = in.read();
		
		while (value != -1) 
		{
			 character = new charFreq( (char) value,1) ;
			available = letters.contains(character);
			if( available ==true)  
			{ 
				 index = letters.indexOf(character);
				character = letters.get(index);
				character.increment();
			} 
			else
			{
				letters.add(character);
			}	
			value = in.read();	
		}
		in.close();
}
		catch (FileNotFoundException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

 catch (IOException e) {

	// TODO Auto-generated catch block

	e.printStackTrace();

}
}
  public void writefile(LinkedList<charFreq> letters)
{
try {
String path = System.getProperty("user.dir");

	PrintWriter out = new PrintWriter(path + File.separatorChar + "bin"+ File.separatorChar + "frequencyresults.txt");
			out.printf("%s %2s","Character", "Count");
			out.println();

			for( int i = 0; i < letters.size(); i++)
			{
				out.println(letters.get(i).frequencyToString());
			}		
			out.flush();

			out.close();
System.out.println("File has been written to:" + path+ File.separatorChar + "bin" + File.separatorChar+ "frequencyresults.txt");
}
catch (FileNotFoundException e) 
{
	// TODO Auto-generated catch block
	e.printStackTrace();
}
catch (IOException e)
{
	// TODO Auto-generated catch block
e.printStackTrace();
}

}
  public void  writetable (StringBuilder codes)
  
  {
String data = codes.toString();   
	  
 String[]info = data.split(",");  
 encodingChar[] binary = new encodingChar [info.length];
  try {
  String path = System.getProperty("user.dir");

  	PrintWriter out = new PrintWriter(path + File.separatorChar + "bin"+ File.separatorChar + "binarytable.txt");
  			out.printf("%s %2s","Character", "Code");
  			out.println();

  			for( int i = 0; i < binary.length; i++)
  			{
  				out.println(binary[i].binaryToString());
  			    
  			}		
  			out.flush();

  			out.close();
  System.out.println("File has been written to:" + path+ File.separatorChar + "bin" + File.separatorChar+ "binarytable.txt");
  }
  catch (FileNotFoundException e) 
  {
  	// TODO Auto-generated catch block
  	e.printStackTrace();
  }
  catch (IOException e)
  {
  	// TODO Auto-generated catch block
  e.printStackTrace();
  }

  }

 public void readtable (encodingChar encodedcharacter, LinkedList<encodingChar> encodedletters )
 {
	 
	 try {

			String path = System.getProperty("user.dir");

			BufferedReader in = new BufferedReader(new FileReader(path+ File.separatorChar + "bin" + File.separatorChar+ "binarytable.txt"));
char character = '\0';
String Number="";
String i = "";
			int value = in.read();
			
			
			while (value != -1) 
			{
				if (Character.isLetter(value))
				{
				character = (char)value;	
				}
				else 
					
				{
					 i = Integer.toString(value);
					Number=Number+i;
				}
				 encodedcharacter = new encodingChar(character, Number);
				 encodedletters.add(encodedcharacter);
				 value = in.read();	
		}
		in.close();
		}
		catch (FileNotFoundException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

catch (IOException e) {

	// TODO Auto-generated catch block

	e.printStackTrace();
}
 }
 public String frequencyToString(char character, long  count) {
		String s = String.format("    %1c      %2d", character,  count);
		
		return s;
	}
 public String binaryToString(char character, String encodingnumber) {
		String s = String.format("    %1c      %2d", character,  encodingnumber);
		
		return s;
	}
 public void compression (encodingChar encodedcharacter, boolean exist, int encodedindex, LinkedList<encodingChar> encodedletters )
 {

	 int j=7;
	 String encoding;
	byte b=0;
	int power = 0;
	String extra;//leftover of encoding string

	 try {

	 		String path = System.getProperty("user.dir");

	 		BufferedReader in = new BufferedReader(new FileReader(path+ File.separatorChar + "bin" + File.separatorChar+ "finalproject.txt"));

	 		int value = in.read();//read  character from file

	 		while (value != -1)
	 		{
	 			char original=(char)value;

	 			exist = encodedletters.contains(original);//check to see if  character is an link lists for the encoding table
	 			if( exist ==true)  //if it is
	 			{
	 				 encodedindex =encodedletters.indexOf(original);//
	 			encodedcharacter = encodedletters.get(encodedindex);//gget the object out ofthe list
	 			encoding =encodedcharacter.getEncodingnumber();//get the encoding string
	 			for (int i=0;i <encoding.length();i++)//for the length of the encoding string
	 			{

					while(j >=0)// is greater than zero   // Count from 7 down to 0 by 1
					{
		if (encoding.charAt(i)=='1')
	 						power = (int) Math.pow(2, j);
	 					{
	 			b =(byte) (	b| power);//set bit  use OR (|) instead of AND (&)
j--;
	 					}

					}

					if (j<0)  // Change this to less than zero...-1 use a separate index variable for the byte and the encoding index
					{
						PrintWriter out = new PrintWriter(path + File.separatorChar + "bin"+ File.separatorChar + "compressed.txt");
						out.print(b);
						out.flush();

						out.close();
						b=0;
						j=7;
						 value = in.read();	
					
					in.close();

						//need help here. Wants to do the following.
						//	subject eight characters from the string
						//if the length of the current string is zero then
							//reset the bite equal zero
							//read next encoding number from file
							///else if the length of the current string is greater than zero add it to the next string from file.
							//Reset the bite to equal zero
							//read next encoding number from file


					}
	 			}
	 			}
	 			}
	 	
System.out.println("File has been written to:" + path+ File.separatorChar + "bin" + File.separatorChar+ "compressed.txt");

	 		}
	 			catch (FileNotFoundException e)
	 			{
	 				// TODO Auto-generated catch block
	 				e.printStackTrace();
	 			}

	 	catch (IOException e) {

	 		// TODO Auto-generated catch block

	 		e.printStackTrace();
	 	}
	 	 }
}


 
