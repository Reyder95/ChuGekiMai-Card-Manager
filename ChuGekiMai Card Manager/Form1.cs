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
        Card selectedCard = null;   // The current card selected by the program. This card's ID is entered into aime.txt upon being selected

        BindingList<Card> cards = new BindingList<Card>();  // List of cards in the database. Loaded upon app load, taken from a JSON file.

        string addedCardName = "";  // The data for the card name text box for adding a new card
        TextBox[] textBoxes = new TextBox[5];   // The list of text boxes for inputting a card ID.

        public Form1()
        {
            InitializeComponent();

            this.Text = "ChuGekiMai Card Manager";

            // Sets the card list ComboBox datasource as the "cards" BindingList, while displaying only the "Name"
            this.cardList.DataSource = cards;
            this.cardList.DisplayMember = "Name";

            // Loading the textBoxes array with the textboxes in order of left to right (these names aren't in the proper order ...)
            this.textBoxes[0] = this.textBox2;
            this.textBoxes[1] = this.textBox1;
            this.textBoxes[2] = this.textBox4;
            this.textBoxes[3] = this.textBox3;
            this.textBoxes[4] = this.textBox5;

            // For each textbox, assign them the same KeyDown and KeyPress events.
            for (int i = 0; i < this.textBoxes.Length; i++)
            {
                this.textBoxes[i].KeyDown += TextBox_KeyDown;
                this.textBoxes[i].KeyPress += TextBox_KeyPress;
            }

            ReadCardsFromFile();    // Load the cards from the database into cards
        }

        // Select button click
        private void cardSelect_Click(object sender, EventArgs e)
        {
            if (this.cards.Count == 0) return;  // Checks if any cards exist

            selectedCard = cards[this.cardList.SelectedIndex];  // Select the current ComboBox card as the card we want to use

            this.cardName.Text = selectedCard.Name; // Sets the name on the top for clarification

            WriteToAimeTxt();   // Writes the card ID to the aime.txt file in the parent directory.
        }

        // Delete button click
        private void cardDelete_Click(object sender, EventArgs e)
        {
            if (this.cards.Count == 0) return;  // Checks if any cards exist

            cards.RemoveAt(this.cardList.SelectedIndex);    // Remove an element from the cards list based on the ComboBox selected index
        }

        // Binds the addedCardName variable to the inputCardName textbox, for adding a new card.
        private void inputCardName_TextChanged(object sender, EventArgs e)
        {
            addedCardName = this.inputCardName.Text;
        }

        // -- Card ID text boxes. When the length of the textbox reaches 4, skip to the next text box for seemless ID input.
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

        // When a key is pressed in the textbox, only enter in text if it is a number
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // When a key is pressed, if it's a paste command, paste the clipboard across the entire set of text boxes for seemless data input.
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // If both CTRL and the V key is pressed, we are pasting. Override the paste method.
            if (e.Control && e.KeyCode == Keys.V)
            {
                TextBox currentTextBox = sender as TextBox; // Get current text box we are in
                    
                string clipboardText = Clipboard.GetText(); // Get the text from the clipboard

                clipboardText = new string(Array.FindAll(clipboardText.ToCharArray(), char.IsDigit));   // Get all characters from the clipboard that are digits.

                // If our clipboard contains 20 digits, we have a valid ID
                if (clipboardText.Length == 20)
                {  
                    // For each textbox, extract 4 elements and paste it into that text box.
                    for (int i = 0; i < 5; i++)
                    {
                        this.textBoxes[i].Text = clipboardText.Substring(i * 4, 4);
                    }

                    this.textBoxes[4].Focus();  // Set the final textbox as focus
                }
            }

            // Cancel the real paste command by confirming this text box has already been "handled".
            e.Handled = true;
        }

        // Create a new card in memory with the data provided
        private void cardAdd_Click(object sender, EventArgs e)
        {
            if (textBoxes[0].Text[0] == '3') return;    // Checks whether first digit is a 3
            Card newCard = CreateCard();    // Create a new card using our data

            // Only continue if our ID is valid
            if (newCard.Id.Length != 20) return;

            // Only continue if our name is valid
            if (newCard.Name == "") return;

            // Remove all text in the textboxes as a "reset"
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = "";
            }

            cards.Add(newCard); // Add the new card to our in-memory database.
        }

        // Create a new card based on the information entered
        private Card CreateCard()
        {
            // Take the text boxes and combine them into one string
            string combinedId = "";
            for (int i = 0; i < textBoxes.Length; i++)
            {
                combinedId += textBoxes[i].Text;
            }

            // Return a new card object with the combined ID string and the name
            return new Card(combinedId, this.addedCardName);
        }

        // Generates a random valid card ID. The beginning 
        private void generateCard_Click(object sender, EventArgs e)
        {
            Random random = new Random();   // Seed Random

            // For each text box
            for (int i = 0; i < textBoxes.Length; i++)
            {
                int randomNumber = random.Next(0, 10000); // Generate a random num from 0 to 9999
                string randomString = randomNumber.ToString("D4");  // Ensure it pads the remaining numbers with 0s. Such like a 1 would be 0001

                // If the first digit generates as a 3, make it a 4 instead
                if (i == 0)
                {
                    if (randomString[0] == '3')
                    {
                        char[] charArray = randomString.ToCharArray();
                        charArray[0] = '4';

                        randomString = new string(charArray);
                    }
                }

                textBoxes[i].Text = randomString;   // Set the text box to the randomly generated number
            }

        }

        // Write the current card DB to a JSON file upon clicking Save
        public void WriteCardsToFile()
        {
            // Serialize to JSON, and get appropriate directory path
            string jsonString = JsonConvert.SerializeObject(this.cards, Formatting.Indented);
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filepath = Path.Combine(directoryPath, "cards.json");

            File.WriteAllText(filepath, jsonString);    // Write the text to the file
        }

        // Read the current json database and insert it into the cards list
        public void ReadCardsFromFile()
        {
            // Get the directory in which cards.json should be
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filepath = Path.Combine(directoryPath, "cards.json");

            // If the file exists, read the data and deserialize it into cards. Reset the cardList data source
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);

                this.cards = JsonConvert.DeserializeObject<BindingList<Card>>(jsonString);
                Console.WriteLine(this.cards.Count);
                this.cardList.DataSource = this.cards;
            }
        }

        // Writes the current card ID to aime.txt upon being selected
        public void WriteToAimeTxt()
        {
            // Targets an aime.txt file in the parent directory to write to or create
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filepath = Path.Combine(directoryPath, "../aime.txt");

            File.WriteAllText(filepath, this.selectedCard.Id); // Writes the ID to the aime.txt file
        }

        // Save button click, write cards to file
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (cards.Count > 0)
                WriteCardsToFile();
        }

        // When revert is clicked, reverts to last saved data
        private void revertButton_Click(object sender, EventArgs e)
        {
            ReadCardsFromFile();
        }
    }
}
