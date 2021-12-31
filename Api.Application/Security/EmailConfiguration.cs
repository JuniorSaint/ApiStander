using System;
namespace Api.Application.Security
{
    public class EmailConfiguration
    {
        private string _email = "junior.saint@outlook.com";
        private string _password = "xxxxxxxx";

        public string Email
        {
            get => _email;
            set {; }
        }

        public string Password
        {
            get => _password;
            set {; }
        }

        public EmailConfiguration() { }

    }
}

