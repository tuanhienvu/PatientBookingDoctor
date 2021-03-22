using System;


namespace PatientBookingDoctor.Models
{
    public class MenuItems
    {
        public MenuItems()
        {
            TargetType = typeof(MenuItems);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}