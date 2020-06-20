using System;

namespace Pic.Settings.Shared.Dto
{
    public class LogInResultDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}