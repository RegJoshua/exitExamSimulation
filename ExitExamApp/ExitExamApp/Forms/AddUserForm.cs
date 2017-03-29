using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ExitExamApp
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }
        DatabaseManager db = new DatabaseManager();
        /******************************************************************************
         * private void addButton_Click(object sender, EventArgs e)
         * 
         * @ instantiates new User based on data submitted in AddUserForm text boxes
         * @ params: object sender, EventArgs e
         * @ returns: NA
         * 
        ******************************************************************************/
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // instantiate new User
                User theNewUser = new User();

                // specify user attributes
                try
                { theNewUser.UserID = Int32.Parse(this.mNumberBox.Text); }
                catch (Exception ex)
                { MessageBox.Show("Please enter ony integers for the M number."); }

                theNewUser.FirstName = this.firstNameBox.Text;
                theNewUser.LastName = this.lastNameBox.Text;
                theNewUser.UserName = this.userNameBox.Text;
                theNewUser.PassWord = this.passwordBox.Text;

                // send User object to Database Manager- so indicate if no joy
                bool success = db.InsertUser(theNewUser);
                if (!success) MessageBox.Show("User not added.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There's no data.");
            }
            this.Hide();
        }
    }
}
