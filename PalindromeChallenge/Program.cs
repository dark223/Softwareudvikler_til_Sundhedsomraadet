using Logger;
namespace PalindromeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("string palindrome");
            Console.WriteLine("h.un d: " +PalindromeTester.IsPalindrome("h.un d"));
            Console.WriteLine("ot.to: " + PalindromeTester.IsPalindrome("ot.to"));
            Console.WriteLine("o.tt1o: " + PalindromeTester.IsPalindrome("o.tt1o"));
            Console.WriteLine("o.t1t.o: " + PalindromeTester.IsPalindrome("o.t1t.o"));
            Console.WriteLine("o_t11t.o: " + PalindromeTester.IsPalindrome("o_t11t.o"));
            Console.WriteLine("\nint palindrome");
            Console.WriteLine("112: " + PalindromeTester.IsPalindrome(112));
            Console.WriteLine("111: " + PalindromeTester.IsPalindrome(111));
            Console.WriteLine("1111: " + PalindromeTester.IsPalindrome(1111));
            Console.WriteLine("1121: " + PalindromeTester.IsPalindrome(1121));
        }
    }
}