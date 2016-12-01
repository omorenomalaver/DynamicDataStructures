using System;
using System.Collections.Generic;

namespace AssessmentOne.classes.algorimths.tree
{
    
    public class tree
    {
        public Nodes start;

        public tree()
        {
           //start = new Nodes();
        }
        
        /// <summary>
        /// this function add nodes into the tree
        /// </summary>
        /// <param name="info_to_insert"></param>
        public void insert_node(int info_to_insert)
        {
            //if the tree is empty, create the root node
            if(start == null){
                Nodes tempNode = new Nodes(); 
                tempNode.info = info_to_insert;
                tempNode.root = true;
                start = tempNode;
            }
            // if is not empty the tree, check values into root node "children and values"
            else
            {
                // create a temporary copy of tree
                Nodes tempNode = start;
                // iterate the temporaly tree
                while (tempNode!=null)
                {
                    //searching if you have child
                    if(tempNode.left==null && tempNode.right == null)
                    {
                        //check if "info" is more than info_to_insert
                        if (tempNode.info < info_to_insert)
                        {
                            // if is more than, insert right child
                            Nodes rightChild = new Nodes();
                            // insert who is the parent of this node
                            rightChild.parent = tempNode;
                            // insert the value of this node
                            rightChild.info = info_to_insert;
                            tempNode.right = rightChild;
                            //give a null value to tempNode to exit loop
                            tempNode = null;
                        }
                        // otherwise insert left child
                        else
                        {
                            // insert values into left arm
                            Nodes leftChild = new Nodes();
                            // insert who is the parent of this node
                            leftChild.parent = tempNode;
                            // insert the value of this node
                            leftChild.info = info_to_insert;
                            tempNode.left = leftChild;
                            //give a null value to tempNode to exit loop
                            tempNode = null;
                        }
                    }
                    // if there are some children, check right arm if is empty and info is more than info_to_insert
                    else if (tempNode.right == null && (tempNode.info < info_to_insert)){
                        // insert values into right arm
                        Nodes rightChild = new Nodes();
                        // insert who is the parent of this node
                        rightChild.parent = tempNode;
                        // insert the value of this node
                        rightChild.info = info_to_insert;
                        tempNode.right = rightChild;
                        // give null value to temNode to exit loop
                        tempNode = null;
                    }
                    // if there are some children, check left arm if is empty and info is less than info_to_insert
                    else if (tempNode.left == null && (tempNode.info > info_to_insert))
                    {
                        // insert values into left arm
                        Nodes leftChild = new Nodes();
                        // insert who is the parent of this node
                        leftChild.parent = tempNode;
                        // insert the value of this node
                        leftChild.info = info_to_insert;
                        tempNode.left = leftChild;
                        // give null value to temNode to exit loop
                        tempNode = null;
                    }
                    // if there are some children, check right arm if is not empty and info is less than info_to_insert
                    else if (tempNode.right != null && (tempNode.info < info_to_insert))
                    {
                        // iterate again, but only the right arm
                        tempNode = tempNode.right;
                    }
                    // if there are some children, check left arm if is not empty and info is less than info_to_insert
                    else if (tempNode.left != null && (tempNode.info > info_to_insert))
                    {
                        // iterate again, but only the left arm
                        tempNode = tempNode.left;
                    }
                }
            }
        }

        /// <summary>
        /// this function show tree values, using a list<> to save nodes
        /// </summary>
        public void show_tree()
        {
            //this is the position of the list where the program will read
            int list_position = 0;
            // then create a list <Nodes> to save each node
            List<Nodes> listElements = new List<Nodes>();
            //we save start tree in the fisrt position (0) of this list
            listElements.Add(start);
            // while list_position is less than listElements.Count, keep read info
            while (list_position < listElements.Count)
            {
                //separete children of the parent
                Nodes leftNode = listElements[list_position].left;
                Nodes rightNode = listElements[list_position].right;
                // ask if left child has got some info
                if (leftNode != null)
                {
                    // if the child has got info, we save this child to the next position of this list
                    listElements.Add(leftNode);
                }
                // ask if right child has got some info
                if (rightNode != null)
                {
                    // if the child has got info, we save this child to the next position of this list
                    listElements.Add(rightNode);
                }
                // increase position to read 'list_position' next loop 
                list_position++;

            }

            // now read 'list_position' to show what the program found
            foreach (Nodes showNodes in listElements)
            {
                Console.WriteLine("------------------------");
                string root = (showNodes.parent != null) ? showNodes.parent.info.ToString() : "root";

                Console.WriteLine("Root: " + root);
                Console.WriteLine("Info: " + showNodes.info);
                if (showNodes.right != null)
                    Console.WriteLine("Right Child: " + showNodes.right.info);
                else
                    Console.WriteLine("Right Child: null");
                if (showNodes.left != null)
                    Console.WriteLine("Left Child: " + showNodes.left.info);
                else
                    Console.WriteLine("Left Child: null");
               
            }
            
        }

        public void reorder_tree()
        {
            Nodes oldTree = start;
            start = null;
            Nodes newTree = readTree(oldTree, null,false,false);
            
        }
        List<int> tmpResult = new List<int>();
        /// <summary>
        /// this function show the list of leave of this tree in post order traversal
        /// </summary>
        /// <param name="treeData"></param>
        /// <returns></returns>
        public List<int> post_order(Nodes treeData)
        {
            List<int> result = new List<int>();
            tmpResult = new List<int>();
            Console.WriteLine("******** POST ORDER ***********");
            if (treeData.left != null)
            {
                showLeaves(treeData.left);
            }

            if (treeData.right != null)
            {
                showLeaves(treeData.right);
            }
            foreach(int item in tmpResult)
            {
                result.Add(item);
            }
            Console.WriteLine(" root " + treeData.info);
            result.Add(treeData.info);
            return result;
        }
        
        /// <summary>
        /// this recursevy function show all leave of this tree
        /// </summary>
        /// <param name="treeData"></param>
        public void showLeaves(Nodes treeData)
        {
            List<int> result = new List<int>();

            if (treeData.left != null)
            {
                showLeaves(treeData.left);
            }
                
            if (treeData.right != null)
            {
                showLeaves(treeData.right);
            }

            Console.WriteLine(treeData.info);
            tmpResult.Add(treeData.info);
            
        }

        /// <summary>
        /// this function show the in order traversal binary tree
        /// </summary>
        /// <param name="treeData"></param>
        public List<int> in_order(Nodes treeData)
        {
            List<int> result = new List<int>();
            tmpResult = new List<int>();
            Console.WriteLine("******** IN ORDER ***********");
            if (treeData.left != null)
                showDeepBranch(treeData.left);
            foreach (int item in tmpResult)
            {
                result.Add(item);
            }
            result.Add(treeData.info);
            tmpResult.Add(treeData.info);
            tmpResult = new List<int>();
            Console.WriteLine(" root " + treeData.info);
            if (treeData.right != null)
                showDeepBranch(treeData.right);
            foreach (int item in tmpResult)
            {
                result.Add(item);
            }
            return result;
        }
        /// <summary>
        /// this function show since the deep left value of each branch
        /// </summary>
        /// <param name="treeData"></param>
        public void showDeepBranch(Nodes treeData)
        {
            if (treeData.left != null)
            {
                showDeepBranch(treeData.left);
                Console.WriteLine(treeData.info);
                tmpResult.Add(treeData.info);
                if (treeData.right != null)
                    showDeepBranch(treeData.right);
            }
            else
            {
                Console.WriteLine(treeData.info);
                tmpResult.Add(treeData.info);
                if (treeData.right != null)
                    showDeepBranch(treeData.right);
            }
        }

        /// <summary>
        /// this function show the preorder traversal
        /// </summary>
        /// <param name="treeData"></param>
        public List<int> pre_order(Nodes treeData)
        {
            List<int> result = new List<int>();
            tmpResult = new List<int>();
            Console.WriteLine("******** PRE ORDER ***********");
            result.Add(treeData.info);
            Console.WriteLine(" root "+ treeData.info);
            if (treeData.left != null)
                showBranch(treeData.left);
            foreach (int item in tmpResult)
            {
                result.Add(item);
            }
            tmpResult = new List<int>();
            if (treeData.right != null)
                showBranch(treeData.right);
            foreach (int item in tmpResult)
            {
                result.Add(item);
            }
            return result;
        }
        /// <summary>
        /// this function will show whe whole branch using a recursive calling
        /// </summary>
        /// <param name="treeData"></param>
        public void showBranch(Nodes treeData)
        {
            Console.WriteLine(treeData.info);
            tmpResult.Add(treeData.info);
            if (treeData.left != null)
                showBranch(treeData.left);
            if (treeData.right != null)
                showBranch(treeData.right);
        }

        private Nodes readTree(Nodes oldTree, Nodes newTree, bool rChild, bool lChild)
        {
            if (newTree == null)
            {
                newTree = new Nodes();
                insert_node(oldTree.info);
                newTree.info = oldTree.info;
                newTree.root = true;
                if (oldTree.right != null)
                {
                    readTree(oldTree.right, newTree,true,false);
                }
                if(oldTree.left != null)
                {
                    readTree(oldTree.left, newTree, false, true);
                }
            }
            else
            {
                if (rChild == true)
                {
                    Nodes rChildNode = new Nodes();
                    insert_node(oldTree.info);
                    rChildNode.info = oldTree.info;
                    newTree.right = rChildNode;
                    if (oldTree.right != null)
                    {
                        readTree(oldTree.right, newTree, true, false);
                    }
                    if (oldTree.left != null)
                    {
                        readTree(oldTree.left, newTree, false, true);
                    }
                }
                if (lChild == true)
                {
                    Nodes lChildNode = new Nodes();
                    insert_node(oldTree.info);
                    lChildNode.info =  oldTree.info;
                    newTree.left = lChildNode;
                    if (oldTree.right != null)
                    {
                        readTree(oldTree.right, newTree, true, false);
                    }
                    if (oldTree.left != null)
                    {
                        readTree(oldTree.left, newTree, false, true);
                    }
                }
            }
            return newTree;
        }

        /// <summary>
        /// this function show tree values, using a list<> to save nodes
        /// </summary>
        public List<Nodes> list_tree()
        {
            //this is the position of the list where the program will read
            int list_position = 0;
            // then create a list <Nodes> to save each node
            List<Nodes> listElements = new List<Nodes>();
            //we save start tree in the fisrt position (0) of this list
            listElements.Add(start);
            // while list_position is less than listElements.Count, keep read info
            while (list_position < listElements.Count)
            {
                //separete children of the parent
                Nodes leftNode = listElements[list_position].left;
                Nodes rightNode = listElements[list_position].right;
                // ask if left child has got some info
                if (leftNode != null)
                {
                    // if the child has got info, we save this child to the next position of this list
                    listElements.Add(leftNode);
                }
                // ask if right child has got some info
                if (rightNode != null)
                {
                    // if the child has got info, we save this child to the next position of this list
                    listElements.Add(rightNode);
                }
                // increase position to read 'list_position' next loop 
                list_position++;

            }
            
            return listElements;
        }


        /// <summary>
        /// this function find info into the tree and show results
        /// </summary>
        /// <param name="info_to_find"></param>
        public void search_info(int info_to_find)
        {
            // we create a copy of the tree
            Nodes tempNode = start;
            // then we iterate each node of the tree to find the value
            while (tempNode != null)
            {
                //if the "info_to_find" matches with the info of the node, show result
                if (tempNode.info==info_to_find)
                {
                    Console.WriteLine("--- result of search ---");
                    Console.WriteLine("Root: " + tempNode.root);
                    Console.WriteLine("Info: " + tempNode.info);
                    if (tempNode.right != null)
                        Console.WriteLine("Right Child: " + tempNode.right.info);
                    else
                        Console.WriteLine("Right Child: null");
                    if (tempNode.left != null)
                        Console.WriteLine("Left Child: " + tempNode.left.info);
                    else
                        Console.WriteLine("Left Child: null");
                    //end of the loop
                    tempNode = null;
                }
                // if is not  a match, check the right hand of the node is not null
                // and ask if the "info_to_find" is more than the info what have the actual node
                else if ((info_to_find>tempNode.info) && tempNode.right!=null)
                {
                    // replace the actual node to the right node and loop again
                    tempNode = tempNode.right;
                }
                // if is not a match, check the left hand of the node is not null
                // and ask if the "info_to_find" is more than the info what have the actual node
                else if ((info_to_find < tempNode.info) && tempNode.left != null)
                {
                    // replace the actual node to the left node and loop again
                    tempNode = tempNode.left;
                }
                else
                {
                    // if all the others rules are negative, is because the info is not here.
                    Console.WriteLine("No info found");
                    // end of the loop
                    tempNode = null;
                }
            }
        }

        /// <summary>
        /// this function find info into the tree and show results
        /// </summary>
        /// <param name="info_to_find"></param>
        public bool search_info_bool(int info_to_find)
        {
            bool result = false;
            // we create a copy of the tree
            Nodes tempNode = start;
            // then we iterate each node of the tree to find the value
            while (tempNode != null)
            {
                //if the "info_to_find" matches with the info of the node, show result
                if (tempNode.info == info_to_find)
                {
                    Console.WriteLine("info founded");
                    result = true;
                    //end of the loop
                    tempNode = null;
                }
                // if is not  a match, check the right hand of the node is not null
                // and ask if the "info_to_find" is more than the info what have the actual node
                else if ((info_to_find > tempNode.info) && tempNode.right != null)
                {
                    // replace the actual node to the right node and loop again
                    tempNode = tempNode.right;
                }
                // if is not a match, check the left hand of the node is not null
                // and ask if the "info_to_find" is more than the info what have the actual node
                else if ((info_to_find < tempNode.info) && tempNode.left != null)
                {
                    // replace the actual node to the left node and loop again
                    tempNode = tempNode.left;
                }
                else
                {
                    // if all the others rules are negative, is because the info is not here.
                    Console.WriteLine("No info founded");
                    // end of the loop
                    tempNode = null;
                }
            }
            return result;
        }


        public void delete_node(int info_to_find)
        {
            // validate if the node to delete exists
            if (search_info_bool(info_to_find))
            {
                Nodes tempNode = start;

                while (tempNode != null)
                {
                    if(tempNode.info== info_to_find)
                    {
                        // if the node to delete do not have children
                        if(tempNode.right==null && tempNode.left == null)
                        {
                            Nodes parent = new Nodes();
                            if(tempNode.parent!=null)
                                parent = tempNode.parent;

                            if(parent.right!=null)
                                if(parent.right.info==info_to_find)
                                    parent.right = null;

                            if (parent.left != null)
                                if (parent.left.info == info_to_find)
                                    parent.left = null;

                            tempNode = null;

                        }
                        // if the node to delete does have a right child
                        else if(tempNode.right!=null && tempNode.left == null)
                        {
                            //create a parent of this child
                            Nodes parent = new Nodes();
                            // if the parent of this child does not exits is the root
                            if (tempNode.parent != null)
                                parent = tempNode.parent;

                            if (parent.right != null)
                                if (parent.right.info == info_to_find)
                                {
                                    parent.right = tempNode.right;
                                    tempNode.right.parent = parent;
                                }


                            if (parent.left != null)
                                if (parent.left.info == info_to_find)
                                {
                                    parent.left = tempNode.right;
                                    tempNode.left.parent = parent;
                                }

                            tempNode = null;

                        }
                        // if the node to delete does have a left child
                        else if(tempNode.right==null && tempNode.left != null)
                        {
                            Nodes parent = new Nodes();
                            if (tempNode.parent != null)
                                parent = tempNode.parent;

                            if (parent.right != null)
                                if (parent.right.info == info_to_find)
                                {
                                    parent.right = tempNode.left;
                                    tempNode.left.parent = parent;
                                }

                            if (parent.left != null)
                                if (parent.left.info == info_to_find)
                                {
                                    parent.left = tempNode.left;
                                    tempNode.left.parent = parent;
                                }

                            tempNode = null;

                        }
                        // if the node to delete does have left and right child.
                        else if (tempNode.right != null && tempNode.left != null)
                        {
                            // i am looking the minimal value of the right hand of this node
                            // so, i will iterate as much a deep posible this branch
                            // and keep the lower value I found
                            // then this lower value i will use to the node where exist
                            // the element to delete, i rewrite de element to delete
                            // to the minimal value i found

                            Nodes minimal_right = new Nodes();
                            // create a copy of the right hand of node
                            minimal_right = tempNode.right;
                            // save the value of the node to delete
                            int temp = minimal_right.info;
                            // loop values of the right hand of this node
                            while (minimal_right != null)
                            {
                                // if the right hand of this node has got right hand values
                                if (minimal_right.right != null)
                                {
                                    // compare the value of the right hand value and the node to delete
                                    // if the node is big, rewrite temp variable
                                    if (temp> minimal_right.right.info)
                                        temp = minimal_right.right.info;
                                    //rewrite the right hand of the node with the right right hand
                                    // and start again the loop
                                    minimal_right = minimal_right.right;
                                }
                                else
                                {
                                    // is there are no more right hand nodes, finish the program
                                    minimal_right = null;
                                }
                            }
                            // now create a modify node
                            Nodes modify = new Nodes();
                            // this modify node contains the tempNode where we found the value to delete
                            modify = tempNode;
                            // then I rewrite the info of modify with the lower value of the right hand of this node
                            modify.info = temp;
                            //rewrite the tempNode to keep going the loop
                            tempNode = tempNode.right;
                            //rewrite the user value to the minimal value
                            // because now the user value is delete, but now we have two 
                            // nodes with the same values, so now the program will
                            // iterate againg but a lower lever where we found the user value
                            // and the program will delete the duplicate value by itself

                            info_to_find = temp;
                        }
                    }
                    else if ((info_to_find > tempNode.info) && tempNode.right != null)
                    {
                        // replace the actual node to the right node and loop again
                        tempNode = tempNode.right;
                    }
                    // if is not a match, check the left hand of the node is not null
                    // and ask if the "info_to_find" is more than the info what have the actual node
                    else if ((info_to_find < tempNode.info) && tempNode.left != null)
                    {
                        // replace the actual node to the left node and loop again
                        tempNode = tempNode.left;
                    }
                }

            }
            //reorder_tree();
        }

    }
     
}

