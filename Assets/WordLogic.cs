using System.Collections;

public class WordLogic {

	// compute the distance between two words, as spec'd by the rules of this game
	public int GameDistance( string A, string B)
	{
		if(A.Length != B.Length)
			return -1;  // we do not consider unequal length words
		
		// distance should be case insensitive
		A = A.ToLower();
		B = B.ToLower();
		
		int count = 0;
		for( int i = 0; i<A.Length; i++)
		{
			if(A[i] != B[i])
				count++;
		}
		
		return count;
	}
		
}
