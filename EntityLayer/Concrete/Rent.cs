using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Rent
	{
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerIdentity { get; set; }
        public string CarInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}