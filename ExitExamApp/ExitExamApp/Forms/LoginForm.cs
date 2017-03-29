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
    public partial class LoginForm : Form
    {
        User user = new User();
        DatabaseManager db = new DatabaseManager();

        public LoginForm()
        {
            InitializeComponent();
       
        }

        /* private void exitButton_Click(object sender, EventArgs e)
         * 
         * exitButton_Click will close the program when the button is clicked. 
        */
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* private void userNameBox_KeyDown(object sender, KeyEventArgs e)
         * 
         * We want the user to be able to press enter after typing their
         * userName to be able to go to the next box (password). This will
         * also check to make sure if the user entered anything in the textbox.
         */
        private void userNameBox_KeyDown(object sender, KeyEventArgs e)
        {

            //if user presses enter, 
            //(1)check if anything is in the userTextBox
            //(2) if there is something in, proceed to passBox with enter key.
            if (e.KeyCode == Keys.Enter)
            {
                if(userNameBox.Text == "")
                {
                    MessageBox.Show("Invalid Username or Password. Try again.", "Error!", MessageBoxButtons.OK);
                    userNameBox.Text = "";
                    
                }
                else
                {
                    passBox.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                
            }
        }

        /* private void passBox_KeyDown(object sender, KeyEventArgs e)
         * 
         * We want the user to be able to press enter as well with the passBox.
         * This method will check if anything is entered within the passTextBox.
         * If so, it will perform a click on loginButton when pressing the enter key.
        */
        private void passBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            //Check if the user pressed the Enter key if so,
            //(1) check if it is empty or not. Show error box.
            //(2) if text is entered, perform click on login button.
            if(e.KeyCode == Keys.Enter)
            {
                if(passBox.Text == "")
                {
                    MessageBox.Show("Invalid Username or Password. Try again.", "Error!", MessageBoxButtons.OK);
                    passBox.Text = "";
                }
                else
                {
                    loginButton.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }   
            }//close for if
        }//close for passBox_KeyDown

        /* private void loginButton_Click(object sender, EventArgs e)
         * 
         * loginButton_Click will check the user credentials based on what 
         * text is inside userNameBox and passBox. 
         */
        private void loginButton_Click(object sender, EventArgs e)
        {
            //Check to see if anything is entered in the textBox
            //(1) if nothing is entered and user pressed/click login,
            //show error message.
            //(2) else  validate the user using ValidateUser from DatabaseManager.
            if(userNameBox.Text == "" || passBox.Text == "")
            {
                MessageBox.Show("Username and Password can not be empty. Please enter credentials.");
                userNameBox.Text = "";
                passBox.Text = "";
            }
            else
            {         
                //ValidateUser returns a user object.  
                user = db.ValidateUser(userNameBox.Text, passBox.Text);
             
                //ValidateUser returns null if validation was unsuccessful.
                //Print error message if null was returned.
                if(user == null)
                {
                    MessageBox.Show("Username/Password is incorrect. Try again.");
                    userNameBox.Text = "";
                    passBox.Text = "";
                    userNameBox.Focus();
                }
                //else hide the login form and go to mainMenuForm.
                else
                {
                    this.Hide();
                    ExamMenuForm ss = new ExamMenuForm(user);
                    ss.Show();
                }      
            }//second else          
        }//loginButton_Click
    }
}
