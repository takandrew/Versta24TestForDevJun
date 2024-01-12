namespace Versta24TestForDevJun.BLL.Models
{
    public class OrderCreationDTO
    {
        public string SenderCity { get; set; }

        public string SenderAddress { get; set; }

        public string RecipientCity { get; set; }

        public string RecipientAddress { get; set; }

        public string CargoWeight { get; set; }

        public string CargoPickUpDate { get; set; }
    }
}
