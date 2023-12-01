using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace NewProjectWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int id = 0;
        public MainWindow()
        {
            InitializeComponent();
        }




        private void BindGrid()
        {
            Crud c = new Crud();
            dgvhuman.ItemsSource = null;
            dgvhuman.ItemsSource = c.Read();
            txtname.Text = "";
            txtfamily.Text = "";
            txtage.Text = "";
        }



        private void dgvhuman_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dgvhuman.CurrentItem != null)
            {
                if (e.RightButton == Mouse.RightButton)
                {
                    id = ((human)dgvhuman.SelectedItem).id;
                }
            }
            else
            {
                MessageBox.Show("No");
            }
        }



        bool isVail()
        {
            bool ischek = true;

            if (txtname.Text == "")
            {
                MessageBox.Show("نام کاربر را وارد نمایید");
                ischek = false;
                txtname.Focus();
            }
            else if (txtfamily.Text == "")
            {
                MessageBox.Show("فامیلی خود را وارد نمایید");
                ischek = false;
                txtfamily.Focus();
            }
            else if (txtage.Text == "")
            {
                MessageBox.Show("سن خود را وارد نمایید");
                ischek = false;
                txtage.Focus();
            }
            return ischek;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isVail())
            {
                human h = new human();
                Crud c = new Crud();
                h.Name = txtname.Text;
                h.Family = txtfamily.Text;
                h.Age = int.Parse(txtage.Text);

                if (btnSaveAndUpdate.Content.ToString() == "save")
                {
                    MessageBox.Show(c.Crete(h));
                }
                else if (btnSaveAndUpdate.Content.ToString() == "update")
                {
                    MessageBox.Show(c.Update(id, h));
                    btnSaveAndUpdate.Content = "save";
                }

                BindGrid();
            }
        }



        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            Crud c = new Crud();
            human hh = c.ReadById(id);
            txtname.Text = hh.Name;
            txtfamily.Text = hh.Family;
            txtage.Text = hh.Age.ToString();
            btnSaveAndUpdate.Content = "update";
        }


        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            Crud c = new Crud();
            MessageBox.Show(c.Delete(id));
            BindGrid();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

      int index = 0;
        private void txtname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Crud c = new Crud();
            if(index == 1)
            {
                dgvhuman.ItemsSource = null;
                dgvhuman.ItemsSource = c.Serch(txtname.Text, 0);
            }
           else if (index == 2)
            {
                dgvhuman.ItemsSource = null;
                dgvhuman.ItemsSource = c.Serch(txtname.Text, 2);
            }
        }

        
    }
}
