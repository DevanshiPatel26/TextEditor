// Name: Devanshi Patel
// Student ID: 100805084
// Date: March 28, 2021
// Decription: This application will allow user to enter text and it contains different menu such as File, Edit, Help.
//             It also has sub-menus like cut, copy, paste, new, open, save, save as, etc

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class formTextEditor : Form
    {

        // This is the filepath of the active file, if applicable
        string filePath = String.Empty;

        public formTextEditor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        #region "Event Handlers"

        /// <summary>
        /// It will start the new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickFileNew(object sender, EventArgs e)
        {
            // Clear the text box
            textBoxEditor.Clear();

            // Clear the filePath
            filePath = String.Empty;
            
            // Update the title
            UpdateTitle();
        }


        /// <summary>
        /// On clicking, it will open the dialog box and open the file in the text edito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickFileOpen(object sender, EventArgs e)
        {

            // Create a open dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            // Iteration
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                // If a reader clicks OK, initialize the StreamReader Object
                FileStream myFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(myFile);

                // Display the text from the file
                textBoxEditor.Text = reader.ReadToEnd();

                // Close the reader
                reader.Close();
            }
            

        }


        /// <summary>
        /// It will save the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickFileSave(object sender, EventArgs e)
        {
            // If filePath is empty
            if (filePath == String.Empty)
            {
                // Call Save As event handler
                ClickFileSaveAs(sender, e);
            }

            // Else
            else
            {
                // Save the filePath
                SaveTextFile(filePath);
            }
        }


        /// <summary>
        /// It will save the file as.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickFileSaveAs(object sender, EventArgs e)
        {
            // Create a save dialog
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // Iteration
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Save filePath as the filename
                filePath = saveDialog.FileName;
                SaveTextFile(filePath);

                // Update the title
                UpdateTitle();
            }
        }


        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickFileExit(object sender, EventArgs e)
        {
            // Exit the application
            Close();
        }


        /// <summary>
        /// Used to copy the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCopy(object sender, EventArgs e)
        {
            // Copy the selected text
            
            if (textBoxEditor.Text.Length != 0)
            {
                Clipboard.SetText(textBoxEditor.SelectedText);
            }

        }


        /// <summary>
        ///  Used to remove the selected text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCut(object sender, EventArgs e)
        {
            Clipboard.Clear();

            if (textBoxEditor.Text.Length != 0)
            {
                // Remove the selected text
                Clipboard.SetText(textBoxEditor.SelectedText);
                textBoxEditor.SelectedText = "";
            }
        }


        /// <summary>
        /// It will paste the copied text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPaste(object sender, EventArgs e)
        { 
            // Paste the copied text
            textBoxEditor.Text = Clipboard.GetText();
        }


        /// <summary>
        /// Gives explanation about text editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickAbout(object sender, EventArgs e)
        {
            // Displays the message
            MessageBox.Show("Text Editor\n" + "By Devanshi Patel\n\n" +
                "For NETD 2202\n" + "Lab 5\n" + "March 27, 2021", "About..");
        }
        #endregion


        #region "Functions"

        /// <summary>
        /// Display the title
        /// </summary>
        public void UpdateTitle()
        {
            this.Text = "Text Editor";

            if (filePath != String.Empty)
            {
                this.Text += " - " + filePath;
            }
        }

        /// <summary>
        /// Function used to save the file
        /// </summary>
        /// <param name="path"></param>
        public void SaveTextFile(string path)
        {
            // If a writer clicks OK, initialize the StreamWriter Object
            FileStream myFile = new FileStream (path, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(myFile);

            // Save the written text
            writer.Write(textBoxEditor.Text);

            // Close the writer
            writer.Close();
        }


        #endregion

        
    }
}
