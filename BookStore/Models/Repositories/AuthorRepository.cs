using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBookStoreRepository<Author>
    {
        private IList<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author(){Id = 1,FullName = "abdallah mahmoud"},
                new Author(){Id = 2,FullName = "sameh samir"},
                new Author(){Id = 3,FullName = "shady ryad"}
            };
        }
        public IList<Author> List()
        {
            return authors;
        }

        public Author Find(int id)
        {
            return authors.SingleOrDefault(a => a.Id == id);
        }

        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id) + 1;
            authors.Add(entity);
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;

        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();
        }
    }
}
