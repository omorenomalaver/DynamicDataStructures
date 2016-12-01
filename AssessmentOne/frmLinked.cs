using AssessmentOne.classes;
using AssessmentOne.classes.algorimths.list;
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
    public partial class frmLinked : Form
    {
        doubly_linked_list myList;
        public frmLinked()
        {
            InitializeComponent();
            myList = new doubly_linked_list();
        }

        private void frmLinked_Load(object sender, EventArgs e)
        {

        }


        private void showList( int xPosGroup, int yPosGroup, string prev, string cont, string next, bool selected, int count, Panel myPanel)
        {
            GroupBox mygroup01 = new GroupBox();
            mygroup01.Location = new Point(xPosGroup, yPosGroup);
            mygroup01.Size = new Size(135, 125);
            mygroup01.Text = "Node No" + count.ToString();
            mygroup01.BackColor = Color.RoyalBlue;
            mygroup01.Name = cont;
            mygroup01.Tag = "nodes";
            
            yPosGroup = yPosGroup + 5;
            Label myPrev = new Label();
            myPrev.Text = "prev: " + prev;
            myPrev.Location = new Point(20, yPosGroup);
            myPrev.BackColor = Color.Aqua;
            myPrev.Name = "lblpsgb" + count.ToString();

            yPosGroup = yPosGroup + 30;
            Label myContent = new Label();
            myContent.Text = "cont: " + cont;
            myContent.Location = new Point(20, yPosGroup);
            myContent.BackColor = Color.AliceBlue;
            myPrev.Name = "lblcsgb" + count.ToString();

            yPosGroup = yPosGroup + 30;
            Label myNext = new Label();
            myNext.Text = "next: " + next;
            myNext.Location = new Point(20, yPosGroup);
            myNext.BackColor = Color.LightGreen;
            myPrev.Name = "lblnsgb" + count.ToString();

            mygroup01.Controls.Add(myPrev);
            mygroup01.Controls.Add(myContent);
            mygroup01.Controls.Add(myNext);

            myPanel.Controls.Add(mygroup01);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            myList = new doubly_linked_list();
            createAmountNumbers();
            insertValues();
        }

        private void createAmountNumbers()
        {
            string result = "100";

            foreach (Control control in this.gbRange.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton myRadio = control as RadioButton;
                    if (myRadio.Checked)
                        result = myRadio.Text;
                }
            }

            randomNumbers myRnd = new randomNumbers();
            int[] elements = myRnd.arrayElements(int.Parse(result));
            foreach(int i in elements)
            {
                myList.insert_node(i);
            }
            listBoxElements.DataSource = null;
            List<int> _items = new List<int>();
            foreach (int items in elements)
            {
                _items.Add(items);
            }
            listBoxElements.DataSource = _items;
        }

        private void insertValues()
        {
          
            NodesDLL myNode = myList.showData();
            NodesDLL myNode2 = new NodesDLL();
            int xPos = 20;
            int count = 1;

            foreach (Control myControl in this.Controls)
            {
                if(myControl is Panel)
                {
                    Panel myPanel = (Panel)myControl;
                    myPanel.Controls.Clear();
                    myPanel.Dispose();
                    myControl.Controls.RemoveByKey("panelList");
                }
                    
            }

            foreach (Control myControl in this.Controls)
            {
                if (myControl is Panel)
                {
                    Panel myPanel = (Panel)myControl;
                    myPanel.Controls.Clear();
                    myPanel.Dispose();
                    myControl.Controls.RemoveByKey("panelList2");
                }

            }

            var panel1 = new Panel() {
                Size = new Size(736, 163),
                Location = new Point(12, 286),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true,
                BackColor = Color.White,
                Tag = "panelList"
            };

            var panel2 = new Panel()
            {
                Size = new Size(736, 163),
                Location = new Point(12, 486),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true,
                BackColor = Color.White,
                Tag = "panelList2"
            };

            // forward display
            while (myNode != null)
            {

                string pre = "null";
                string cont = "null";
                string next = "null";
                if (myNode.prev != null)
                {
                    pre = myNode.prev.data.ToString();
                }
                if (myNode.next != null)
                {
                    next = myNode.next.data.ToString();
                }
                cont = myNode.data.ToString();

                showList(xPos, 20, pre, cont, next, true, count, panel1);
                xPos = xPos + 180;
                if (myNode.next == null)
                {
                    myNode2 = new NodesDLL();
                    myNode2 = myNode;
                }
                myNode = myNode.next;
                count++;
            }
            // backward display
             xPos = 20;
             count = 1;
            while (myNode2 != null)
            {

                string pre = "null";
                string cont = "null";
                string next = "null";
                if (myNode2.prev != null)
                {
                    pre = myNode2.prev.data.ToString();
                }
                if (myNode2.next != null)
                {
                    next = myNode2.next.data.ToString();
                }
                cont = myNode2.data.ToString();

                showList(xPos, 20, pre, cont, next, true, count, panel2);
                xPos = xPos + 180;
                myNode2 = myNode2.prev;
                count++;
            }

            this.Controls.Add(panel1);
            this.Controls.Add(panel2);
        }

        private void frmLinked_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form myForm in Application.OpenForms)
            {
                myForm.Show();
            }
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            validations myVal = new validations();
            string valueToFind = txtFind.Text;
            txtFind.Text = "";
            if (myVal.intValidation(valueToFind))
            {
                findValues(valueToFind);
            }
            else
            {
                MessageBox.Show("Enter a integer value", "Result", MessageBoxButtons.OK);
            }
        }
        public void findValues(string valueToFind)
        {
            if (myList.findNode(int.Parse(valueToFind)))
            {
                foreach (Control myControl in this.Controls)
                {
                    if (myControl is Panel)
                    {
                        Panel myPanel = (Panel)myControl;
                        foreach (Control panelControls in myPanel.Controls)
                        {
                            if (panelControls is GroupBox)
                            {
                                GroupBox myBroupBox = (GroupBox)panelControls;
                                if (myBroupBox.Name == valueToFind)
                                {
                                    myBroupBox.BackColor = Color.Red;
                                    myBroupBox.Select();
                                }
                                else
                                {
                                    myBroupBox.BackColor = Color.RoyalBlue;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Value not found", "Result", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            validations myVal = new validations();
            string valueToFind = txtDelete.Text;
            txtDelete.Text = "";
            if (myVal.intValidation(valueToFind))
            {
                deleteValue(valueToFind);
            }
            else
            {
                MessageBox.Show("Enter a integer value", "Result", MessageBoxButtons.OK);
            }
        }

        public void deleteValue(string valueToFind)
        {
            if (myList.findNode(int.Parse(valueToFind)))
            {
                myList.delete_node(int.Parse(valueToFind));
                insertValues();
                MessageBox.Show("Value deleted successful", "Result", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Value not found", "Result", MessageBoxButtons.OK);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
