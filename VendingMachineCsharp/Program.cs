using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineCsharp.Repositories;

namespace VendingMachineCsharp
{
    static class Program
    {
        public static VendingMachine myVendingMachine;

        public static Inventory myInventory;

        public static InventoryService myInventoryService;

        public static VendingMachineStateEnum programState;

        public static void ManageState(VendingMachineStateEnum currentState)
        {
            Program.programState = currentState;

            Form1.ActiveForm.Controls["textBoxVMStateViewer"].Text = Program.programState.ToString();

            switch (currentState)
            {
                case VendingMachineStateEnum.NoQuarter:
                    Form1.ActiveForm.Controls["button1"].Enabled = true; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = false; //Eject
                    Form1.ActiveForm.Controls["button3"].Enabled = false; //Sprite
                    Form1.ActiveForm.Controls["button4"].Enabled = false; //Coke
                    Form1.ActiveForm.Controls["button5"].Enabled = true; //Inventory
                    Form1.ActiveForm.Controls["button6"].Enabled = false; //Purchase Transaction
                    break;
                case VendingMachineStateEnum.Sold:
                    Form1.ActiveForm.Controls["button1"].Enabled = true; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = false; //Eject
                    Form1.ActiveForm.Controls["button3"].Enabled = false; //Sprite
                    Form1.ActiveForm.Controls["button4"].Enabled = false; //Coke
                    Form1.ActiveForm.Controls["button5"].Enabled = true; //Inventory
                    Form1.ActiveForm.Controls["button6"].Enabled = true; //Purchase Transaction
                    break;
                case VendingMachineStateEnum.HasQuarter:
                    Form1.ActiveForm.Controls["button1"].Enabled = false; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = true; //Eject

                    //if CheckInventory("Sprite") then {
                    if (CheckInventory("sprite"))
                    { 
                        Form1.ActiveForm.Controls["button3"].Enabled = true; 
                    }
                    else
                    {
                        Form1.ActiveForm.Controls["button3"].Enabled = false;
                    }

                    //if CheckInventory("coke") then {
                    if (CheckInventory("coke"))
                    {
                        Form1.ActiveForm.Controls["button4"].Enabled = true;
                    }
                    else
                    {
                        Form1.ActiveForm.Controls["button4"].Enabled = false;
                    }

                    Form1.ActiveForm.Controls["button4"].Enabled = true; //Coke
                    Form1.ActiveForm.Controls["button5"].Enabled = true; //Inventory
                    Form1.ActiveForm.Controls["button6"].Enabled = false; //Purchase Transaction
                    break;
                case VendingMachineStateEnum.SoldOut:
                    Form1.ActiveForm.Controls["textBoxVMStateViewer"].Text = ("Now you can select a soda");
                    Form1.ActiveForm.Controls["button1"].Enabled = true; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = false; //Eject
                    Form1.ActiveForm.Controls["button3"].Enabled = false; //Sprite
                    Form1.ActiveForm.Controls["button4"].Enabled = false; //Coke
                    Form1.ActiveForm.Controls["button5"].Enabled = true; //Inventory
                    Form1.ActiveForm.Controls["button6"].Enabled = true; //Purchase Transaction
                    break;
            }
        }

        public static bool CheckInventory(string currentProduct)
        {

            List<Inventory> myInventoryList;

            myInventoryService = new InventoryService();
            myInventoryList = myInventoryService.GetAll();
            //myInventoryList = myInventoryService.Update(Inventory);

            //Pull current quantity from the database for the product
            string strQtyInventory = "";

            foreach (var inventory in myInventoryList)
            {
                strQtyInventory += inventory.Product.Name + " " + inventory.Qty;
                strQtyInventory += Environment.NewLine;
            }

            //If quantity > 0 then return true;
            //if(myInventory.Qty > 0)
            //{
            //    return true;
            //}

            ////Else return false;
            //else
            //{
            return false;
            //}

            //InventoryRepository.Update();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            myVendingMachine = new VendingMachine();

            //Program.ManageState(VendingMachineStateEnum.NoQuarter);
        }
    }
}
