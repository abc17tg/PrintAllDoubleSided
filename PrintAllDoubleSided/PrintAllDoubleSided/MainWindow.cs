using System;
using System.Windows.Forms;

namespace PrintAllDoubleSided
{
    public partial class MainWindow : Form
    {
        private Printing printing;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            printing = new Printing();
            printing.RecalculatePagesSets();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length > 0)
                Clipboard.SetText(textBox1.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Length > 0)
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
                printing.RecalculatePagesSets();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && numericUpDown2.Value > 0 && numericUpDown1.Value >= numericUpDown2.Value)
                printing.RecalculatePagesSets();
        }
    }
}