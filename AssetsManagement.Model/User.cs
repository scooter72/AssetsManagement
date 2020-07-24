﻿namespace AssetsManagement.Model
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
