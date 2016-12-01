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
    public partial class FrmSearch : Form
    {
        public FrmSearch()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            validations myVal = new validations();
            if (myVal.intValidation(txtFind.Text.ToString()))
            {
                string result = "100";

                foreach (Control control in this.groupBox1.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton myRadio = control as RadioButton;
                        if (myRadio.Checked)
                            result = myRadio.Text;
                    }
                }

                randomNumbers myRnd = new randomNumbers();
                int[] myElements = myRnd.arrayElements(int.Parse(result));
                Simple_merge_sort mySort = new Simple_merge_sort();
                listBox2.DataSource = myElements.ToArray();
                mySort.sort(myElements);
                List<string> _items = new List<string>(); // <-- Add this

                _items = new List<string>(); // <-- Add this
                foreach (int i in myElements)
                {
                    _items.Add(i.ToString());
                }
                listBox1.DataSource = _items;

                SimpleBinarySearch myBinarySearch = new SimpleBinarySearch();
                if (myBinarySearch.find(myElements, int.Parse(txtFind.Text)))
                {
                    int myIndex = listBox1.FindString(txtFind.Text);
                    listBox1.SetSelected(myIndex, true);
                    MessageBox.Show("Value  Found: " + txtFind.Text.ToString(), "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Value Not Found", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Must type a enter value, thx", "Error", MessageBoxButtons.OK);
            }
            

        }

        private void FrmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form myForm in Application.OpenForms)
            {
                myForm.Show();
            }
        }
    }
}
