using System;

namespace RSClient
{
    public class User
    {
        private string userid;
        private string username;
        private string password;
        private string email;
        private string token;

        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}
