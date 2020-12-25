using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineCsharp
{
    public partial class Form1 : Form
    {
        VendingMachine myVendingMachine;

        public Form1()
        {
            InitializeComponent();
            myVendingMachine = new VendingMachine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Now you can select a soda");
            
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.HasQuarter;
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Insert Quarters");

            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.NoQuarter;
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
