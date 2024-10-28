using BusinessObject;

namespace DataAccess.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(int id, Author author);
        void DeleteAuthor(int id);

    }
}
