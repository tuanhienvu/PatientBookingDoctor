using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PatientBookingDoctor.Models
{
    public class MenuItems
    {
        // public MenuItems()
        // {
        //     TargetItemText = typeof(ContentPage);
        // }
        public string Id { get; set; }
        public string Title { get; set; }

        public string TargetItem { get; set; }
    }
}