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
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void btnCreateElements_Click(object sender, EventArgs e)
        {
            tree myTree = new tree();
            myTree.insert_node(4);
            myTree.insert_node(6);
            myTree.insert_node(7);
            myTree.insert_node(8);
            myTree.insert_node(1);
            myTree.insert_node(2);

            TreeNode myTreeNode = createTree(myTree.start,null, null);
            treeView1.Nodes.Add(myTreeNode);
        }

        private TreeNode createTree(Nodes myNode, TreeNode myTreeNode, string tmpIndex)
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
                createTree(myNode.right, myTreeNode, nodeKey);
            }
            if (myNode.left != null)
            {
                createTree(myNode.left, myTreeNode, nodeKey);
            }
            return myTreeNode;
        }
    }
}
