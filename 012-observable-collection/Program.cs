// See https://aka.ms/new-console-template for more information
using System.Collections.ObjectModel;
using static System.Linq.Enumerable;

Console.WriteLine("ObservableCollection!");

var oc = new ObservableCollection<string>
{
    "a",
    "b"
};

for (int index = 1; index <= 5; index++)
{
    oc.Add(index.ToString());
}

void Printer() {
    foreach (var item in oc)
    {
        Console.WriteLine(item);
    }
}

oc.CollectionChanged += Oc_CollectionChanged;

void Oc_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
    Console.WriteLine("Oc_CollectionChanged...");
    Printer();
}

while (true)
{
    Console.Write("Add new item:");
    var newItem = Console.ReadLine();
    if (!string.IsNullOrEmpty(newItem))
    {
        oc.Add(newItem);
    }
}

