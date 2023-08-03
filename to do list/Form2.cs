using System;
using to_do_list;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.DirectoryServices.ActiveDirectory;

namespace to_do_list
{
    public partial class Form2 : Form { 


       

        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string DateForTask = dateTimePicker2.Value.ToString();
            DateForTask = DateForTask.Substring(0, 10);
            string path = @"all.txt";
              if(!File.Exists(path)) { 
               File.Create(path);

               }



               using (StreamWriter sw = File.AppendText(path))
               {
                   sw.WriteLine(textBox2.Text + " " + DateForTask + "");
                   sw.Close();

               }


            Form1.list = textBox2.Text + " " + DateForTask + "";
           




            this.Close();
















        }
    }
}
