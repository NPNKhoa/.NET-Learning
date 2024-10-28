using BusinessObject.DTOs;

namespace BusinessObject.Mappers
{
    public static class AuthorMapper
    {
        public static Author ToEntityAuthor(this CreateAuthorDto dto)
        {
            return new Author
            {
                last_name = dto.last_name,
                first_name = dto.first_name,
                phone = dto.phone,
                address = dto.address,
                city = dto.city,
                state = dto.state,
                zip = dto.zip,
                email_address = dto.email_address
            };
        }
    }
}
