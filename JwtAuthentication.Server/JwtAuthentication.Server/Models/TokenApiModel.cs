﻿namespace JwtAuthentication.Server.Models
{
    public class TokenApiModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
