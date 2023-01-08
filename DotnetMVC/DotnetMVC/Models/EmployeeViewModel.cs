namespace DotnetMVC.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String JobPosition { get; set; }
        public String Status { get; set; }

        public EmployeeViewModel()
        {

        }

        public EmployeeViewModel(
            int id, 
            string name, 
            string email, 
            string gender, 
            string jobPosition, 
            string status 
            )
        {
            Id = id;
            Name = name;
            Email = email;
            Gender = gender;
            JobPosition = jobPosition;
            Status = status;
        }
    }
}
