  
namespace ClassUtilities.Models
{
    public class Country
    {
        public Country(string countryCode, string countryName)
        {
            this.countryCode = countryCode;
            this.countryName = countryName;
        }

        public string countryCode { get; set; }
        public string countryName { get; set; }
    }
}
