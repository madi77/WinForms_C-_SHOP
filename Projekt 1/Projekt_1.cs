using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Projekt_1
{

    class Projekt_1 : Form
    {
        public static DataGridView DataGridView1 = VisualItems.CreateDataGridView();
        public static DataGridView DataGridView2 = VisualItems.CreateDataGridView();
        public Label LabelTotalPayCart = VisualItems.CreateLabel("0kr", 15, AnchorStyles.Bottom);
        public static Label LabelTotalPay = VisualItems.CreateLabel("0kr", 15, AnchorStyles.Bottom);
        public static TextBox TextBoxForCoupon = VisualItems.CreatTextBox();
        private static double Discount = 1;

        public Projekt_1()
        {
            DataGridView1 = FileHandler.DataGridFromFile(@"Products.csv");

            Text = "Shopping Cart made by M & M 2017";
            Size = new Size(1000, 620);
            StartPosition = FormStartPosition.CenterScreen;

            //Creation of tables
            var mainTable = VisualItems.CreateTableLayoutPanel(3, 5, Color.LightCyan);
            var removeAndClearCartTable = VisualItems.CreateTableLayoutPanel(2, 1, Color.LightCyan);
            var sumAndValidateTable = VisualItems.CreateTableLayoutPanel(2, 6, Color.LightSkyBlue);

            //Creation of buttons from method in another file.
            var buttonAddToCart = VisualItems.CreateButton("Add to Cart");
            var buttonCheckout = VisualItems.CreateButton("CHECKOUT");
            var buttonRemoveProduct = VisualItems.CreateButton("Remove");
            var buttonClearCart = VisualItems.CreateButton("Clear Cart");
            var buttonValidate = VisualItems.CreateButton("Validate");

            //Creation of Labels from method in another file.
            var shoppingCart = VisualItems.CreateLabel("Shopping Cart", 20, AnchorStyles.Bottom);
            var labelProducts = VisualItems.CreateLabel("Products", 20, AnchorStyles.Bottom);
            var labelTotalInCart = VisualItems.CreateLabel("Total in cart:", 12, AnchorStyles.Bottom);
            var labelTotalToPay = VisualItems.CreateLabel("Total to pay:", 12, AnchorStyles.Bottom);
            var labelEnterCouponCode = VisualItems.CreateLabel("Enter coupon code:", 12, AnchorStyles.Bottom);

            //Design
            Controls.Add(mainTable);
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 4));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 4));
            mainTable.Controls.Add(DataGridView2, 1, 2);
            mainTable.Controls.Add(labelProducts, 0, 1);
            mainTable.Controls.Add(shoppingCart, 1, 1);
            mainTable.Controls.Add(DataGridView1, 0, 2);
            mainTable.Controls.Add(buttonAddToCart, 0, 3);
            mainTable.Controls.Add(buttonCheckout, 2, 3);
            mainTable.SetColumnSpan(buttonCheckout, 1);
            mainTable.Controls.Add(removeAndClearCartTable, 1, 3);
            mainTable.Controls.Add(sumAndValidateTable, 2, 2);

            removeAndClearCartTable.Controls.Add(buttonRemoveProduct, 0, 0);
            removeAndClearCartTable.Controls.Add(buttonClearCart, 1, 0);

            sumAndValidateTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            sumAndValidateTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            sumAndValidateTable.RowStyles.Add(new RowStyle(SizeType.Percent, 14));
            sumAndValidateTable.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            sumAndValidateTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            sumAndValidateTable.RowStyles.Add(new RowStyle(SizeType.Percent, 41));
            sumAndValidateTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            sumAndValidateTable.Controls.Add(labelTotalInCart, 0, 0);
            sumAndValidateTable.Controls.Add(labelTotalToPay, 0, 6);
            sumAndValidateTable.Controls.Add(labelEnterCouponCode, 0, 2);
            sumAndValidateTable.Controls.Add(LabelTotalPayCart, 1, 0);
            sumAndValidateTable.Controls.Add(TextBoxForCoupon, 1, 2);
            sumAndValidateTable.Controls.Add(buttonValidate, 1, 3);
            sumAndValidateTable.Controls.Add(LabelTotalPay, 1, 6);
            sumAndValidateTable.SetColumnSpan(labelEnterCouponCode, 2);
            sumAndValidateTable.SetColumnSpan(TextBoxForCoupon, 2);
            sumAndValidateTable.SetColumnSpan(buttonValidate, 2);

            //Eventhandelers
            buttonAddToCart.Click += DataGridView1_SelectionRowAdd;
            buttonRemoveProduct.Click += DataGridView2_SelectionRowDelete;
            buttonClearCart.Click += DataGridView2_ClearCart;
            DataGridView2.CellValueChanged += DataGridView2_CellValueChanged;
            buttonValidate.Click += ButtonValidate_Click;
            buttonCheckout.Click += ButtonCheckout_Click;
        }

        public static void ClearAll()
        {
            DataGridView2.Rows.Clear();
            LabelTotalPay.ResetText();
            ResetDiscount();
            LabelTotalPay.Text = "0kr";
        }
        public void TotalPayCartUpdateFromDataGrid2()
        {

            Double sum = 0;
            for (int i = 0; i < DataGridView2.Rows.Count - 1; i++)
            {
                try
                {
                    double numberOfProducts = double.Parse(DataGridView2.Rows[i].Cells[1].Value.ToString());
                    double productPrice = double.Parse(DataGridView2.Rows[i].Cells[2].Value.ToString());
                    sum = sum + numberOfProducts * productPrice;
                }
                catch (NullReferenceException)
                {
                }
            }
            LabelTotalPayCart.Text = sum.ToString() + "kr";
        }

        public static void ResetDiscount()
        {
            Discount = 1;
            TextBoxForCoupon.Text = "";
        }

        public void UppdateTotalToPay()
        {
            double sumTotal = 0;
            string cartTotal = LabelTotalPayCart.Text.ToString();
            cartTotal = cartTotal.TrimEnd('k', 'r');
            sumTotal = Discount * double.Parse(cartTotal);
            LabelTotalPay.Text = sumTotal.ToString() + "kr";
        }

        public void DataGridView2_ClearCart(object sender, EventArgs e)
        {
            DataGridView2.Rows.Clear();
            TotalPayCartUpdateFromDataGrid2();
            UppdateTotalToPay();
            ResetDiscount();
        }


        private void ButtonValidate_Click(object sender, EventArgs e)
        {

            bool discount = Calculate.DiscountCheck(TextBoxForCoupon.Text);
            if (discount)
            {
                Projekt_1.Discount = .8;
                UppdateTotalToPay();
            }
            else
            {
                ResetDiscount();
                MessageBox.Show("Invalid discount code.");
                UppdateTotalToPay();
            }
            TextBoxForCoupon.Text = "";
        }
        private void ButtonCheckout_Click(object sender, EventArgs e)
        {
            Hide();
            var formReceipt = new Receipt();
            formReceipt.Show();
            

        }
        private void DataGridView2_SelectionRowDelete(object sender, EventArgs e)
        {

            try
            {
                int rowIndex = DataGridView2.CurrentCell.RowIndex;
                DataGridView2.Rows.RemoveAt(rowIndex);
            }
            catch (NullReferenceException)
            {
            }
            catch (InvalidOperationException)
            {
            }
            TotalPayCartUpdateFromDataGrid2();
            UppdateTotalToPay();
        }
        private void DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TotalPayCartUpdateFromDataGrid2();
            UppdateTotalToPay();
        }
        private void DataGridView1_SelectionRowAdd(object sender, EventArgs e)
        {

            // If the choosen product already is in datagridview2 add one more to the quantity of the product.
            for (int i = 0; i < DataGridView2.Rows.Count - 1; i++)
            {
                string selectedItems = DataGridView1.SelectedRows[DataGridView1.SelectedRows.Count - 1].Cells[0].Value.ToString();
                string allRowsOfDataGridView2 = DataGridView2.Rows[i].Cells[0].Value.ToString();
                if (selectedItems == allRowsOfDataGridView2)
                {
                    int cartProductsToAdd = int.Parse(DataGridView2.Rows[i].Cells[2].Value.ToString());
                    cartProductsToAdd++;
                    DataGridView2.Rows[i].Cells[2].Value = cartProductsToAdd.ToString();
                    return;
                }
            }
            // adds the choosen product to datagridview2 when it isnt found in datagrid2
            for (int j = 0; j < DataGridView1.SelectedRows.Count; j++)
            {
                int index = DataGridView2.Rows.Add();
                int amoutOfProductToCartRow = 0;
                try
                {
                    amoutOfProductToCartRow = int.Parse(DataGridView2.Rows[index].Cells[2].Value.ToString());
                }
                catch (NullReferenceException)
                {
                }
                amoutOfProductToCartRow++;
                DataGridView2.Rows[index].Cells[0].Value = DataGridView1.SelectedRows[j].Cells[0].Value.ToString();
                DataGridView2.Rows[index].Cells[1].Value = DataGridView1.SelectedRows[j].Cells[1].Value.ToString();
                DataGridView2.Rows[index].Cells[2].Value = amoutOfProductToCartRow.ToString();
            }
        }












    }
}












