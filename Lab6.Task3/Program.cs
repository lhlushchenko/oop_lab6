namespace Lab6.Task3;

using System;
using System.Collections;
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

public class JournalCollection : IEnumerable<Journal>
{
    private List<Journal> _journals;

    public JournalCollection()
    {
        _journals = new List<Journal>();
    }

    public void Add(Journal journal)
    {
        _journals.Add(journal);
    }

    // Реалізація IEnumerable<Journal>
    public IEnumerator<Journal> GetEnumerator()
    {
        return _journals.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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
        JournalCollection journalCollection = new JournalCollection();
        journalCollection.Add(new Journal("Журнал 1", 50.5m, 100, 8));
        journalCollection.Add(new Journal("Журнал 2", 30.0m, 120, 7));
        journalCollection.Add(new Journal("Журнал 3", 70.0m, 90, 9));
        journalCollection.Add(new Journal("Журнал 4", 45.0m, 110, 6));

        // Сортуємо за рейтингом продажів
        var sortedJournals = new List<Journal>(journalCollection);
        sortedJournals.Sort(new JournalComparer(JournalComparer.ComparisonType.BySalesRating));

        // Виводимо на консоль
        Console.WriteLine("Журнали, впорядковані за рейтингом продажів:");
        foreach (var journal in sortedJournals)
        {
            Console.WriteLine(journal);
        }
    }
}