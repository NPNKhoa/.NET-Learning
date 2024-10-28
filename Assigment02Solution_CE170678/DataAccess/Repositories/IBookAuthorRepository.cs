using BusinessObject;

namespace DataAccess.Repositories
{
    public interface IBookAuthorRepository
    {
        void AddBookAuthor(BookAuthor bookAuthor);
        bool CheckExistBookAuthor(BookAuthor bookAuthor);
    }
}
