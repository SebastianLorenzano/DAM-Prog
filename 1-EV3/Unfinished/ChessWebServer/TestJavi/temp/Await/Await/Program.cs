namespace Await
{
    internal class Program
    {
        public static async Task<int> Function(int n)
        {
            int ret = 0;
            for (int i = 0; i < n; i++)
                ret += i;
            return ret;
        }

        static async void Main(string[] args)
        {
            List<Task<int>> list = new();
            for (int i = 0; i < 100; i++)
            {
                Task<int> n = Function(1000);
                list.Add(n);
            }
            // ...
            // ...
            // ...
            // ...
            // ...
            await Task.WhenAll(list);
        }
    }
}