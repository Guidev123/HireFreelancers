﻿namespace ProjectE.UserAPI.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
    }
}
