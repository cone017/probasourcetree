using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MenuItemBusiness
    {
        public MenuItemRepository menu = new MenuItemRepository();

        public List<MenuItem2> GetAllMenuItems()
        {
            return menu.GetAllMenuItems();
        }

        public List<MenuItem2> GetMenuItemsInRange(int min, int max)
        {
            return menu.GetAllMenuItems().Where(item => item.Price >= min && item.Price <= max).ToList();
        }

        public bool InsertMenuItem(MenuItem2 menuItem)
        {
            return menu.InsertMenuItem(menuItem) != 0;
        }
    }
}
