using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace DynamicWebsite.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly string connectionString = "Server=your-aws-rds-host;Database=dynamic_website;User Id=your-db-user;Password=your-db-password;";

        [HttpPost]
        public IActionResult Login([FromBody] UserLogin user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE email=@Email", conn);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return Ok(new { message = "Login successful" });
                }
                else
                {
                    return Unauthorized(new { error = "Invalid credentials" });
                }
            }
        }
    }

    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
