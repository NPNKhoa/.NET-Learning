using BusinessObject;

namespace DataAccess.DAOs
{
    public class AuthorDAO
    {
        public static List<Author> GetAuthors()
        {
            var listAuthors = new List<Author>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listAuthors = context.Authors.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listAuthors;
        }
        public static Author GetAuthorById(int authorId)
        {
            Author p = new Author();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Authors.SingleOrDefault(x => x.author_id == authorId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return p;
        }

        public static void AddAuthor(Author p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Authors.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateAuthor(int id, Author p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var existingAuthor = context.Authors.Find(id);

                    if (existingAuthor != null)
                    {
                        existingAuthor.last_name = p.last_name;
                        existingAuthor.first_name = p.first_name;
                        existingAuthor.phone = p.phone;
                        existingAuthor.address = p.address;
                        existingAuthor.city = p.city;
                        existingAuthor.state = p.state;
                        existingAuthor.zip = p.zip;
                        existingAuthor.email_address = p.email_address;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteAuthor(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Authors.SingleOrDefault(c => c.author_id == id);
                    context.Authors.Remove(p1);
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
