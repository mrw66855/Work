import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;



public class encodingChar implements Comparable
{
private char character;
 private String encodingnumber;

 public encodingChar(char character, String encodingnumber) {
		setCharacter(character);
		setEncodingnumber(encodingnumber);
	}
 public encodingChar(char character) {
		setCharacter(character);
	
	}

public void setCharacter(char incharacter) {
	character = incharacter;
}

public char getCharacter() {
	return character;
}
/**
 * @return the encodingnumber
 */
public String getEncodingnumber() {
	return encodingnumber;
}

/**
 * @param encodingnumber the encodingnumber to set
 */
public void setEncodingnumber(String inencodingnumber) {
	 encodingnumber=inencodingnumber;
}



public boolean equals(Object o)
{
boolean equal = false; 
encodingChar ec = new encodingChar(character, encodingnumber);

ec = (encodingChar)o;	
if( this.compareTo(ec) == 0 )
	equal = true;

return equal;

}
public int compareTo(Object o) {
	
	encodingChar ce = new encodingChar(character, encodingnumber);
	int compare = 0;  // default to equal
	
	ce = (encodingChar)o;
	
	if( ce.getCharacter() > this.character)
		compare = -1;
	else if( ce.getCharacter() == this.character)
		compare = 0;
	else if( ce.getCharacter() < this.character)
		compare = 1;	
	
	return compare;
}


public LinkedList<encodingChar> Sort( LinkedList<encodingChar> encodedletterss) 
{
	encodingChar[]frequency = new encodingChar[encodedletterss.size()];
    encodedletterss.toArray(frequency);
    
    boolean done= true; // stop when a pass causes no change
    for(int i = frequency.length; i > 0; i--)
    {
         done = true;
         for(int j = 1; j < i; j++)
         {
              if(frequency[j].getCharacter()<frequency[j - 1].getCharacter()) 
              {
                   swap(frequency, j, j - 1);
                   done = false;
              }
         }
        }
    if (done)
    {
    List<encodingChar> storage = Arrays.asList(frequency);
    encodedletterss =new LinkedList<encodingChar>(storage);
      }
    return encodedletterss;
      }

      public void swap(encodingChar[]frequency, int one, int two) {
        encodingChar temp = frequency[one];
        frequency[one] = frequency[two];
        frequency[two] = temp;
        
      }
public String binaryToString() {
	String s = String.format("    %1c      %2d", character,  encodingnumber);
	
	return s;
}

}
