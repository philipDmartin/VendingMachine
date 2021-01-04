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

        //PurchaseTransactionsService myPurchaseTransactionsService;
        //List<PurchaseTransactions> myPurchaseTransactionsList;

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

            //myPurchaseTransactionsService = new PurchaseTransactionsService();
            //myPurchaseTransactionsList = myPurchaseTransactionsService.GetAll();

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
            InventoryService myInventoryService;
            Inventory mySpriteInventory;

            PurchaseTransactionsService myPurchaseTransactionsService;
            PurchaseTransactions myPurchaseTransactions;

            myInventoryService = new InventoryService();
            
            myPurchaseTransactionsService = new PurchaseTransactionsService();
            myPurchaseTransactions = new PurchaseTransactions();

            myPurchaseTransactions.PurchaseTotal = 1; //1 is a quarter
            myPurchaseTransactions.ProductId = 1; //Id for sprite
            myPurchaseTransactions.PurchaseQty = 1;
            myPurchaseTransactions.Time = DateTime.Now;
            myPurchaseTransactions.VendingMachineId = 1; //Id for Vh1

            mySpriteInventory = myInventoryService.Get(1);

            //Decrement inventory qty 
            mySpriteInventory.Qty = (mySpriteInventory.Qty - 1);

            //Start a C# transaction later

            myPurchaseTransactionsService.Add(myPurchaseTransactions);
            myInventoryService.Update(mySpriteInventory);

            //End C# transaction here

            textBoxVMViewer.Text = ("You Have Selected Sprite, Now Despensing");

            textBoxVMStateViewer.Text = (Program.programState.ToString());
            Program.ManageState(VendingMachineStateEnum.Sold);
            textBoxVMStateViewer.Text = (Program.programState.ToString());
        }

        //COKE
        private void button4_Click(object sender, EventArgs e)
        {
            InventoryService myInventoryService;
            Inventory myCokeInventory;

            PurchaseTransactionsService myPurchaseTransactionsService;
            PurchaseTransactions myPurchaseTransactions;

            myInventoryService = new InventoryService();

            myPurchaseTransactionsService = new PurchaseTransactionsService();
            myPurchaseTransactions = new PurchaseTransactions();

            myPurchaseTransactions.PurchaseTotal = 1; //1 is a quarter
            myPurchaseTransactions.ProductId = 2; //Id for coke
            myPurchaseTransactions.PurchaseQty = 1;
            myPurchaseTransactions.Time = DateTime.Now;
            myPurchaseTransactions.VendingMachineId = 1; //Id for Vh1

            myCokeInventory = myInventoryService.Get(2);

            //Decrement inventory qty 
            myCokeInventory.Qty = (myCokeInventory.Qty - 1);

            //Start a C# transaction later

            myPurchaseTransactionsService.Add(myPurchaseTransactions);
            myInventoryService.Update(myCokeInventory);

            //End C# transaction here


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
            PurchaseTransactionsService myPurchaseTransactionsService;
            List<PurchaseTransactions> myPurchaseTransactionsList;

            myPurchaseTransactionsService = new PurchaseTransactionsService();

            myPurchaseTransactionsList = myPurchaseTransactionsService.GetAll();

            Program.ManageState(Program.programState);

            string strAllPurchaseTransactions = "";

            foreach (var purchaseTransactions in myPurchaseTransactionsList)
            {
                strAllPurchaseTransactions += "Quarters Amount:" + " " + purchaseTransactions.PurchaseTotal + ", " + "Poduct:" + " " + purchaseTransactions.Product.Name + ", " + "Qty:" + " " + purchaseTransactions.PurchaseQty + ", " + "Timestamp:" + " " + purchaseTransactions.Time + ", " + "Machine:" + " " + purchaseTransactions.VendingMachine.Name;
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
