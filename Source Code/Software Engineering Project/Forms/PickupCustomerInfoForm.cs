using System;
using System.Windows.Forms;

namespace Software_Engineering_Project.Forms
{
    public partial class PickupCustomerInfoForm : Form
    {
        private PickupControl controller;
        public PickupCustomerInfoForm(PickupControl c)
        {
            InitializeComponent();
            controller = c;
        }

        public void Submit()
        {
            string name;
            string cc;
            string address;
            string exp;
            string ccv;
            string city;
            string state;
            string zip;
            string phone;
            string insurance;

            name = Name_box.Text;
            cc = CardNum_box.Text;
            address = Address_box.Text;
            exp = Exp_box.Text;
            ccv = CCV_box.Text;
            city = City_box.Text;
            state = State_box.Text;
            zip = Zip_box.Text;
            phone = Phone_box.Text;
            insurance = Insurance_box.Text;

            if (name.Split(' ').Length < 2)
                return;

            controller.Submit(name, cc, address, exp, ccv, city, state, zip, phone, insurance);

            this.Close();
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {
            Submit();
        }
    }
}
