namespace Application.Models.Requests
{
    public class PaymentPreferenceResponseDto
    {
        public int OrderId { get; set; }
        public string PreferenceId { get; set; }
        public string InitPoint { get; set; }
    }
}
