using BusinessObject;

namespace DataAccess.Repositories
{
    public interface IPublisherRepository
    {
        List<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int id);
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(int id, Publisher publisher);
        void DeletePublisher(int id);
    }
}
