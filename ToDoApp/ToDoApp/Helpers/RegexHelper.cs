using System.Text.RegularExpressions;

namespace ToDoApp.Helpers
{
    public static class RegexHelper
    {
        public static bool CheckEmailRegex(string emailAddress)
        {
            string patternStrict = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(emailAddress);
            return isStrictMatch;
        }
    }
}
