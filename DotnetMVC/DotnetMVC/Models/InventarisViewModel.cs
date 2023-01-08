namespace DotnetMVC.Models
{
    public class InventarisViewModel
    {
        public int Id { get; set; }
        public String ProductName { get; set; }
        public String Category { get; set; }
        public String Brand { get; set; }
        public int Stock { get; set; }

        public InventarisViewModel()
        {

        }

        public InventarisViewModel(
            int id, 
            string productName,
            string category,
            string brand,
            int stock
            )
        {
            Id = id;
            ProductName = productName;
            Category = category;
            Brand = brand;
            Stock = stock;
        }
    }
}
