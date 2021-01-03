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
        //public VendingMachine Program.myVendingMachine;
        Product myProduct;
        PurchaseTransactions myPurchaseTransactions;
        Inventory myInventory;

        InventoryService myInventoryService;
        List<Inventory> myInventoryList;

        PurchaseTransactionsService myPurchaseTransactionsService;
        List<PurchaseTransactions> myPurchaseTransactionsList;

        public Form1()
        {
            InitializeComponent();
            //Program.myVendingMachine = new VendingMachine();
            myProduct = new Product();
            myPurchaseTransactions = new PurchaseTransactions();
            myInventory = new Inventory();

            myInventoryService = new InventoryService();
            myInventoryList = myInventoryService.GetAll();
            //myInventoryList = myInventoryRepository.Delete(int);

            myPurchaseTransactionsService = new PurchaseTransactionsService();
            myPurchaseTransactionsList = myPurchaseTransactionsService.GetAll();
            //myPurchaseTransactionsList = myPurchaseTransactionsService.Add(PurchaseTransactions);

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

            textBoxVMStateViewer.Text = (Program.programState.ToString());

            Program.ManageState(VendingMachineStateEnum.HasQuarter);

            textBoxVMStateViewer.Text = (Program.programState.ToString());
        }

        //EJECT
        private void button2_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("Please Insert Quarters");

            textBoxVMStateViewer.Text = (Program.programState.ToString());
            Program.ManageState(VendingMachineStateEnum.NoQuarter);
            textBoxVMStateViewer.Text = (Program.programState.ToString());

        }

        //SPRITE
        //private int i;
        private void button3_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("You Have Selected Sprite, Now Despensing");

            textBoxVMStateViewer.Text = (Program.programState.ToString());

            Program.ManageState(VendingMachineStateEnum.Sold);

            textBoxVMStateViewer.Text = (Program.programState.ToString());

            //i--;

            //1.DECREMENT QTY NUMBER BY 1 WHEN BUTTON CLICKED

            //string qtyInventory = "";

            //foreach (var inventory in myInventoryList)
            //{
            //    qtyInventory += --inventory.Qty;

            //}

            //textBoxVMViewer.Text = qtyInventory.ToString();

            //textBoxVMStateViewer.Text = i.ToString();

            //2.ADD A NEW TRANSACTION WHEN BUTTON CLICKED

            //myPurchaseTransactionsList.Add(PurchaseTransactions type);
        }

        //COKE
        private void button4_Click(object sender, EventArgs e)
        {
            textBoxVMViewer.Text = ("You Have Selected Coke, Now Despensing");

            textBoxVMStateViewer.Text = (Program.programState.ToString());

            Program.ManageState(VendingMachineStateEnum.Sold);

            textBoxVMStateViewer.Text = (Program.programState.ToString());

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
            string strAllPurchaseTransactions = "";

            foreach (var purchaseTransactions in myPurchaseTransactionsList)
            {
                strAllPurchaseTransactions += "Quarters Amount" + " " + purchaseTransactions.PurchaseTotal + ", " + "Poduct" + " " + purchaseTransactions.Product.Name + ", " + "Qty" + " " + purchaseTransactions.PurchaseQty + ", " + "Timestamp" + " " + purchaseTransactions.Time + ", " + "Machine" + " " + purchaseTransactions.VendingMachine.Name;
                strAllPurchaseTransactions += Environment.NewLine;
            }

            textBoxVMViewer.Text = strAllPurchaseTransactions;
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
