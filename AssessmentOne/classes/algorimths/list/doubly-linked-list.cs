using System;

namespace AssessmentOne.classes.algorimths.list
{
    /// <summary>
    /// this class give the whole objects to create a double linked list
    /// </summary>
    public class doubly_linked_list
    {
        /// <summary>
        /// this object is a node object what contains the double linked list object
        /// </summary>
        NodesDLL doubleLinkedList;
        
        /// <summary>
        /// this function will return the double linked list object created
        /// </summary>
        /// <returns></returns>
        public NodesDLL showData()
        {
            return doubleLinkedList;
        }

        /// <summary>
        /// this function will insert values into the double linked list object
        /// </summary>
        /// <param name="data_to_insert">this param is expected as integer</param>
        public void insert_node(int data_to_insert)
        {
            NodesDLL tempDLL = new NodesDLL();
            tempDLL.data = data_to_insert;
            //if the list object is empty, start it with the temporal variable
            if (doubleLinkedList == null)
            {
                doubleLinkedList = tempDLL;
            }
            else
            {
                // create a temporal variable to storage the list
                NodesDLL temp2DLL = new NodesDLL();
                temp2DLL = doubleLinkedList;
                //loop the list unltil find the end of the list
                while (temp2DLL != null)
                {
                    if (temp2DLL.next == null)
                    {
                        // when find the end of the list, add the new value
                        temp2DLL.next = tempDLL;
                        tempDLL.prev = temp2DLL;
                        temp2DLL = null;
                    }
                    else
                    {
                        //if is not the end of the list, jump to the next list value
                        temp2DLL = temp2DLL.next;
                    }
                }
                
            }
            
        }
        /// <summary>
        /// this function show the double linked list as console check
        /// </summary>
        public void show_double_linked_list()
        {
            NodesDLL tempDLL = new NodesDLL();
            tempDLL = doubleLinkedList;
            while (tempDLL != null)
            {
                if (tempDLL.prev != null)
                {
                    Console.WriteLine("previous node: " + tempDLL.prev.data);
                }
                else
                {
                    Console.WriteLine("previous node: null");
                }

                Console.WriteLine("Data: " + tempDLL.data);

                if (tempDLL.next != null)
                {
                    Console.WriteLine("next node: " + tempDLL.next.data);
                    tempDLL = tempDLL.next;
                }
                else
                {
                    Console.WriteLine("next node: null");
                    tempDLL = null;
                }
            }
        }
        /// <summary>
        /// this function find values into the double linked list, will show values into console test
        /// </summary>
        /// <param name="data_to_find"></param>
        public void find_node(int data_to_find)
        {
            NodesDLL tempDLL = new NodesDLL();
            tempDLL = doubleLinkedList;

            Console.WriteLine("********** Searching Value ***********" + data_to_find);

            while (tempDLL != null)
            {
                if(tempDLL.data == data_to_find)
                {
                    if (tempDLL.prev != null)
                    {
                        Console.WriteLine("previous node: " + tempDLL.prev.data);
                    }
                    else
                    {
                        Console.WriteLine("previous node: null");
                    }

                    Console.WriteLine("Data: " + tempDLL.data);

                    if (tempDLL.next != null)
                    {
                        Console.WriteLine("next node: " + tempDLL.next.data);
                        tempDLL = tempDLL.next;
                    }
                    else
                    {
                        Console.WriteLine("next node: null");
                        tempDLL = null;
                    }
                    tempDLL = null;
                }
                else
                {
                    if (tempDLL.next != null)
                        tempDLL = tempDLL.next;
                    else
                    {
                        Console.WriteLine("No data found");
                        tempDLL = null;
                    }
                }
                
            }
        }

        /// <summary>
        /// this function will find a value into the double linked list object
        /// </summary>
        /// <param name="data_to_find">expect a integer value</param>
        /// <returns>return true if the value exist into the list, otherwise will be false</returns>
        public bool findNode(int data_to_find)
        {
            NodesDLL tempDLL = new NodesDLL();
            tempDLL = doubleLinkedList;

            Console.WriteLine("********** Searching Value ***********" + data_to_find);
            // will make a loop cheching since the begining until the end of the list, asking if some data info store into this list is equal than the value to be found
            //
            while (tempDLL != null)
            {
                if (tempDLL.data == data_to_find)
                {
                    return true;
                    tempDLL = null;
                }
                else
                {
                    if (tempDLL.next != null)
                        tempDLL = tempDLL.next;
                    else
                    {
                        Console.WriteLine("No data found");
                        tempDLL = null;
                    }
                }

            }
            return false;
        }
        /// <summary>
        /// this function find the node to be delete, acording a value give by user
        /// </summary>
        /// <param name="tempDLL">list object to be search</param>
        /// <param name="data_to_find">value to be find into the list</param>
        /// <returns>node found</returns>
        private NodesDLL find_node_to_delete(NodesDLL tempDLL, int data_to_find)
        {
            NodesDLL result = new NodesDLL();

            Console.WriteLine("********** Searching Value to delete ***********" + data_to_find);
            //make a loop to find the value, if it exists, will storage it and return the node
            while (tempDLL != null)
            {
                if (tempDLL.data == data_to_find)
                {
                    result = tempDLL;
                    tempDLL = null;
                }
                else
                {
                    if (tempDLL.next != null)
                        tempDLL = tempDLL.next;
                    else
                        tempDLL = null;
                }
            }
            return result;
        }
        /// <summary>
        /// this function delete nodes into the double linked list object
        /// </summary>
        /// <param name="data_to_delete">value as integer is expected</param>
        public void delete_node(int data_to_delete)
        {
            
            NodesDLL tempDLL = new NodesDLL();
            tempDLL = doubleLinkedList;
            // create a temporally object with a node found to be delete
            tempDLL = find_node_to_delete(tempDLL, data_to_delete);

            if (tempDLL != null)
            {
                //if the node contains values, will ask is has got a previous or next connections
                Console.WriteLine("found value to delete");
                // if the node have not any connection next and previous, delete
                if (tempDLL.prev==null && tempDLL.next==null)
                {
                    tempDLL = new NodesDLL();
                }
                else if(tempDLL.prev==null && tempDLL.next != null)
                {
                   // if the node to delete got a next connection,  disconnect the next conection give the previos conections of this
                   // node to be delete
                    doubleLinkedList = new NodesDLL();
                    tempDLL.next.prev = null;
                    doubleLinkedList = tempDLL.next;

                }
                else if(tempDLL.prev!=null && tempDLL.next==null)
                {
                    //if the node is the last node into the list, just disconnect the preovious node value
                    tempDLL.prev.next = null;
                }
                else if(tempDLL.prev !=  null && tempDLL.next != null)
                {
                    // if both next and previous are connected into this node, cross connections
                    NodesDLL preNodeDelete = tempDLL.prev;
                    NodesDLL nextNodeDelete = tempDLL.next;

                    tempDLL.prev.next = nextNodeDelete;
                    tempDLL.next.prev = preNodeDelete;

                }
            }
        }

    }
    
}
