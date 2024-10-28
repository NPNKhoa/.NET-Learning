using BusinessObject.DTOs;

namespace BusinessObject.Mappers
{
    public static class UserMapper
    {
        public static User ToEntityUser(this CreateUserDto dto)
        {
            return new User
            {
                email_address = dto.email_address,
                password = dto.password,
                source = dto.source,
                first_name = dto.first_name,
                middle_name = dto.middle_name,
                last_name = dto.last_name,
                hire_date = dto.hire_date,
                role_id = dto.role_id,
                pub_id = dto.pub_id
            };
        }
    }
}
