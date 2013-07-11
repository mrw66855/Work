import java.util.*;



public class charFreq implements Comparable
{
private char character;
 private long count;

 public charFreq(char character, long count) {
		setCharacter(character);
		setCount(count);
	}
 public charFreq(char character) {
		setCharacter(character);
 }

public void setCharacter(char incharacter) {
	character = incharacter;
}

public char getCharacter() {
	return character;
}
public void setCount(long incount) {
	if (incount < 0)
		incount = 0;

	count = incount;
}
public long getCount() {
	return count;
}
public void increment ()
{
	count++;
}


public boolean equals(Object o)
{
boolean equal = false; 
charFreq cf = new charFreq(character, count);

cf = (charFreq)o;	
if( this.compareTo(cf) == 0 )
	equal = true;

return equal;

}
public int compareTo(Object o) {
	
	charFreq cf = new charFreq(character, count);
	int compare = 0;  // default to equal
	
	cf = (charFreq)o;
	
	if( cf.getCharacter() > this.character)
		compare = -1;
	else if( cf.getCharacter() == this.character)
		compare = 0;
	else if( cf.getCharacter() < this.character)
		compare = 1;	
	
	return compare;
}


public LinkedList<charFreq> Sort( LinkedList<charFreq> letters) 
{
	charFreq[]frequency = new charFreq[letters.size()];
    letters.toArray(frequency);
    
    boolean done= true; // stop when a pass causes no change
    for(int i = frequency.length; i > 0; i--)
    {
         done = true;
         for(int j = 1; j < i; j++)
         {
              if(frequency[j].getCount()<frequency[j - 1].getCount()) 
              {
                   swap(frequency, j, j - 1);
                   done = false;
              }
         }
        }
    if (done)
    {
    List<charFreq> storage = Arrays.asList(frequency);
    letters =new LinkedList<charFreq>(storage);
      }
    return letters;
      }

      public void swap(charFreq[]frequency, int one, int two) {
        charFreq temp = frequency[one];
        frequency[one] = frequency[two];
        frequency[two] = temp;
        
      }
public String frequencyToString() {
	String s = String.format("    %1c      %2d", character,  count);
	
	return s;
}

}
