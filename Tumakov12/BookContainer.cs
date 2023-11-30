using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov12
{
    internal class BookContainer
    {
        private List<Book> books;

        public void SortBooks(Comparison<Book> comparisonDelegate)
        {
            books.Sort(comparisonDelegate);
        }

        public void DisplayBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publisher: {book.Publisher}");
            }
        }
        public BookContainer(List<Book> books)
        {
            this.books = books;
        }
    }
}
