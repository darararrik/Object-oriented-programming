
internal class Program
{
    public delegate double MyDel(int[] a);

    private static void Main(string[] args)
    {
        MyDel AverageDelegate = delegate (int[] array)
        {
            double sum = 0;
            foreach (int i in array) 
            {
                sum += i;
            }
            return sum / array.Length;
        };
        MyDel myDelegate = new MyDel(AverageDelegate);
        int[] numbers = { 1, 2,3 };
        double res = myDelegate(numbers);
        Console.WriteLine(res);

    }


}


