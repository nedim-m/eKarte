using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Utility
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public string APIKey { get; set; }
        public string APIKeySecret { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public bool enableSSL { get; set; }
    }
}
