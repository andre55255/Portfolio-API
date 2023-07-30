namespace Portfolio.Helpers
{
    public static class StatcMethods
    {
        public static string GetPlace(this object obj)
        {
            return obj.GetType().ToString();
        }
    }
}
