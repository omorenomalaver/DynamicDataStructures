using AssessmentOne.classes.algorimths.tree;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using AssessmentOne.classes;

namespace AssessmentOne
{
    public partial class frmBinary : Form
    {
        tree myTree;
        public frmBinary()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            myTree = new tree();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxElements.DataSource = null;
        }

        private void btnCreateElements_Click(object sender, EventArgs e)
        {
           
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

        private TreeNode find(String value)
        {
            TreeNode[] tred = treeView1.Nodes
                                    .Cast<TreeNode>()
                                    .Where(r => r.Text == value)
                                    .ToArray();
            return tred[0];
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
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
            label1.Text = "List of "+ result + " Aleatory Numbers Created ";

            randomNumbers myRnd = new randomNumbers();
            List<int> _items = new List<int>();
            foreach (int items in myRnd.arrayElements(int.Parse(result))){
                _items.Add(items);
            }
            listBoxElements.DataSource = _items;
        }

        private void btnCreateTree_Click(object sender, EventArgs e)
        {
            if (listBoxElements.Items.Count > 0)
            {
                myTree = new tree();
                foreach (int item in listBoxElements.Items)
                {
                    myTree.insert_node(item);
                }
                populateTreeList();
            }
            else
            {
                MessageBox.Show("First create the tree, thanks", "Result", MessageBoxButtons.OK);
            }
            
        }
        public void populateTreeList()
        {

            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes.Clear();
            }
            //listBox1.DataSource = _items;
            TreeNode myTreeNode = showTree(myTree.start, null, null);
            ListPostOrder.DataSource = myTree.post_order(myTree.start);
            ListInOrder.DataSource = myTree.in_order(myTree.start);
            ListPreOrder.DataSource = myTree.pre_order(myTree.start);
            treeView1.Nodes.Add(myTreeNode);
        }

        public void populateTreeList(int value)
        {
            List<int> _items = new List<int>();
            int removeNumber = value;
            if (listBoxElements.DataSource != null)
            {
                myTree.start = null;
                foreach (var obj in (List<int>)listBoxElements.DataSource)
                {
                    if (obj != removeNumber)
                    {
                        myTree.insert_node(obj);
                        _items.Add(obj);
                    }
                        
                }
            }
            listBoxElements.DataSource = _items;

            populateTreeList();
        }

        private void expandNode(TreeNode myTreeNode)
        {
            if (myTreeNode.Parent != null)
            {
                myTreeNode.Parent.Expand();
                expandNode(myTreeNode.Parent);
            } 
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            populateTreeList();
            if (treeView1.Nodes.Count > 0)
            {
                //treeView1.Nodes.Find(txtFind.Text.ToString(), true)[0].Parent.Expand();
                //treeView1.Nodes.Find(txtFind.Text.ToString(), true)[0].ForeColor = System.Drawing.Color.Coral;
                TreeNode[] myTreeNode = treeView1.Nodes.Find(txtFind.Text.ToString(), true);
                if (myTreeNode.Length > 0)
                {
                    
                    expandNode(myTreeNode[0]);
                    myTreeNode[0].BackColor = System.Drawing.Color.Red;
                    treeView1.SelectedNode = myTreeNode[0];
                }

            }

            if (treeExist())
            {
                if (intValidate(txtFind.Text.ToString()))
                {
                    int valueToFind = 0;
                    valueToFind = int.Parse(txtFind.Text.ToString());
                    bool myresult = myTree.search_info_bool(valueToFind);
                    if (myresult)
                        MessageBox.Show("Value found: " + valueToFind.ToString(), "Result", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Value not found: " + valueToFind.ToString(), "Result", MessageBoxButtons.OK);

                    txtFind.Text = "";
                }
            }
            else
            {
                MessageBox.Show("First create the tree, thanks", "Result", MessageBoxButtons.OK);
            }
            
            
        }
        public bool intValidate(String valueToText)
        {

            int convertResult;
            int.TryParse(valueToText, out convertResult);
            if (convertResult == 0)
            {
                MessageBox.Show("Value not integer, try again", "Result", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool treeExist()
        {
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeExist())
            {
                if (intValidate(txtDelete.Text.ToString()))
                {
                    int valueToFind = 0;
                    valueToFind = int.Parse(txtDelete.Text.ToString());
                    bool myresult = myTree.search_info_bool(valueToFind);
                    if (myresult)
                    {
                        myTree.delete_node(valueToFind);
                        MessageBox.Show("Value deleted: " + valueToFind.ToString(), "Result", MessageBoxButtons.OK);
                        populateTreeList(valueToFind);
                        txtDelete.Text = "";
                    }
                    else
                        MessageBox.Show("Value not found: " + valueToFind.ToString(), "Result", MessageBoxButtons.OK);
                }
            }
            else
            {
             
                    MessageBox.Show("First create the tree, thanks", "Result", MessageBoxButtons.OK);
                
            }
            


        }

        private void frmBinary_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Form myForm in Application.OpenForms)
            {
                myForm.Show();
            }
        }

        private void btnAddManual_Click(object sender, EventArgs e)
        {
            validations myVal = new validations();

            if (myVal.intValidation((txtManualNumber.Text)))
            {
                List<int> _items = new List<int>();
                int addNumber = int.Parse(txtManualNumber.Text);
                if (listBoxElements.DataSource != null)
                {
                    foreach (var obj in (List<int>)listBoxElements.DataSource)
                    {
                        if (obj != addNumber)
                            _items.Add(obj);
                    }
                    _items.Add(addNumber);
                }
                else
                {
                    _items.Add(addNumber);
                }
                listBoxElements.DataSource = _items;
                txtManualNumber.Text = "";
                label1.Text = "List of Numbers to be Use";
            }
            else
            {
                MessageBox.Show("Only numbers please", "Error",MessageBoxButtons.OK);
                txtManualNumber.Text = "";
            }
            
        }

        private void ListPostOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
