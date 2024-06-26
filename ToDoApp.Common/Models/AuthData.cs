﻿using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class AuthData
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("user")]
        public EmployeeUIData User { get; set; }

        [JsonConstructor]
        public AuthData(string token, EmployeeUIData user)
        {
            Token = token;
            User = user;
        }
    }
}
