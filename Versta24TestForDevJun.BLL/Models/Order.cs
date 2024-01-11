using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24TestForDevJun.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string SenderAddress { get; set; } = null!;

        public string SenderCity { get; set; } = null!;

        public string RecipientAddress { get; set; } = null!;

        public string RecipientCity { get; set; } = null!;

        public double CargoWeight { get; set; }

        public DateOnly CargoPickUpDate { get; set; }
    }
}
