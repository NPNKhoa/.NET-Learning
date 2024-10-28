using BusinessObject;

namespace DataAccess.DAOs
{
    public class BookAuthorDAO
    {

        public static void AddBookAuthor(BookAuthor b)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.BookAuthors.Add(b);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static bool CheckExistBookAuthor(BookAuthor bookAuthor)
        {

            try
            {
                using (var context = new MyDbContext())
                {
                    return context.BookAuthors.Any(p => p.author_id == bookAuthor.author_id && p.book_id == bookAuthor.book_id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
    }
}
