using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Pig_Latin {
	public class Translator {
		public string Translate(string v) {
			string[] Words = SplitString(v);
			List<string> Return = new List<string>();

			foreach (string Word in Words) {
				string WordNew = CheckForVowels(Word);
				Return.Add(WordNew);
			}

			return String.Join(" ", Return.ToArray());
		}

		private string CheckForVowels(string Word) {
			char[] Vowels = { 'a', 'e', 'i', 'o', 'u'};
			char PrevLetter = Word[0];
			char[] Letters = Word.ToCharArray();
			string WordNew = Word;
			foreach (char Letter in Letters) {
				if (Vowels.Contains(Letter) && 
					!(Letter == 'u' && PrevLetter = 'q')) break;
				WordNew = MoveFirstLetterToEnd(WordNew);
				PrevLetter = Letter;
			}

				return WordNew + "ay";
			}

		private string[] SplitString(string Input) {
			char[] SplitChars = { ' ' };
			return Input.Split(SplitChars);
		}

		private string MoveFirstLetterToEnd(string Input) {
			char FirstLetter = Input[0];
			string WordCut;

			WordCut = Input.Substring(1);
			return WordCut + FirstLetter;
		}
	}
}