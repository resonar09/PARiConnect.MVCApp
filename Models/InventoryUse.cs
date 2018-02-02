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
        public string Name { get; set; }
        public string ProductName { get; set; }
        
        public int Uses { get; set; }

    }
}