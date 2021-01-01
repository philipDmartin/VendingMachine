using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using VendingMachineCsharp.Repositories;

namespace VendingMachineCsharp
{
    public partial class Form1 : Form
    {
        VendingMachine myVendingMachine;
        Product myProduct;
        PurchaseTransactions myPurchaseTransactions;
        Inventory myInventory;

        InventoryRepository myInventoryRepository;
        List<Inventory> myInventoryList;


        public Form1()
        {
            InitializeComponent();
            myVendingMachine = new VendingMachine();
            myProduct = new Product();
            myPurchaseTransactions = new PurchaseTransactions();
            myInventory = new Inventory();

            myInventoryRepository = new InventoryRepository();
            myInventoryList = myInventoryRepository.GetAll();

            textBoxVMViewer.Text = ("Please Inerst Quarter");
            textBoxVMStateViewer.Text = ("Your Current State");

            string constring = "server=localhost\\SQLExpress;database=VendingMachine;integrated security=true;";
            string Query = "select * from Product";

            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                //myReader.Read();
                //MessageBox.Show(myReader.GetSqlValue(0).ToString()+ " " + myReader.GetSqlValue(1).ToString());
                //myReader.Read();
                //MessageBox.Show(myReader.GetSqlValue(0).ToString() + " " + myReader.GetSqlValue(1).ToString());
                while (myReader.Read())
                {
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            string strAllInventory = "";

            foreach (var inventory in myInventoryList)
            {
                strAllInventory += inventory.Product.Name + " " + inventory.Qty;
                strAllInventory += Environment.NewLine;
            }

            textBoxVMViewer.Text = strAllInventory;
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
