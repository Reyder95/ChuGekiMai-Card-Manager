using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ChuGekiMai_Card_Manager
{
    public partial class Form1 : Form
    {
        Card selectedCard = null;

        BindingList<Card> cards = new BindingList<Card>();

        string addedCardName = "";
        TextBox[] textBoxes = new TextBox[5];

        public Form1()
        {
            InitializeComponent();

            this.cardList.DataSource = cards;
            this.cardList.DisplayMember = "Name";

            this.textBoxes[0] = this.textBox2;
            this.textBoxes[1] = this.textBox1;
            this.textBoxes[2] = this.textBox4;
            this.textBoxes[3] = this.textBox3;
            this.textBoxes[4] = this.textBox5;

            for (int i = 0; i < this.textBoxes.Length; i++)
            {
                this.textBoxes[i].KeyDown += TextBox_KeyDown;
            }

            ReadCardsFromFile();
        }

        private void cardSelect_Click(object sender, EventArgs e)
        {
            selectedCard = cards[this.cardList.SelectedIndex];

            this.cardName.Text = selectedCard.Name;

            WriteToAimeTxt();
        }

        private void cardDelete_Click(object sender, EventArgs e)
        {
            cards.RemoveAt(this.cardList.SelectedIndex);
            this.cardList.DataSource = cards;
        }

        private void inputCardName_TextChanged(object sender, EventArgs e)
        {
            addedCardName = this.inputCardName.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 4)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 4)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 4)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 4)
            {
                textBox5.Focus();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                TextBox currentTextBox = sender as TextBox;

                string clipboardText = Clipboard.GetText();

                clipboardText = new string(Array.FindAll(clipboardText.ToCharArray(), char.IsDigit));

                if (clipboardText.Length == 20)
                {
                    string[] parts = new string[5];

                    for (int i = 0; i < 5; i++)
                    {
                        this.textBoxes[i].Text = clipboardText.Substring(i * 4, 4);
                    }

                    this.textBoxes[4].Focus();
                }
            }

            e.Handled = true;
        }

        private void cardAdd_Click(object sender, EventArgs e)
        {
            Card newCard = CreateCard();

            if (newCard.Id.Length != 20) return;

            if (newCard.Name == "") return;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = "";
            }

            Console.WriteLine(newCard.Id);

            cards.Add(newCard);
        }

        private Card CreateCard()
        {
            string combinedId = "";
            for (int i = 0; i < textBoxes.Length; i++)
            {
                combinedId += textBoxes[i].Text;
            }

            return new Card(combinedId, this.addedCardName);
        }

        private void generateCard_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < textBoxes.Length; i++)
            {
                int randomNumber = random.Next(0, 10000);
                string randomString = randomNumber.ToString("D4");

                if (i == 0)
                {
                    if (randomString[0] == '3')
                    {
                        char[] charArray = randomString.ToCharArray();
                        charArray[0] = '4';

                        randomString = new string(charArray);
                    }
                }

                textBoxes[i].Text = randomString;
            }

        }

        public void WriteCardsToFile()
        {
            string jsonString = JsonConvert.SerializeObject(this.cards, Formatting.Indented);
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filepath = Path.Combine(directoryPath, "cards.json");

            File.WriteAllText(filepath, jsonString);

            Console.WriteLine($"JSON file saved to: {filepath}");
        }

        public void ReadCardsFromFile()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filepath = Path.Combine(directoryPath, "cards.json");

            if (File.Exists(filepath))
            {
                Console.WriteLine("Hi");
                string jsonString = File.ReadAllText(filepath);

                this.cards = JsonConvert.DeserializeObject<BindingList<Card>>(jsonString);
                Console.WriteLine(this.cards.Count);
                this.cardList.DataSource = this.cards;
            }
        }

        public void WriteToAimeTxt()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filepath = Path.Combine(directoryPath, "../aime.txt");
            File.WriteAllText(filepath, this.selectedCard.Id);

            Console.WriteLine($"Aime card ID written to {filepath}.");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (cards.Count > 0)
                WriteCardsToFile();
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            ReadCardsFromFile();
        }
    }
}
