namespace DotnetMVC.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public String ProjectName { get; set; }
        public String Status { get; set; }

        public ProjectViewModel()
        {

        }

        public ProjectViewModel(
            int id,
            string projectName,
            string status
            )
        {
            Id = id;
            ProjectName = projectName;
            Status = status;
        }
    }
}
