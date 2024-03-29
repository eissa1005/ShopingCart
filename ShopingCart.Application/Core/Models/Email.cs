﻿
using System.ComponentModel.DataAnnotations;

namespace ShopingCart.Application.Core.Models
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string BCc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<MailAttachment> Attachments { get; set; }

    }
}
