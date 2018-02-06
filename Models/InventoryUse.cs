namespace PARiConnect.MVCApp.Models
{
    public class InventoryUse
    {
        public InventoryUse()
        {       
        }
        public InventoryUse(string name, int uses)
        {
            this.Name = name;
            this.Uses = uses;          
        }
        public InventoryUse(string name, int uses, string productName)
        {
            this.Name = name;
            this.Uses = uses; 
            this.ProductName = productName;         
        }
        public string Name { get; set; }
        public string ProductName { get; set; }
        
        public int Uses { get; set; }

    }
}