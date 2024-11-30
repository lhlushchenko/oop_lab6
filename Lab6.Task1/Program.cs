namespace Lab6.Task1;

using System;

public class Journal : IComparable<Journal>
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int PageCount { get; set; }
    public int SalesRating { get; set; } // Рейтинг продажів (1-10)

    public Journal(string title, decimal price, int pageCount, int salesRating)
    {
        Title = title;
        Price = price;
        PageCount = pageCount;
        SalesRating = salesRating;
    }

    // Порівняння журналів за ціною
    public int CompareTo(Journal other)
    {
        if (other == null) return 1; // Якщо інший журнал не задано, то поточний журнал більший.
        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"{Title} - Ціна: {Price:C}, Сторінки: {PageCount}, Рейтинг: {SalesRating}/10";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal[] journals = new Journal[]
        {
            new Journal("Журнал 1", 50.5m, 100, 8),
            new Journal("Журнал 2", 30.0m, 120, 7),
            new Journal("Журнал 3", 70.0m, 90, 9),
            new Journal("Журнал 4", 45.0m, 110, 6)
        };

        // Сортуємо журнали за ціною
        Array.Sort(journals);
        foreach (var journal in journals)
        {
            Console.WriteLine(journal);
        }
    }
}