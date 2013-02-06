using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Display : MonoBehaviour {
	
	public List<string> entry;	// the entry of what to display on the board 
	public bool showBlank;		// if true, we'll show a blank between the last and next to last entry
	public string newWord;		// when inserting a new word, this is where we store it before it gets inserted
	public int wordLength;		// the length of the words in this entry
	private WordLogic wordlogic;
	
	// Use this for initialization
	void Start () {
		wordlogic = new WordLogic();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{		
		GUILayout.BeginArea(new Rect( Screen.width*0.1f, Screen.height*0.1f, Screen.width*0.8f, Screen.height*0.8f));	// big box in the middle of the screen
		
		// show all the entries except the last one, because we have to check if we're showing a blank or not
		for( int i = 0; i<entry.Count-1; i++)
		{
			if(i==0)
				GUILayout.Label(entry[i]);	// the first entry cannot be edited
			else
				GUILayout.Label(entry[i]);	// temporarily making earlier entries uneditable
				//entry[i] = GUILayout.TextField(entry[i], wordLength);	// a text field prepopulated with whatever the entry is
		}
		
		if( showBlank)
		{
			// capture the Enter/Return key so we can do a submit action
			if (Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return)) //http://forum.unity3d.com/threads/69361-GUI.TextField-submission-via-quot-return-quot-key...?p=585583&viewfull=1#post585583
			{	
				if( wordlogic.GameDistance(newWord, entry[entry.Count-2]) == 1) // check to see this is a valid entry
				{
					entry.Insert(entry.Count-1, newWord);
					newWord = "";
					Debug.Log("Word Accepted!");
					
					// check to see if that was game over
					if( wordlogic.GameDistance(entry[entry.Count-1], entry[entry.Count-2]) == 1)
					{
						Debug.Log("Yay! You won! Score = " + (entry.Count-1));
						showBlank = false;
					}
				} else 
				{
					Debug.Log("Word Denied.");
					newWord = "";
				}
				//GUI.FocusControl("New Word Entry");
			}
			//GUI.SetNextControlName( "New Word Entry"); 
			newWord = GUILayout.TextField( newWord, wordLength);	// a blank entry
		}
			
		GUILayout.Label(entry[entry.Count-1]);	// the un-editable last entry
		
		GUILayout.EndArea();
	}
			
}
