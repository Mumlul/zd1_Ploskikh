using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yp1
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }
        Sh shop1 = new Sh();
        private void магазинToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьПродуктToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listBox1.Items.Clear();
            foreach (var product in shop1.Products)
            {
                listBox1.Items.Add(product.Key.GetInfo() + " - Количество: " + product.Value);
            }
        }


        public static bool IsOnlyLetters(string input)
        {
            return input.All(char.IsLetter);
        }

        //Добавление продукта в список 
        private void button1_Click(object sender, EventArgs e)
        {

            bool isOnlyLetters = IsOnlyLetters(textBox1.Text);

            if (textBox1.Text != "")
            {
                if (shop1.pr(textBox1.Text))
                {
                    shop1.Dop(textBox1.Text, Convert.ToInt32(numericUpDown2.Value));
                    listBox1.Items.Clear();
                    foreach (var product in shop1.Products)
                    {
                        listBox1.Items.Add(product.Key.GetInfo() + " - Количество: " + product.Value);
                    }
                }
                else
                {
                    if (isOnlyLetters)
                    {
                        Product p = new Product(textBox1.Text, Convert.ToDecimal(numericUpDown3.Value));
                        shop1.AddProduct(p, Convert.ToInt32(numericUpDown2.Value));
                        listBox1.Items.Add(p.GetInfo() + "Kol-vo:" + numericUpDown2.Value);
                    }
                    else
                    {
                        MessageBox.Show("Не верный формат названия");
                        textBox1.Text = "";
                    }
                }
               
            }




        }
        //проверка ввода цены
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; 
            }
        }

        private void Shop_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void сделатьПокупкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            panel2.Visible = true;
            foreach (var product in shop1.Products)
            {
                if(product.Value>0)
                listBox2.Items.Add(product.Key.GetInfo() + " - Количество: " + product.Value);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = listBox2.SelectedItem.ToString();
                string[] parts = name.Split(';');
                string namePart = parts[0];
                string[] nameComponents = namePart.Split(':');
                string productName = nameComponents[1].Trim();

                string kk = shop1.Korzina(productName, Convert.ToInt32(numericUpDown1.Value));
                string totalPriceValue = ExtractTotalPrice(kk);
                double pr = Convert.ToInt32(label8.Text);
                pr += Convert.ToInt32(totalPriceValue);
                label8.Text = pr.ToString();
                listBox3.Items.Add(kk);
                listBox2.Items.Clear();
                foreach (var product in shop1.Products)
                {
                    listBox2.Items.Add(product.Key.GetInfo() + " - Количество: " + product.Value);
                }
            }
            catch (Exception ex)
            {

            }
            

        }

        public static string ExtractTotalPrice(string input)
        {
            
            string[] parts = input.Split('-');

            
            foreach (var part in parts)
            {
                if (part.Trim().StartsWith("Общая цена:"))
                {
                    
                    string[] priceComponents = part.Split(':');
                    return priceComponents[1].Trim(); 
                }
            }

            return null; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox3.Items.Clear();
               
                MessageBox.Show("Поздравляю вы совершили покупку она составила:" + label8.Text);
                int summa = Convert.ToInt32(label10.Text);
                
                summa += Convert.ToInt32(label8.Text);
                label10.Text = summa.ToString();
                label8.Text = "0";
            }
            catch(Exception ex)
            {

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            textBox1.Text = "";
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            numericUpDown1.Value = 1;
            label1.Text = "0";
            listBox3.Items.Clear();
            panel2.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = listBox1.SelectedItem.ToString();
            string[] parts = name.Split(';');
            string namePart = parts[0];
            string[] nameComponents = namePart.Split(':');
            string productName = nameComponents[1].Trim();
            textBox1.Text = productName;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
