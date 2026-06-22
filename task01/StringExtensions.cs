using System;
using System.Security.Cryptography;
namespace task01;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        string new_str = "";
        foreach (char el in input)
        {
            if(!char.IsPunctuation(el) && !char.IsWhiteSpace(el)) new_str += char.ToLower(el);
        }
        if (new_str.Length == 0) return false;
        char[] arr = new_str.ToCharArray();
        Array.Reverse(arr);
        string reverse_str = new string(arr);
        return new_str == reverse_str;
    }
}
