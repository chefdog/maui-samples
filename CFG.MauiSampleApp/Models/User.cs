﻿namespace CFG.MauiSampleApp.Models
{
    public record User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }
    }
}
