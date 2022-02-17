using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PrintAllDoubleSided
{
    public partial class MainWindow : Form
    {
        private Printing printing;
        private List<string> textBoxesValues;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            printing = new Printing();
            setTextBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                Clipboard.SetText(textBox1.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
                Clipboard.SetText(textBox2.Text);
            if (printing.IsMoreUnevenPages)
                MessageBox.Show("Remove top sheet of paper from printer before printing next set");
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (printing.IsMoreUnevenPages)
                MessageBox.Show("Remove top sheet of paper from printer before printing next set");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && numericUpDown2.Value > 0 && numericUpDown1.Value >= numericUpDown2.Value)
                setTextBoxes();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && numericUpDown2.Value > 0 && numericUpDown1.Value >= numericUpDown2.Value)
                setTextBoxes();
        }
        
        private void setTextBoxes()
        {
            textBoxesValues = printing.RecalculatePagesSets((int)NumericUpDown1.Value, (int)NumericUpDown2.Value);
            textBox1.Text = textBoxesValues[0];
            textBox2.Text = textBoxesValues[1];
        }
    }
}