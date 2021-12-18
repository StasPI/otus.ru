namespace Implementation
{
    public static class MyExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> getParameter) where T : class
        {
            if (!collection.Any())
            {
                throw new ArgumentException($"Collection is empty!");
            }

            T tMax = collection.First();
            foreach (var item in collection)
            {
                if (getParameter(item) > getParameter(tMax))
                {
                    tMax = item;
                }
            }
            return tMax;
        }
    }
}