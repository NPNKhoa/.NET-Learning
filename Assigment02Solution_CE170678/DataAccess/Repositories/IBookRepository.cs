using BusinessObject;

namespace DataAccess.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        List<Publisher> GetAllPublishers();
        List<Author> GetAllAuthors();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(int id, Book book);
        void DeleteBook(int id);
    }
}
