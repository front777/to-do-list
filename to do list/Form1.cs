using to_do_list;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.LinkLabel;

namespace to_do_list
{
    public partial class Form1 : Form
    {
        List<String> trash = new List<String>();
        static public string list;


        public Form1()
        {

            InitializeComponent();
            Date();
            AddInListAll();

        }



        void AddInListAll()
        {
            string path = @"all.txt";
            string path2 = @"done.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                using (StreamReader sr2 = new StreamReader(path2))
                {

                    string line = sr.ReadToEnd();
                    line = line.Trim();  
                    string line2 = sr2.ReadToEnd(); 
                    line2 = line2.Trim();
                 
                        string[] StopWords = line2.Split(Environment.NewLine);


                        foreach (string word in StopWords)
                        {

                            line = line.Replace(word, "");
                           


                        }
                        string[] DoneVersion = line.Split(Environment.NewLine);
                        listBox2.Items.AddRange(DoneVersion);
                        listBox1.Items.AddRange(StopWords);
                    
                    









                    sr.Close();
              
                }

            }
          

        }


        void Date()
        {
            DateTime dt = DateTime.Today;
            string dtCut = dt.ToString().Substring(0, 2);
            label5.Text = dtCut;
            string DayName = dt.DayOfWeek.ToString();
            DayName = DayName.Substring(0, 3);

            label4.Text = DayName;

            label6.Text = dt.Year.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void button2_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(checkedListBox3.SelectedItem.ToString());

            string path = @"all.txt";

            using (StreamReader sr = new StreamReader(path))
            {

                string line = sr.ReadToEnd();
                string[] str = line.Split(Environment.NewLine);
                List<string> s = new List<string>(str);
                listBox2.Items.Remove(listBox2.SelectedItem);
                trash.Add(listBox2.SelectedItem.ToString());


            }


        }




        private void button1_Click_1(object sender, EventArgs e)
        {


        }



        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*foreach (var str in checkedListBox3.CheckedItems)
            {
                MessageBox.Show(str.ToString());
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listBox1.Items.Add(listBox2.SelectedItem.ToString());
         
            string path = @"done.txt";
            string path2 = @"all.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
             
                sw.WriteLine(listBox2.SelectedItem);

                sw.Close();

            }
            listBox2.Items.Remove(listBox2.SelectedItem);
           


           
        }
    }
}
    