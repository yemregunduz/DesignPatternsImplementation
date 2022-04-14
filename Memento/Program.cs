using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new() { Isbn = "12345", Title = "Devlet", Author = "Platon" };
            book.ShowBook();
            CareTaker history = new();
            history.Memento = book.CreateUndo();

            book.Isbn = "54321";
            book.Title = "Sefiller";
            book.Author = "Victor Hugo";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);

            book.ShowBook();
        }
        class Book
        {
            private string _title;
            private string _isbn;
            private string _author;
            DateTime _lastUpdated;

            public string Title
            {
                get { return _title; }
                set 
                {
                    _title = value;
                    SetLastUpdated();
                }
            }
            public string Isbn
            {
                get { return _isbn; }
                set
                {
                    _isbn = value;
                    SetLastUpdated();
                }
            }
            public string Author
            {
                get { return _author; }
                set
                {
                    _author = value;
                    SetLastUpdated();
                }
            }

            private void SetLastUpdated()
            {
                _lastUpdated = DateTime.UtcNow;
            }
            public Memento CreateUndo()
            {
                return new Memento(_title,_author,_isbn,_lastUpdated);
            }
            public void RestoreFromUndo(Memento memento)
            {
                _title = memento.Title;
                _author = memento.Author;
                _isbn = memento.IsBn;
                _lastUpdated = memento.LastUpdated;
            }
            public void ShowBook()
            {
                Console.WriteLine("{0},{1},{2} Last Updated: {3}",_isbn,_author,_title,_lastUpdated);
            }
        }
        class Memento
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string IsBn { get; set; }
            public DateTime LastUpdated { get; set; }

            public Memento(string title,string author,string isbn,DateTime lastUpdated)
            {
                IsBn = isbn;
                Title = title;
                Author = author;
                LastUpdated = lastUpdated;
            }
        }
        class CareTaker
        {
            public Memento Memento { get; set; }
        }
    }
}
