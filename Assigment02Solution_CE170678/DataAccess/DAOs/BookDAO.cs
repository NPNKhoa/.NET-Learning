using BusinessObject;

namespace DataAccess.DAOs
{
    public class BookDAO
    {
        public static List<Book> GetBooks()
        {
            var listBooks = new List<Book>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listBooks = context.Books.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBooks;
        }

        public static Book GetBookById(int bookId)
        {
            Book b = new Book();
            try
            {
                using (var context = new MyDbContext())
                {
                    b = context.Books.SingleOrDefault(x => x.book_id == bookId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return b;
        }

        public static void AddBook(Book b)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Books.Add(b);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateBook(int id, Book b)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var existingBook = context.Books.Find(id);

                    if (existingBook != null)
                    {
                        existingBook.title = b.title;
                        existingBook.type = b.type;
                        existingBook.price = b.price;
                        existingBook.advance = b.advance;
                        existingBook.royalty = b.royalty;
                        existingBook.ytd_sales = b.ytd_sales;
                        existingBook.notes = b.notes;
                        existingBook.published_date = b.published_date;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteBook(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var b1 = context.Books.SingleOrDefault(c => c.book_id == id);
                    context.Books.Remove(b1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
