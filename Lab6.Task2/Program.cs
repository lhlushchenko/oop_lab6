namespace Lab6.Task2;

using System;
using System.Collections.Generic;

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

public class JournalComparer : IComparer<Journal>
{
    public enum ComparisonType
    {
        ByPageCount,
        BySalesRating
    }

    private ComparisonType _comparisonType;

    public JournalComparer(ComparisonType comparisonType)
    {
        _comparisonType = comparisonType;
    }

    // Порівняння журналів за кількістю сторінок або рейтингом продажів
    public int Compare(Journal x, Journal y)
    {
        if (x == null || y == null) return 0;

        switch (_comparisonType)
        {
            case ComparisonType.ByPageCount:
                return x.PageCount.CompareTo(y.PageCount);
            case ComparisonType.BySalesRating:
                return x.SalesRating.CompareTo(y.SalesRating);
            default:
                throw new InvalidOperationException("Невірний тип порівняння.");
        }
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
        
        // Сортуємо за кількістю сторінок
        Array.Sort(journals, new JournalComparer(JournalComparer.ComparisonType.ByPageCount));
        Console.WriteLine("Сортування за кількістю сторінок:");
        foreach (var journal in journals)
        {
            Console.WriteLine(journal);
        }

        // Сортуємо за рейтингом продажів
        Array.Sort(journals, new JournalComparer(JournalComparer.ComparisonType.BySalesRating));
        Console.WriteLine("\nСортування за рейтингом продажів:");
        foreach (var journal in journals)
        {
            Console.WriteLine(journal);
        }

    }
}