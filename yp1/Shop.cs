using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        //Переход в раздел по добавлению продуктов
        private void добавитьПродуктToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel1.Visible = true;
            panel3.Visible = true;
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

        //Добавление продукта в список всех продуктов
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
        //Проверка на ввод цифр
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //Переход в раздел совершения покупок
        private void сделатьПокупкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            panel2.Visible = true;
            foreach (var product in shop1.Products)
            {
                if(product.Value>0)
                listBox2.Items.Add(product.Key.GetInfo() + " - Количество: " + product.Value);
            }

        }

        //Добавление товара в корзину
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
        //
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
        //Покупка всейкорзины
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
        //закрытие раздела по добавлению продукта
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            textBox1.Text = "";
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            listBox1.Items.Clear();
        }
        //закрытие раздела по покупке
        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            numericUpDown1.Value = 1;
            label1.Text = "0";
            listBox3.Items.Clear();
            panel2.Visible = false;
        }
        //выбор товарар для его дозакупки
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

        private void дискиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }


























        //ПЕСЕНКИ
        Playlist playlist = new Playlist();
        Song song = new Song();



        //Обновляет данные о текущей песне
        private void UpdateSong()
        {
            song = playlist.CurrentSong();
            autor.Text = song.Author;
            name.Text = song.Title;
            file.Text = song.Filename;
        }


        //Добавление новой песни
        private void Add_song(object sender, EventArgs e)
        {
            if(Proverka(AuthorLine.Text, NameLine.Text, PathLine.Text))
            {
                string author, name, filename;
                author = AuthorLine.Text;
                name = NameLine.Text;
                filename = PathLine.Text;
                playlist.AddSong(author, name, filename);
                AuthorLine.ResetText();
                NameLine.ResetText();
                PathLine.ResetText();
                MessageBox.Show("Песня добавлена");
                autor.Text= author;
                this.name.Text = name;
                file.Text = filename;
               /* song = playlist.CurrentSong();*/
               /* UpdateSong();*/
            }
            else
            {
                MessageBox.Show("Вы не заполнили поля");
            }
           
        }


        //Проверка на заполниние полей
        private bool Proverka(string author, string name, string filename)
        {
            return !string.IsNullOrWhiteSpace(author) &&
                   !string.IsNullOrWhiteSpace(name) &&
                   !string.IsNullOrWhiteSpace(filename);
        }



        //Очистка плейлиста
        private void Clear_pl(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите продолжить?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Плейлист удален");
                playlist.Clear();
                autor.Text = "";
                name.Text = "";
                file.Text = "";
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Операция отменена");
            }
        }
        //пролистывание песни вперед
        private void Nextsn_Click(object sender, EventArgs e)
        {
            try
            {
                playlist.NextSong();
                song = playlist.CurrentSong();
                autor.Text = song.Author;
                name.Text = song.Title;
                file.Text = song.Filename;
            }
            catch(Exception ex)
            {

            }
           
        }
        //пролистывание песни назад
        private void Backsn_Click_1(object sender, EventArgs e)
        {
            try
            {
                playlist.PreviousSong();
                song = playlist.CurrentSong();
                autor.Text = song.Author;
                name.Text = song.Title;
                file.Text = song.Filename;
            }
            catch (Exception ex)
            {

            }
           
        }
            

        //Переход к началу списка
        private void ToStart(object sender, EventArgs e)
        {
            try
            {
                playlist.GoToStart();
                UpdateSong();
            }
            catch (Exception ex)
            {

            }
        }
        //удаление текущей песни
        private void Delete_CurrentSong(object sender, EventArgs e)
        {
            try
            {
                playlist.RemoveSong(song);
                UpdateSong();
            
                MessageBox.Show("Песня была удалена");
            }
            catch (Exception ex)
            {
               
            }
           
        }
        //Удаление песни по введенным данным
        private void Delete_with_name(object sender, EventArgs e)
        {
            try
            {
                playlist.RemoveSong(song);
                UpdateSong();
            }
            catch(Exception ex)
            {

            }
          
        }
        //Удаление при помощи индекса песни
        private void Delete_with_index(object sender, EventArgs e)
        {
            try
            {
                playlist.RemoveSong(Convert.ToInt32(numericUpDown5.Value));
                UpdateSong();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Извините такого индекса не существует");

            }
        }
        //переход по индексу
        private void by_index(object sender, EventArgs e)
        {
            try
            {
                playlist.GoToSong(Convert.ToInt32(numericUpDown4.Value));
                UpdateSong();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Извините такого индекса не существует");

            }
        }
    }
}
