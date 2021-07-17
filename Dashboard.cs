using FormUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Dashboard : Form
    {
        List<Person> people = new List<Person>();
        DataAccess db = new DataAccess();
        public Dashboard()
        {
            InitializeComponent();
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            peopleFoundListbox.DataSource = people;
            peopleFoundListbox.DisplayMember = "FullInfo";
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            
            people = db.GetPeople(lastNameText.Text);
            if (people.Count!=0)
            {
                UpdateBinding();
            }
            else
            {
                MessageBox.Show($"No account with surname {lastNameText.Text} was found", "No Surname Found",MessageBoxButtons.OK);
            }
            lastNameText.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.InsertPerson(firstNameIns.Text, lastNameIns.Text, emailIns.Text, telephoneIns.Text);
            firstNameIns.Text = "";
            lastNameIns.Text = "";
            emailIns.Text = "";
            telephoneIns.Text = "";
        }

        private void GetAll_Click(object sender, EventArgs e)
        {
            people = db.GetAll();
            UpdateBinding();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            peopleFoundListbox.DataSource = null;
          //  peopleFoundListbox.Items.Clear();
        }
    }
}
