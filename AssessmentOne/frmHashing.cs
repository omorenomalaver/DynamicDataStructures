using AssessmentOne.classes;
using AssessmentOne.classes.algorimths.tree;
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
    public partial class frmHashing : Form
    {
        simple_hash_function myHash;
        public frmHashing()
        {
            InitializeComponent();
            myHash = new simple_hash_function();
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            myHash = new simple_hash_function();
            listBox2.DataSource = null;
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
            label1.Text = "List of " + result + " numbers created ";

            randomNumbers myRnd = new randomNumbers();
            List<int> _items = new List<int>();
            foreach (int items in myRnd.arrayElements(int.Parse(result)))
            {
                _items.Add(items);
            }
            listBox1.DataSource = _items;
        }

        private void frmHashing_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form myForm in Application.OpenForms)
            {
                myForm.Show();
            }
        }

        private void btnCreateHashTable_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                foreach (int items in listBox1.Items)
                {
                    myHash.insert(items);
                }
                List<int> _items = new List<int>();
                for (int i = 0; i <= myHash.hash_table.Length - 1; i++)
                {
                    _items.Add(i);
                }
                listBox2.DataSource = _items;
            }
            else
            {
                MessageBox.Show("Fisrt create a list of unhash elements", "Result", MessageBoxButtons.OK);
            }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                populateTreeList(int.Parse(listBox2.SelectedItem.ToString()));
            }
            
        }

        public void populateTreeList(int hashTable)
        {
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes.Clear();
            }
            tree myTree = (tree)myHash.hash_table[hashTable];
            if (myTree != null)
            {
                TreeNode myTreeNode = showTree(myTree.start, null, null);
                treeView1.Nodes.Add(myTreeNode);
            }
            else
            {
                MessageBox.Show("This hash table does not have elements", "Result", MessageBoxButtons.OK);
            }
 
        }

        private TreeNode showTree(Nodes myNode, TreeNode myTreeNode, string tmpIndex)
        {
            string nodeKey = "";
            if (myTreeNode == null)
            {
                myTreeNode = new TreeNode();
                TreeNode rootNode = new TreeNode();
                rootNode.Text = myNode.info.ToString();
                rootNode.Tag = myNode.info.ToString();
                rootNode.Name = myNode.info.ToString();
                nodeKey = myNode.info.ToString();
                myTreeNode.Nodes.Add(rootNode);
                myTreeNode.Text = "Binary Tree";
            }
            else
            {
                TreeNode childNode = new TreeNode();
                childNode.Text = myNode.info.ToString();
                childNode.Tag = myNode.info.ToString();
                childNode.Name = myNode.info.ToString();
                nodeKey = myNode.info.ToString();
                foreach (TreeNode moreNodes in myTreeNode.Nodes.Find(tmpIndex, true))
                {
                    moreNodes.Nodes.Add(childNode);
                }
            }

            if (myNode.right != null)
            {
                showTree(myNode.right, myTreeNode, nodeKey);
            }
            if (myNode.left != null)
            {
                showTree(myNode.left, myTreeNode, nodeKey);
            }
            return myTreeNode;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
