using AutoMapperOdata.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DTOs.RequestModels
{
    public class CommentContract
    {
        [Key]
        public int Id { get; set; }

        [DataMember(Name = "Text")]
        public string Text { get; set; }

        [DataMember(Name = "creator")]
        public string Creator { get; set; }
    }
}
