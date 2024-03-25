using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redactor1
{
    public partial class Form1 : Form
    {
        private string FileN = "New File";
        private DialogResult a;

        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDLG.FileName == "" && saveDLG.FileName == "")
                mnuSaveAs_Click(sender, e);
            else
            {
                if (openDLG.FileName != "")
                    rtb.LoadFile(FileN, RichTextBoxStreamType.RichText);
                if (saveDLG.FileName != "")
                    rtb.LoadFile(FileN, RichTextBoxStreamType.RichText);
            }

        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (rtb.Modified)
                DialogResult = MessageBox.Show(this, "Do you want to Save?", "Prompt",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (a == DialogResult.OK) saveToolStripMenuItem_Click(sender, e);
            if (a == DialogResult.Cancel) return;
            rtb.Clear(); //rtb.text="";

        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (rtb.Modified)
            {
                DialogResult = MessageBox.Show(this, "Do you want to Save?", "Prompt",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (a == DialogResult.OK) saveToolStripMenuItem_Click(sender, e);
                if (a == DialogResult.Cancel) return;
            }
        
            openDLG.Filter = "All Files| *.*| Text Files|*.txt| Word Files|*.doc|RTF Files|*.rtf";
            openDLG.InitialDirectory = Application.StartupPath+"\\ Files";
           if( openDLG.ShowDialog()== DialogResult.OK) 
               rtb.LoadFile(openDLG.FileName, RichTextBoxStreamType.PlainText);
            setFileTitle(openDLG.FileName);
            

           
        }

        private void setFileTitle(string fileName)
        {
            throw new NotImplementedException();
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            saveDLG.Title = "Запиши съдържанието като...";
            saveDLG.Filter = "All Files| *.*| Text Files|*.txt| Word Files|*.doc|RTF Files|*.rtf";
            saveDLG.FilterIndex = 4;
            saveDLG.InitialDirectory = Application.ExecutablePath;
            saveDLG.DefaultExt = ".rtf";
            if (saveDLG.ShowDialog() == DialogResult.OK)
            {
                rtb.LoadFile(FileN, RichTextBoxStreamType.RichText);
                setFileTitle(saveDLG.FileName);
                FileN = saveDLG.FileName;
            }


        }
        private void setFileName(string s)
        {
            System.IO.FileInfo fff = new System.IO.FileInfo(s);
            this.Text = fff.Name + " -My Text Editor";
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (rtb.Modified)
            {
                DialogResult = MessageBox.Show(this, "Do you want to Save?", "Prompt",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (a == DialogResult.OK) saveToolStripMenuItem_Click(sender, e);
                if (a == DialogResult.Cancel) return;
            }
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rtb.Modified)
                DialogResult = MessageBox.Show(this, "Do you want to Save?", "Prompt",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (a == DialogResult.OK) saveToolStripMenuItem_Click(sender, e);
            if (a == DialogResult.Cancel) e.Cancel=true;
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            fontDLG.ShowColor = true;
            fontDLG.ShowDialog();
            rtb.SelectionFont = fontDLG.Font;
            rtb.SelectionColor = fontDLG.Color;
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            rtb.Undo();
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            rtb.Redo();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            rtb.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            rtb.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            rtb.Paste();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            rtb.SelectAll();
        }
    }
}
