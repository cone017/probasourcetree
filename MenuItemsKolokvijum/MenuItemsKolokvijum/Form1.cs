using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuItemsKolokvijum
{
    public partial class Form1 : Form
    {

        readonly MenuItemBusiness menu = new MenuItemBusiness();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            listBoxMenuItems.Items.Clear();

            foreach(MenuItem2 item in menu.GetAllMenuItems())
            {
                listBoxMenuItems.Items.Add($"{item.Id}, {item.Title}, {item.Description}, {item.Price}");
            }
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            MenuItem2 menuItem2 = new MenuItem2()
            {
                Title = textBoxTitle.Text,
                Description = textBoxDescription.Text,
                Price = Convert.ToDecimal(textBoxPrice.Text)
            };

            menu.InsertMenuItem(menuItem2);

            RefreshList();

            textBoxTitle.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            textBoxPrice.Text = string.Empty;
        }

        private void buttonOpseg_Click(object sender, EventArgs e)
        {
            listBoxMenuItems.Items.Clear();

            int min = 0, max = 0;

            try
            {
                min = Convert.ToInt32(textBoxMin.Text);
                max = Convert.ToInt32(textBoxMax.Text);
            }
            catch(Exception ex) {
                MessageBox.Show("Uneti opseg!");
            }

            foreach (MenuItem2 item in menu.GetMenuItemsInRange(min, max))
            {
                listBoxMenuItems.Items.Add($"{item.Id}, {item.Title}, {item.Description}, {item.Price}");
            }

            textBoxMin.Text = string.Empty;
            textBoxMax.Text = string.Empty;
        }
    }
}
