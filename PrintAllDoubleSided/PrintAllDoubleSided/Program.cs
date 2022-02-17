using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintAllDoubleSided
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }

    internal class Printing : MainWindow
    {
        public bool IsMoreUnevenPages;
        private delegate void TextBoxDelegate(string text);
        public List<string> RecalculatePagesSets(int numberOfPages, int numberOfPagesPerSheet)
        {
            List<int> nOP = new List<int>();
            for (int i = 1; i < numberOfPages + 1; i++)
                nOP.Add(i);

            var chunkedPages = Utils.ChunkBy(nOP, numberOfPagesPerSheet);

            List<string> evenPages = new List<string>();
            List<string> unevenPages = new List<string>();

            for (int i = 1; i < chunkedPages.Count + 1; i++)
            {
                if (i % 2 == 0)
                {
                    if (chunkedPages[i - 1].First() != chunkedPages[i - 1].Last())
                        evenPages.Add(chunkedPages[i - 1].First().ToString() + '-' + chunkedPages[i - 1].Last().ToString());
                    else
                        evenPages.Add(chunkedPages[i - 1].First().ToString());
                }
                else
                {
                    if (chunkedPages[i - 1].First() != chunkedPages[i - 1].Last())
                        unevenPages.Add(chunkedPages[i - 1].First().ToString() + '-' + chunkedPages[i - 1].Last().ToString());
                    else
                        unevenPages.Add(chunkedPages[i - 1].First().ToString());
                }
            }

            evenPages.Reverse();

            if (unevenPages.Count > evenPages.Count)
                IsMoreUnevenPages = true;
            else
                IsMoreUnevenPages = false;

            return new List<string>{string.Join(",", unevenPages), string.Join(",", evenPages)};

            //mainWindow.Invoke(new Action(()=> { textBox1_ChangeText(string.Join(",", unevenPages)); textBox2_ChangeText(string.Join(",", evenPages)); }));
            /*mainWindow.BeginInvoke(new TextBoxDelegate(textBox1_ChangeText), string.Join(",", unevenPages));
            
            mainWindow.BeginInvoke(new TextBoxDelegate(textBox2_ChangeText), string.Join(",", evenPages));*/

            //if (!mainWindow.IsHandleCreated)
               // mainWindow.CreateControl();
            //mainWindow.Invoke((MethodInvoker)delegate () { TextBox1.Text = string.Join(",", unevenPages); TextBox2.Text = string.Join(",", evenPages); });

            /*textBox1_ChangeText(string.Join(",", unevenPages));
            textBox2_ChangeText(string.Join(",", evenPages));*/

        }
    }
}

