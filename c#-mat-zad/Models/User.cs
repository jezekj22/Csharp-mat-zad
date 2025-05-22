﻿using System.ComponentModel.DataAnnotations;

namespace NotesAppAspNet.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public List<Note> Notes { get; set; }
    }
}
