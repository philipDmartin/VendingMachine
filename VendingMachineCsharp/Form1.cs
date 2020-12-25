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
        Product myProduct;
        Inventory myInventory;
        PurchaseTransactions myPurchaseTransactions;

        public Form1()
        {
            InitializeComponent();
            myVendingMachine = new VendingMachine();
            myProduct = new Product();
            myInventory = new Inventory();
            myPurchaseTransactions = new PurchaseTransactions();
        }

        //INSERT
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Now you can select a soda");
            
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.HasQuarter;
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

        }

        //EJECT
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Insert Quarters");

            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.NoQuarter;
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

        }

        //SPRITE
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Selected Sprite, Now Despensing");

            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.Sold;
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());
        }

        //COKE
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Selected Coke, Now Despensing");

            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.Sold;
            MessageBox.Show(myVendingMachine.VendingMachineStateEnum.ToString());

        }

        //INVENTORY
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here Is Your Inventory");
        }

        //PURCHASE TRANSACTIONS
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here Is Your Purchase Transaction History");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
