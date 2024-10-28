using BusinessObject;

namespace DataAccess.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        public void AddBookAuthor(BookAuthor bookAuthor)
        => DAOs.BookAuthorDAO.AddBookAuthor(bookAuthor);

        public bool CheckExistBookAuthor(BookAuthor bookAuthor)
       => DAOs.BookAuthorDAO.CheckExistBookAuthor(bookAuthor);
    }
}
