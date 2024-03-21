using LR2_2;

internal class Program
{
    private static void Main(string[] args)
    {
        // Ввод знака операции с клавиатуры
        Console.Write("Введите оператор (+ или -): ");
        char operatorChar = Console.ReadKey().KeyChar;

        // Определение массива делегатов в зависимости от введенного оператора
        MyDelegate[] delegates;
        if (operatorChar == '+')
        {
            delegates = new MyDelegate[] { (x, y) => x + y };
        }
        else if (operatorChar == '-')
        {
            delegates = new MyDelegate[] { (x, y) => x - y };
        }
        else
        {
            Console.WriteLine("\nОшибка: Неподдерживаемый оператор. Введите + или -.");
            return;
        }

        // Ввод чисел с клавиатуры
        Console.Write("\nВведите первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        // Создание экземпляра класса и выполнение операций
        DelegateClass delegateClass = new DelegateClass();
        double result = delegateClass.PerformOperations(delegates, num1, num2);

        // Вывод результата
        Console.WriteLine($"Результат операции: {result}");
    }
}