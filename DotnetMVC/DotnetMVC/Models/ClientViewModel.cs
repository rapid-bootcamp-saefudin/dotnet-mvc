namespace DotnetMVC.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public String ClientName { get; set; }
        public String ClientEmail { get; set; }
        public String Gender { get; set; }
        public String CompanyName { get; set; }

        public ClientViewModel()
        {

        }

        public ClientViewModel(
            int id, 
            string clientName, 
            string clientEmail, 
            string gender, 
            string companyName
            )
        {
            Id = id;
            ClientName = clientName;
            ClientEmail = clientEmail;
            Gender = gender;
            CompanyName = companyName;
        }
    }
}
