using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class CarStyleDto
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
        public string? Style { get; set; }
        public bool? Statu { get; set; }
        public bool? Revision { get; set; }
        public DateTime RevisionDate { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
    }
}
