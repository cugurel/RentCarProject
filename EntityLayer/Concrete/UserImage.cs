using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class UserImage
	{
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
