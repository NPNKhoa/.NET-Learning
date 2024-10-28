using BusinessObject;

namespace DataAccess.DAOs
{
    public class PublisherDAO
    {
        public static List<Publisher> GetPublishers()
        {
            var listPublishers = new List<Publisher>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listPublishers = context.Publishers.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listPublishers;
        }

        public static Publisher GetPublisherById(int publisherId)
        {
            Publisher p = new Publisher();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Publishers.SingleOrDefault(x => x.pub_id == publisherId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return p;
        }

        public static void AddPublisher(Publisher p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Publishers.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdatePublisher(int id, Publisher p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var existingPublisher = context.Publishers.Find(id);

                    if (existingPublisher != null)
                    {
                        existingPublisher.publisher_name = p.publisher_name;
                        existingPublisher.city = p.city;
                        existingPublisher.state = p.state;
                        existingPublisher.country = p.country;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePublisher(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Publishers.SingleOrDefault(c => c.pub_id == id);
                    context.Publishers.Remove(p1);
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
