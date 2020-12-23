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
            MessageBox.Show("Now you can select a sode");
            //VendingMachine myVendingMachine = new VendingMachine();
            
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());
            //MessageBox.Show(myVendingMachine.Name);
            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.HasQuarter;
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());
            //MessageBox.Show(myVendingMachine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
