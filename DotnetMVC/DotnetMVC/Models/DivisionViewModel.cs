namespace DotnetMVC.Models
{
    public class DivisionViewModel
    {
        public int Id { get; set; }
        public String DivisionName { get; set; }

        public DivisionViewModel()
        {

        }

        public DivisionViewModel(
            int id, 
            string divisionName
            )
        {
            Id = id;
            DivisionName = divisionName;
        }
    }
}
