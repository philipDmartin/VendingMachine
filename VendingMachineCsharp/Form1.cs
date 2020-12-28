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
            textBoxVMViewer.Text = ("Please Inerst Quarter");
            textBoxVMStateViewer.Text = ("Your Current State");
        }

        //INSERT
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("Now you can select a soda");

            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.HasQuarter;
            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());

        }

        //EJECT
        private void button2_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("Please Insert Quarters");

            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.NoQuarter;
            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());

        }

        //SPRITE
        private void button3_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("You Have Selected Sprite, Now Despensing");

            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.Sold;
            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());
        }

        //COKE
        private void button4_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("You Have Selected Coke, Now Despensing");

            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());

            myVendingMachine.VendingMachineStateEnum = VendingMachineStateEnum.Sold;
            textBoxVMStateViewer.Text = (myVendingMachine.VendingMachineStateEnum.ToString());

        }

        //INVENTORY
        private void button5_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("Here Is Your Inventory");
            
        }

        //PURCHASE TRANSACTIONS
        private void button6_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("Here Is Your Purchase Transaction History");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxVMViewer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVMStateViewer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
