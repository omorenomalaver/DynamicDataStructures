using AssessmentOne.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessmentOne
{
    public partial class frmSort : Form
    {
        Simple_merge_sort myMerge;
        int[] elements;
        public frmSort()
        {
            InitializeComponent();
        }

        private void frmSort_Load(object sender, EventArgs e)
        {
            myMerge = new Simple_merge_sort();
            pupulate();
            controlGUI(true, false);
        }
        private void pupulate()
        {
            string result = "100";
            
            foreach (Control control in this.groupBox1.Controls)
            {
                if(control is RadioButton)
                {
                    RadioButton myRadio = control as RadioButton;
                    if (myRadio.Checked)
                        result = myRadio.Text;
                }
            }
            label1.Text = "Unsorted List of " + result;
            label2.Text = "Sorted List of " + result;

            randomNumbers myRnd = new randomNumbers();
            elements = myRnd.arrayElements(int.Parse(result));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sortValues();
            controlGUI(true, false);
        }

        private void sortValues()
        {
           
            List<string> _items = new List<string>(); // <-- Add this
            myMerge.sort(elements);
            _items = new List<string>(); // <-- Add this
            foreach (int i in elements)
            {
                _items.Add(i.ToString());
            }
            listBox2.DataSource = _items;
        }

        private void createValues()
        {
            myMerge = new Simple_merge_sort();
            
            List<string> _items = new List<string>(); // <-- Add this
            foreach (int i in elements)
            {
                _items.Add(i.ToString());
            }
            listBox1.DataSource = _items;
            listBox2.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlGUI(true, true);
            pupulate();
            createValues();
        }

        private void controlGUI(bool create, bool sort)
        {
            btnCreate.Enabled = create;
            btnSort.Enabled = sort;
            if (!sort)
            {
                btnSort.Text = "Push create button to make a number list";
            }
            else
            {
                btnSort.Text = "Sort";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSort_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form myForm in Application.OpenForms)
            {
                myForm.Show();
            }
        }
    }
}
