using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace GAD_Cousework._01
{
    public partial class Customer_Details : MetroFramework.Forms.MetroForm
    {
        public Customer_Details()
        {
            InitializeComponent();
        }
        DBConnection obj = new DBConnection();
        private void Customer_Details_Load(object sender, EventArgs e)
        {
            error_msg.Text = "";
        }
        
        private void Btn_search_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cusid.Text))
            {
                error_msg.Text = "Please Enter the Customer ID. Ex:C001";
                txt_cusid.Focus();
            }
            else
            {
                string query = "SELECT * FROM Customer WHERE Customer_ID='" + txt_cusid.Text + "'";
                metroGrid_customer.DataSource = obj.Display(query);
            }
        }

        private void Btn_update_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cusid.Text))
            {
                error_msg.Text = "Please Enter the Customer ID. Ex:C001";
                txt_cusid.Focus();
            }
            else if (string.IsNullOrEmpty(txt_cusfname.Text))
            {
                error_msg.Text = "First Name cannot be blank";
                txt_cusfname.Focus();
            }
            else if (txt_cusfname.Text.Any(char.IsDigit))
            {
                error_msg.Text = "First Name cannot have numbers";
                txt_cusfname.Focus();
            }
            else if (string.IsNullOrEmpty(txt_cuslname.Text))
            {
                error_msg.Text = "Last Name cannot be blank";
                txt_cuslname.Focus();
            }
            else if (txt_cuslname.Text.Any(char.IsDigit))
            {
                error_msg.Text = "Last Name cannot have numbers";
                txt_cuslname.Focus();
            }
            else if (txt_cusemail.Text.Length == 0)
            {
                error_msg.Text = "Please Enter Email Address";
                txt_cusemail.Focus();
            }
            else if (!Regex.IsMatch(txt_cusemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                error_msg.Text = "Enter a valid email. Ex:name@gmail.com";
                txt_cusemail.Focus();
            }
            else if (!Regex.IsMatch(txt_cusphoneno.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
            {
                error_msg.Text = "Phone No must have 10 numbers";
                txt_cusphoneno.Focus();
            }
            else if (string.IsNullOrEmpty(txt_cusaddress.Text))
            {
                error_msg.Text = "Address cannot be blank";
                txt_cusaddress.Focus();
            }
            else if (string.IsNullOrEmpty(txt_cusnicno.Text))
            {
                error_msg.Text = "NIC NO cannot be blank";
                txt_cusnicno.Focus();
            }
            else if (txt_cusnicno.Text.Length > 12)
            {
                error_msg.Text = "Please Enter a valid NIC NO";
                txt_cusnicno.Focus();
            }
            else
            {
                try
                {

                    error_msg.Text = "";
                    string query = "UPDATE Customer SET First_Name='" + txt_cusfname.Text + "',Last_Name='" + txt_cuslname.Text + "',Email='" + txt_cusemail.Text + "',Phone_No='" + txt_cusphoneno.Text + "',Address='" + txt_cusaddress.Text + "',NIC='" + txt_cusnicno.Text + "' WHERE Customer_ID='" + txt_cusid.Text + "'";
                    int line = obj.Save_Update_Delete(query);
                    if (line == 1)
                        MessageBox.Show("Data Saved Successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Data is Not Saved.Check Again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Check Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_delete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cusid.Text))
            {
                error_msg.Text = "Please Enter the Customer ID. Ex:C001";
                txt_cusid.Focus();
            }
            else
            {
                try
                {
                    string query = "DELETE FROM Customer WHERE Customer_ID='" + txt_cusid.Text + "'";
                    int line = obj.Save_Update_Delete(query);
                    if (line == 1)
                        MessageBox.Show("Data deleted Successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Data is Not Deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Check Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_clear_Click_1(object sender, EventArgs e)
        {
            txt_cusid.Clear();
            txt_cusfname.Clear();
            txt_cuslname.Clear();
            txt_cusemail.Clear();
            txt_cusphoneno.Clear();
            txt_cusnicno.Clear();
            txt_cusaddress.Clear();
        }
    }
}
