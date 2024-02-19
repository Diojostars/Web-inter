using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Демонстрація роботи з класом Thread і Async-Await
        RunThreadDemo();
        RunThreadWithParametersDemo();
        RunThreadWithReturnValueDemo();

        RunAsyncAwaitDemo();
        RunAsyncAwaitWithReturnValueDemo();
        RunMultipleAsyncAwaitDemo();

        Console.ReadLine();
    }

    // Перший метод - демонстрація класу Thread
    static void RunThreadDemo()
    {
        Console.WriteLine("Початок роботи з потоками.");

        Thread thread = new Thread(() => Console.WriteLine("Виконання в потоці."));
        thread.Start();
        thread.Join();

        Console.WriteLine("Завершення роботи з потоками.\n");
    }

    // Додатковий метод для демонстрації передачі параметрів у Thread
    static void RunThreadWithParametersDemo()
    {
        Console.WriteLine("Початок роботи з потоками з параметрами.");

        Thread thread = new Thread(ThreadMethodWithParameters);
        thread.Start("Потік з параметром");
        thread.Join();

        Console.WriteLine("Завершення роботи з потоками з параметрами.\n");
    }

    static void ThreadMethodWithParameters(object obj)
    {
        Console.WriteLine($"{obj}");
    }

    // Метод для демонстрації повернення значення з потоку
    static void RunThreadWithReturnValueDemo()
    {
        Console.WriteLine("Початок роботи потоку з поверненням значення.");

        int result = 0;
        Thread thread = new Thread(() => { result = CalculateResult(); });
        thread.Start();
        thread.Join();

        Console.WriteLine($"Результат роботи потоку: {result}\n");
    }

    static int CalculateResult()
    {
        return 123; // Приклад обчислення
    }

    // Другий метод - демонстрація Async - Await
    static void RunAsyncAwaitDemo()
    {
        Console.WriteLine("Початок роботи з Async - Await.");

        Task task = AsyncMethod();
        task.Wait();

        Console.WriteLine("Завершення роботи з Async - Await.\n");
    }

    static async Task AsyncMethod()
    {
        Console.WriteLine("Асинхронний метод виконується.");
        await Task.Delay(1000); // Імітація асинхронної операції
    }

    // Метод для демонстрації Async - Await з поверненням значення
    static void RunAsyncAwaitWithReturnValueDemo()
    {
        Console.WriteLine("Початок асинхронної роботи з поверненням значення.");

        Task<int> task = AsyncMethodWithReturnValue();
        Console.WriteLine($"Результат асинхронної роботи: {task.Result}\n");
    }

    static async Task<int> AsyncMethodWithReturnValue()
    {
        await Task.Delay(500); // Імітація асинхронної операції
        return 456; // Приклад повернення значення
    }

    // Метод для демонстрації виконання декількох асинхронних методів
    static void RunMultipleAsyncAwaitDemo()
    {
        Console.WriteLine("Початок одночасного асинхронного виконання.");

        Task task1 = AsyncMethod();
        Task task2 = AsyncMethodWithReturnValue();

        Task.WaitAll(task1, task2);

        Console.WriteLine("Завершення одночасного асинхронного виконання.\n");
    }
}
