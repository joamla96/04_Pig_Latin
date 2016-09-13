using System;
using System.Collections.Generic;

namespace _04_Pig_Latin {

	/*
	 * Translator Class
	 * Step 1.....:	Split input into array for each word
	 * Translate():	For each word, do step 2
	 * 
	 * Step 2.........:	Split word into array for each letter
	 * CheckForVowls():	Check each letter. If not Vowl (or special case) do step 3
	 *					If letter is vowl (and not special case) add "ay" and return;
	 * 
	 * Step 3................:	Save the first Letter
	 * MoveFirstLetterToEnd():	Cut the first letter away
	 *							Stich first letter back on end and return;
	 */

	public class Translator {							// Main Method called
		public string Translate(string v) {
			string[] Words = SplitString(v);			// Split string, to deal with multiple words
			List<string> Return = new List<string>();	// Init. list that we're gonna stich together

			foreach (string Word in Words) {			// Foreach word, 
				string WordNew = CheckForVowels(Word);	// Push word to CheckForVowls function
				Return.Add(WordNew);					// Add it to our return list.
			}

			return String.Join(" ", Return.ToArray());	// Converts return LIST to ARRAY, and joins elements with space
		}

		// This methods deals with checking wether a letter needs to be moved to the back.
		private string CheckForVowels(string Word) {
			char[] Vowels = { 'a', 'e', 'i', 'o', 'u'};	// Define an array of vowls
			char PrevLetter = Word[0];					// Init. the previous letter, and populate with first letter to avoid NPE
			char[] Letters = Word.ToCharArray();		// Convert our Word into a Char array, for easy looping
			string WordNew = Word;                      // Our final word

			foreach (char Letter in Letters) {
				if (CharArrayContains(Letter, Vowels) &&			// If Letter is a vovwl && !(special qu case)
					!(Letter == 'u' && PrevLetter == 'q')) break;	// Break; Because we're done with this word.
				WordNew = MoveFirstLetterToEnd(WordNew);	// Call the move letter function.
				PrevLetter = Letter;					// Update PrevLetter used in special qu case checker.
			}

			return WordNew + "ay";
		}

		// This method moves the first letter to the back
		private string MoveFirstLetterToEnd(string Input) {
			char FirstLetter = Input[0];	// Take and save the first letter
			string WordCut;					// Init. string for cut word.

			WordCut = Input.Substring(1);	// Cut word, removing the first letter
			return WordCut + FirstLetter;	// Add the first letter to the back of the word.
		}

		// Split a string into array of words
		private string[] SplitString(string Input) {
			char[] SplitChars = { ' ' };
			return Input.Split(SplitChars);
		}

		// Custom Contains Array because no linq eh.
		private bool CharArrayContains(char Needle, char[] Haystack) {
			bool Contains = false;
			foreach(char Hay in Haystack) {
				if(Hay == Needle) {
					Contains = true;
				}
			}
			return Contains;
		}
	}
}