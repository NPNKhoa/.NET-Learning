using BusinessObject;

namespace DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        => DAOs.BookDAO.AddBook(book);

        public void DeleteBook(int id)
        => DAOs.BookDAO.DeleteBook(id);

        public List<Author> GetAllAuthors()
        => DAOs.AuthorDAO.GetAuthors();

        public List<Book> GetAllBooks()
        => DAOs.BookDAO.GetBooks();

        public List<Publisher> GetAllPublishers()
        => DAOs.PublisherDAO.GetPublishers();

        public Book GetBookById(int id)
        => DAOs.BookDAO.GetBookById(id);

        public void UpdateBook(int id, Book book)
        => DAOs.BookDAO.UpdateBook(id, book);
    }
}
