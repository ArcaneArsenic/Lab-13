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
using System.Threading;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;

namespace Ksu.Cis300.NameLookup
{
    public partial class UserInterface : Form
    {
        private Dictionary<string, FrequencyAndRank> Dictionary = new Dictionary<string, FrequencyAndRank>();
        public UserInterface()
        {
            InitializeComponent();
        }
        int count = 0;

        //public string FileName = Console.ReadLine();
        private Dictionary<string, FrequencyAndRank> Reader(string FileName)
        {
            Dictionary<string, FrequencyAndRank> miniDict = new Dictionary<string, FrequencyAndRank>();
            
            //uxOpenDialog.ShowDialog();
            //System.IO.StringReader OpenFile = new System.IO.StringReader(uxOpenDialog.FileName);

            while (count != FileName.Length + 1)
            {
                using (StreamReader input = new StreamReader(uxOpenDialog.FileName))
                {
                    
                    // Process the file - no need to dispose it
                    string name = FileName.Trim();
                    float freq = Convert.ToSingle(FileName.Trim());
                    int rank = Convert.ToInt32(FileName.Trim());
                    FrequencyAndRank x = new FrequencyAndRank(freq, rank);

                    miniDict.Add(name, x);

                }

                count++;

            }
            return miniDict;
            //MessageBox.Show("Dictionary Complete!");
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }

        private void uxOpen_Click(object sender, EventArgs e)
        {
            try 
            {
                uxOpenDialog.ShowDialog();
                
                Reader(Console.ReadLine());
                MessageBox.Show("File has been read.");
            }
            catch (FileNotFoundException) 
            {
                MessageBox.Show("oof");
            }
        }

        private void uxLookup_Click(object sender, EventArgs e)
        {
            string ui = Console.ReadLine();
            uxName.Text = ui.ToUpper();
            uxFrequency.Text = ui.Trim();
            uxRank.Text = ui;
        }
    }
}
