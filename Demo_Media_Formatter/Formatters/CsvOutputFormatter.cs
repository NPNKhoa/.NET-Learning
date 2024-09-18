using Demo_Media_Formatter.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace Demo_Media_Formatter.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(IEnumerable<Book>).IsAssignableFrom(type) || typeof(Book).IsAssignableFrom(type))
            {
                return true;
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;

            await using (var writer = new StreamWriter(response.Body, selectedEncoding))
            {
                await writer.WriteLineAsync("Id,Title,Author,Year");

                if (context.Object is IEnumerable<Book> books)
                {
                    foreach (var book in books)
                    {
                        await writer.WriteLineAsync($"{book.Id},{book.Title},{book.Author},{book.Year}");
                    }
                }
                else if (context.Object is Book book)
                {
                    await writer.WriteLineAsync($"{book.Id},{book.Title},{book.Author},{book.Year}");
                }
            }
        }
    }
}
