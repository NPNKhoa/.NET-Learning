using BusinessObject.DTOs;

namespace BusinessObject.Mappers
{
    public static class BookMapper
    {
        public static Book ToEntityBook(this CreateBookDto dto)
        {
            return new Book
            {
                title = dto.title,
                type = dto.type,
                price = dto.price,
                advance = dto.advance,
                royalty = dto.royalty,
                ytd_sales = dto.ytd_sales,
                notes = dto.notes,
                published_date = dto.published_date,
                pub_id = dto.pub_id

            };
        }
    }
}
