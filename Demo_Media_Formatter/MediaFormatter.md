# CÁC BƯỚC TẠO MỘT MEDIA FORMATTER

- Khai báo lớp Formatter, kế thừa từ lớp OutputFormatter (hoặc TextOutputFormatter tùy vào dữ liệu).

- Định nghĩa contructor với các cấu hình như thêm loại giá trị, endcoding:

  ```C#
      public CsvOutputFormatter()
      {
          SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
          SupportedEncodings.Add(Encoding.UTF8);
      }
  ```

- Override phương thức `CanWriteType`. Phương thức này sẽ kiểm tra xem một kiểu dữ liệu truyền vào có thể ghi vào response body hay không:

  ```C#
      protected override bool CanWriteType(Type? type)
      {
          if (typeof(IEnumerable<Book>).IsAssignableFrom(type) || typeof(Book).IsAssignableFrom(type))
          {
              return true;
          }
          return false;
      }
  ```

  - Phương thức `IsAssignableFrom`: Một phương thức thuộc lớp `Type` của C#, kiểm tra xem một loại có thể được gán vào một loại kia hay không

- Override phương thức `WriteResponseBodyAsync`:

  ```C#
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
  ```

  - Đối tượng `OutputFormatterWriteContext`: Là một đối tượng chứa toàn bộ thông tin về HTTP request hiện tại, bao gồm:

    - `context.HttpContext.Response`: Thông tin về HTTP response

    - `context.Object`: Là dữ liệu mà sẽ được gưi về client

  - Encoding selectedEncoding:

    - Đây là encoding được sử dụng để mã hóa nội dung trả về cho client, ví dụ như UTF-8. ASP.NET Core truyền encoding này từ thông tin định dạng trong yêu cầu HTTP.

  - Bonus:

    - Định dạng CSV (Comma-Separated Values) là một định dạng tệp văn bản dùng để lưu trữ dữ liệu dạng bảng, trong đó mỗi dòng tương ứng với một bản ghi, và các giá trị trong mỗi dòng được ngăn cách bởi dấu phẩy (hoặc dấu phân cách khác như dấu chấm phẩy).

    - Cấu trúc cơ bản của tệp CSV:

      1. **Hàng tiêu đề**: Chứa tên của các cột, thường là dòng đầu tiên.

      2. **Các dòng dữ liệu**: Mỗi dòng tương ứng với một bản ghi, các giá trị trong một bản ghi được ngăn cách bởi dấu phân cách (thường là dấu phẩy).

- Đăng ký dịch vụ:

  ```C#
      builder.Services.AddControllers(options =>
      {
          options.OutputFormatters.Add(new CsvOutputFormatter());
      });
  ```
