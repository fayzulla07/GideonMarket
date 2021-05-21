﻿using System;
using System.Collections.Generic;

namespace GideonMarket.Web.Client.Application
{
    public class UserResponse
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string Role { get; set; }
        public bool IsSuccessCode { get; set; } = true;
        public Dictionary<string, string[]> errors { get; set; }

        public bool RememberMe { get; set; }
    }
}