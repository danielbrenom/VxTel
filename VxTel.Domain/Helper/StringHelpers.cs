namespace VxTel.Domain.Helper
{
    public static class StringHelpers
    {
        public static bool EmptyNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        }
    }
}