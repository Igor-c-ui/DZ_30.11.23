using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Упр 12.1
            BankAccount client1 = new BankAccount(43546, BankAccount.Type_bank_account.Сберегательный);
            BankAccount client2 = new BankAccount(34567, BankAccount.Type_bank_account.Текущий);

            Console.WriteLine(client1.ToString(), client2.ToString());
            Console.WriteLine(client1 == client2);

            //Упр 12.2
            RationalNumber n1 = new RationalNumber(23, 7);
            RationalNumber n2 = new RationalNumber(23, 7);
            Console.WriteLine(n1.ToString(), n2.ToString());
            Console.WriteLine($"Равенство: {n1 == n2}");
            Console.WriteLine($"Неравенство: {n1 != n2}");
            Console.WriteLine($"Меньше: {n1 < n2}");
            Console.WriteLine($"Меньше либо равно: {n1 <= n2}");

            Console.WriteLine($"Сложение: {n1 + n2}");
            Console.WriteLine($"Вычитание: {n1 - n2}");
            Console.WriteLine($"Умножение: {n1 * n2}");
            Console.WriteLine($"Деление: {n1 / n2}");

            //ДЗ 12.1
            ComplexNumber x = new ComplexNumber(2, 5);
            ComplexNumber y = new ComplexNumber(34, 7);

            Console.WriteLine($"x = {x.ToString()},y = {y.ToString()}");
            Console.WriteLine($"x+y = {x+y}, x*y = {x * y}, x-y = {x - y}");
            Console.WriteLine($"x==y: {x==y}");


            //ДЗ 12.2
            Book book1 = new Book("Книга", "Автор", "Издательство");
            Book book2 = new Book("нигаК", "вторА", "Предательство");
            Book book3 = new Book("агинК", "ротвА", "Издевательство");

            List<Book> bookList = new List<Book> { book3, book1, book2 };

            BookContainer bookContainer = new BookContainer(bookList);

            //Делегат для сравнения книг по названию
            Comparison<Book> titleComparison = (bookA, bookB) => bookA.Title.CompareTo(bookB.Title);

            // Сортировка книг с использованием делегата
            bookContainer.SortBooks(titleComparison);

            // Выводим отсортированные книги
            Console.WriteLine("Отсортированные книги:");
            bookContainer.DisplayBooks();
        }
    }
}
