namespace Tektonlabs.Ecommerce.Domain.MarketingApi
{
    public class DiscountModel
    {
        public string ProductId { get; set; } = string.Empty;
        private string _percent = "0";
        public string Percent
        {
            get => _percent;
            set
            {
                if ((Convert.ToInt32(value) > 0) && (Convert.ToInt32(value) <= 100))
                {
                    _percent = value;
                }
            }
        }
        public int PercentValue { get { return Convert.ToInt32(Percent) * 10; } }
    }
}
