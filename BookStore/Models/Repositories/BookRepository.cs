using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        private List<Book> books;

        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "csharp lang" ,
                    Description = "no dis" ,
                    ImgaUrl = "csharp.png",
                    Author = new Author {Id = 2}
                },
                new Book()
                {
                    Id = 2,
                    Title = "java lang" ,
                    Description = "no dis" ,
                    ImgaUrl = "java.png",
                    Author = new Author {Id = 3}
                },
                new Book()
                {
                    Id = 3,
                    Title = "python lang" ,
                    Description = "no dis" ,
                    ImgaUrl = "python.png",
                    Author = new Author {Id = 1}
                }
            };
        }
        public IList<Book> List()
        {
            return books;
        }

        public Book Find(int id)
        {
            return books.SingleOrDefault(b => b.Id == id);
        }

        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Update(int id, Book newBook)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            book.ImgaUrl = newBook.ImgaUrl;
        }

        public void Delete(int id)
        {
            //var book = Find(entity.Id);
            var book = books.SingleOrDefault(b => b.Id == id);
            books.Remove(book);
        }

        public List<Book> Search(string term)
        {
            return books.Where(b => b.Title.Contains(term)
            ||b.Description.Contains(term)
            ||b.Author.FullName.Contains(term)).ToList();
        }
    }
}
