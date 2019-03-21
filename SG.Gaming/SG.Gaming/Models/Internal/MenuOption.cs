using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SG.Gaming.Models
{
    public class MenuOption
    {
        public MenuOptionToken Key { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public Color BackgroundColor { get; set; }
        public int Order { get; set; }
    }
}
