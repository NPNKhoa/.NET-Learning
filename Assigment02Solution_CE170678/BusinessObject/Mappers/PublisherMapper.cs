using BusinessObject.DTOs;

namespace BusinessObject.Mappers
{
    public static class PublisherMapper
    {
        public static Publisher ToEntityPublisher(this CreatePublisherDto dto)
        {
            return new Publisher
            {
                publisher_name = dto.publisher_name,
                city = dto.city,
                state = dto.state,
                country = dto.country
            };
        }
    }
}
