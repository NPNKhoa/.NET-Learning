using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DataAccess.DAOs
{
    public class UserDAO
    {
        // Lấy tất cả người dùng
        public static List<User> GetUsers()
        {
            var listUsers = new List<User>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listUsers = context.Users.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listUsers;
        }

        // Lấy người dùng theo ID
        public static User GetUserById(int userId)
        {
            User user = new User();
            try
            {
                using (var context = new MyDbContext())
                {
                    user = context.Users.SingleOrDefault(x => x.user_id == userId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return user;
        }

        public static void RegisterUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string Login(string email, string password)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var user = context.Users
                                      .Include(u => u.Role)
                                      .SingleOrDefault(x => x.email_address == email);

                    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.password))
                    {
                        var token = GenerateToken(user);
                        return token;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return null;
        }


        public static User UpdateUser(int id, User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var existingUser = context.Users.Find(id);

                    if (existingUser != null)
                    {
                        existingUser.email_address = user.email_address;
                        // Nếu có mật khẩu mới, mã hóa mật khẩu trước khi lưu
                        if (!string.IsNullOrEmpty(user.password))
                        {
                            existingUser.password = BCrypt.Net.BCrypt.HashPassword(user.password);
                        }
                        existingUser.source = user.source;
                        existingUser.first_name = user.first_name;
                        existingUser.middle_name = user.middle_name;
                        existingUser.last_name = user.last_name;
                        existingUser.hire_date = user.hire_date;
                        existingUser.role_id = user.role_id;
                        existingUser.pub_id = user.pub_id;

                        context.SaveChanges();
                    }

                    return existingUser;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Xóa người dùng
        public static void DeleteUser(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var user = context.Users.SingleOrDefault(c => c.user_id == id);
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        private static string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.email_address),
                new Claim(ClaimTypes.Role, user.Role.role_desc),
                new Claim("UserID", user.user_id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeynehehehehhe123456789abchihihi"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "duyen",
                audience: "duyenn",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
