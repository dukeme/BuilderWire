using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParagraphChecker
{
    public class Paragraph
    {
        #region Private Properties
        //A = 97
        //Z = 122
        private const int FirstAlphaChar = 97;
        private const int LastAlphaChar = 122;
        private int _counter = 1;
        private int _currentChar = 0;
        private List<WordExistPerSentence> _wordExistPerSentence = new List<WordExistPerSentence>();
        private List<string> _basedWordList = new List<string>();
        private List<string> _invalidWordList = new List<string>();
        private int ascii = 0;

        #endregion

        #region Public Properties
        public List<string> InvalidWords
        {
            get { return _invalidWordList; }
        }

        #endregion

        public Paragraph()
        {
            ascii = FirstAlphaChar;
        }

        /// <summary>
        /// Parse paragraph
        /// </summary>
        public string Parse(string paragraph, string words)
        {
            string output = string.Empty;
            List<string> paragraphInWordList = new List<string>();
            List<string> paragraphInSentenceList = new List<string>();

            paragraphInWordList = Utility.SplitText(paragraph);
            paragraphInSentenceList = RebuildToSentence(paragraphInWordList);
            _basedWordList = Utility.SplitTextByChar(words, "\r\n");

            //e.g. (a. this {3:1,6,8})
            for (int x = 0; x < _basedWordList.Count; x++)
            {
                string wordExistsInSentence = string.Empty;

                for (int i = 0; i < paragraphInSentenceList.Count; i++)
                {
                    string word = _basedWordList[x];
                    int numberOfExistWordPerSentence = 0;

                    CountWordPerSentence(paragraphInSentenceList[i], word, ref numberOfExistWordPerSentence);

                    if (numberOfExistWordPerSentence > 0)
                    {
                        _wordExistPerSentence.Add(new WordExistPerSentence()
                        {
                            Word = word,
                            SentenceNumber = i + 1,
                            NumberOfExistWord = numberOfExistWordPerSentence
                        });
                    }
                }
            }

            output = GenerateOutput();

            return output;
        }

        /// <summary>
        /// Count word in a sentence.
        /// </summary>
        private void CountWordPerSentence(string sentence, string word, ref int numberOfExistWordPerSentence)
        {
            List<string> SentenceInWordList = new List<string>();
            sentence = sentence.Remove(sentence.Length - 1);
            SentenceInWordList = Utility.SplitText(sentence);

            for (int i = 0; i < SentenceInWordList.Count; i++)
            {
                if (SentenceInWordList[i].ToLower() == word) //Normal compare
                {
                    numberOfExistWordPerSentence++;
                }
                else if (SentenceInWordList[i].ToLower().RemoveSpecialCharacters() == word) //Word with special character
                {
                    numberOfExistWordPerSentence++;
                }
                else if (i == SentenceInWordList.Count - 1 &&
                    SentenceInWordList[i].ToLower().Remove(SentenceInWordList[i].Length - 1) == word) //Last word
                {
                    numberOfExistWordPerSentence++;
                }

                if (_basedWordList.Contains(SentenceInWordList[i].ToLower().RemoveSpecialCharacters()) == false
                    && _basedWordList.Contains(SentenceInWordList[i].ToLower().RemoveSpecialCharacters2()) == false
                    && _invalidWordList.Contains(SentenceInWordList[i].ToLower().RemoveSpecialCharacters2()) == false)
                    _invalidWordList.Add(SentenceInWordList[i].ToLower());

            }
        }

        /// <summary>
        /// Rebuild list of words to sentence.
        /// </summary>
        private List<string> RebuildToSentence(List<string> wordList)
        {
            List<string> sentenceList = new List<string>();
            string sentence = string.Empty;

            for (int i = 0; i < wordList.Count; i++)
            {
                if (wordList[i].Contains(".") == false)
                {
                    sentence += wordList[i] + " ";
                }
                else
                {
                    try
                    {
                        if (Utility.IsUpper(wordList[i]) == false
                           && Utility.IsUpper(wordList[i + 1]) == true) //End of the sentence
                        {
                            sentence += wordList[i].Replace("\r\n", string.Empty) + " ";
                            sentenceList.Add(sentence);
                            sentence = string.Empty;
                        }
                        else if ((i + 1) == wordList.Count) // Last word in the paragraph
                        {
                            sentence += wordList[i].Replace("\r\n", string.Empty) + " ";
                            sentenceList.Add(sentence);
                            sentence = string.Empty;
                        }
                        else
                        {
                            sentence += wordList[i].Replace("\r\n", string.Empty) + " ";
                        }
                    }
                    catch
                    {
                        sentence += wordList[i].Replace("\r\n", string.Empty) + " ";
                        sentenceList.Add(sentence);
                        sentence = string.Empty;
                    }
                }
            }

            return sentenceList;
        }

        /// <summary>
        /// Generate output to export.
        /// </summary>
        private string GenerateOutput()
        {
            //e.g. (a. this {3:1,6,8})
            StringBuilder sb = new StringBuilder();

            for (int x = 0; x < _basedWordList.Count; x++)
            {
                string str = string.Empty;
                string prefix = GeneratePrefix();

                var result = _wordExistPerSentence.Where(w => w.Word == _basedWordList[x].ToLower()).ToList();


                foreach (WordExistPerSentence WordExistPerSentence in result)
                {
                    for (int i = 1; i <= WordExistPerSentence.NumberOfExistWord; i++)
                        str += WordExistPerSentence.SentenceNumber.ToString() + ",";
                }

                if (string.IsNullOrEmpty(str) == false)
                {
                    str = str.Remove(str.Length - 1);
                    str = string.Format("{0}. {1} {{{2}:{3}}}", prefix, _basedWordList[x].ToLower(), result.Sum(o => o.NumberOfExistWord).ToString(), str);
                    sb.AppendLine(str);
                }

            }

            return sb.ToString();
        }

        /// <summary>
        /// Generate prefix
        /// </summary>
        private string GeneratePrefix()
        {
            string prefix = string.Empty;

            for (int i = 1; i <= _counter; i++)
            {
                prefix += ((char)ascii).ToString();
            }

            if (_currentChar == LastAlphaChar)
            {
                _counter++;
                ascii = FirstAlphaChar;
            }
            else
            {
                ascii++;
            }

            _currentChar = ascii;

            return prefix;

        }
    }
}
