// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Concurrent;

Console.WriteLine("ConcurrentBag! (namespace System.Collections.Concurrent)");

ConcurrentBag<int> bag = new ConcurrentBag<int>();


Task t1 = Task.Factory.StartNew(() =>
{
    Random random = new Random();
    for (int i = 1; i < 11; ++i)
    {
        Console.WriteLine($"[Task1] (1 to 10) Add {i}");
        bag.Add(i);
        Thread.Sleep(random.Next(20, 300));
    }
});


Task t2 = Task.Factory.StartNew(() =>
{
    Random random = new Random();
    for (int i = 11; i < 21; ++i)
    {
        Console.WriteLine($"[Task2] (11 to 20) Add {i}");
        bag.Add(i);
        Thread.Sleep(random.Next(20, 300));
    }
});


Task t3 = Task.Factory.StartNew(() =>
{
    Random random = new Random();
    for (int i = 21; i < 31; ++i)
    {
        Console.WriteLine($"[Task3] (21 to 30) Add {i}");
        bag.Add(i);
        Thread.Sleep(random.Next(20, 300));
    }
});



Task t4 = Task.Factory.StartNew(() =>
{
    Random random = new Random();
    int i = 0;
    while (i != 4)
    {
        foreach (var item in bag)
        {
            Console.WriteLine(i + "-" + item);
            Thread.Sleep(random.Next(20, 300));
        }
        i++;
        Thread.Sleep(random.Next(20, 300));
    }

});


Task.WaitAll(t1, t2, t3, t4);