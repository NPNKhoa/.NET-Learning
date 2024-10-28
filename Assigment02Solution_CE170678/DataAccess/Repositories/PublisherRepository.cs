using BusinessObject;

namespace DataAccess.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        public void AddPublisher(Publisher publisher)
        => DAOs.PublisherDAO.AddPublisher(publisher);

        public void DeletePublisher(int id)
        => DAOs.PublisherDAO.DeletePublisher(id);

        public List<Publisher> GetAllPublishers()
        => DAOs.PublisherDAO.GetPublishers();

        public Publisher GetPublisherById(int id)
        => DAOs.PublisherDAO.GetPublisherById(id);

        public void UpdatePublisher(int id, Publisher publisher)
        => DAOs.PublisherDAO.UpdatePublisher(id, publisher);
    }
}
