using Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalindromeChallenge
{
    /// <summary>
    /// Palindrome Challenge 
    ///Goal
    ///Create a Console app that can identify if a word is a palindrome(the same forward and backwards like racecar). 
    ///Create an overload method to check an int to see if it is a palindrome.
    ///Ignore spacing, casing, and special characters when identifying palindromes. For instance, “stack cats” is a
    ///palindrome.
    /// </summary>
    public class PalindromeTester
    {
        public static bool IsPalindrome(string text)
        {
            try
            {
                // I have chosen to sanitize the input by using regular expressions since it can recognize patterns
                // which then can be removed.
                Regex rx = new Regex(@"\W", RegexOptions.IgnoreCase);

                // Finds all special characters
                // and then removes them
                MatchCollection matches = rx.Matches(text);
                string filteredtext = text;
                if (filteredtext.Contains('_'))
                {
                    filteredtext = filteredtext.Replace("_", "");
                }
                foreach (Match match in matches)
                {
                    filteredtext = filteredtext.Replace(match.ToString(), "");
                }

                // Makes all text lowercase and then makes a chararray based on filteredtext to make use of the Array's reverse method
                // then casts it to string which later can be compared with filteredtext
                filteredtext = filteredtext.ToLower();
                char[] filteredtextArray = filteredtext.ToCharArray();
                Array.Reverse(filteredtextArray);
                string reversefilteredtext = new string(filteredtextArray);

                // if they are the same then it returns true else false
                if (filteredtext == reversefilteredtext)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (RankException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentNullException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (Exception e)
            {
                SimpleLogger.Log(e);
                throw;
            }
        }

        public static bool IsPalindrome(int number)
        {
            try
            {
                // converts int to string
                string text = number.ToString();

                // Makes all text lowercase and then makes a chararray based on text to make use of the Array's reverse method
                // then casts it to string which later can be compared with text
                text = text.ToLower();
                char[] textArray = text.ToCharArray();
                Array.Reverse(textArray);
                string reversetext = new string(textArray);

                // if they are the same then it returns true else false
                if (text == reversetext)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (RankException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentNullException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (Exception e)
            {
                SimpleLogger.Log(e);
                throw;
            }
        }
    }    
}