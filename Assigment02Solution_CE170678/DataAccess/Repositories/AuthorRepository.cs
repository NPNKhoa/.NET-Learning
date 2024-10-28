using BusinessObject;

namespace DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public void AddAuthor(Author author)
       => DAOs.AuthorDAO.AddAuthor(author);

        public void DeleteAuthor(int id)
        => DAOs.AuthorDAO.DeleteAuthor(id);

        public List<Author> GetAllAuthors()
        => DAOs.AuthorDAO.GetAuthors();

        public Author GetAuthorById(int id)
        => DAOs.AuthorDAO.GetAuthorById(id);

        public void UpdateAuthor(int id, Author author)
        => DAOs.AuthorDAO.UpdateAuthor(id, author);
    }
}
