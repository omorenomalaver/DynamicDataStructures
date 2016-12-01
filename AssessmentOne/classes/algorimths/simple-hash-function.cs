using AssessmentOne.classes.algorimths.tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentOne
{
    /// <summary>
    /// this classhas got the specifications to create  a hash algorithm
    /// </summary>
    class simple_hash_function
    {
        /// <summary>
        /// the max lenght of the hast table
        /// </summary>
        public int max_hash_table;
        /// <summary>
        /// the hash table, is a object because can containg anything, a array, tree, double linked list, etc...
        /// </summary>
        public object[] hash_table;

        /// <summary>
        /// constructor of the class
        /// </summary>
        public simple_hash_function()
        {
            max_hash_table = 10;
            hash_table = new object[max_hash_table];
        }

        /// <summary>
        /// define the maximun primus element to divided the hash table
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int hash_function(int data)
        {
            int result;

            result = data % 9;

            return result;
        }

        /// <summary>
        /// this function insert these values into the hash table using a binary tree to storage values
        /// </summary>
        /// <param name="data"></param>
        public void insert(int data)
        {
            Console.WriteLine("-------" + data);
            //
            int hash_table_position = hash_function(data);

            if (hash_table[hash_table_position] == null)
            {
                tree mySimpleTree = new tree();
                mySimpleTree.insert_node(data);
                hash_table[hash_table_position] = mySimpleTree;
            }
            else
            {
                tree mySimpleTree = new tree();
                mySimpleTree = (tree)hash_table[hash_table_position];
                mySimpleTree.insert_node(data);
            }
        }
        /// <summary>
        /// this function display the hash table into console
        /// </summary>
        public void displayHash()
        {
            for(int i = 0; i<= hash_table.Length-1; i++)
            {
                tree myTree = new tree();
                myTree = (tree)hash_table[i];
                Console.WriteLine("*********************************");
                Console.WriteLine("***** Hash Table:" + i + " ******");
                Console.WriteLine("*********************************");
                if (myTree != null)
                    myTree.show_tree();
                else
                    Console.WriteLine("      ");
            }
        }
        /// <summary>
        /// this function return the hash table object
        /// </summary>
        /// <returns></returns>
        public Object HashListTable()
        {
            return hash_table;
        }
        /// <summary>
        /// this function dispaly the unhashed table into console
        /// </summary>
        public void displayUnHash()
        {
            List<int> listElements = new List<int>();
            // show me those hash elements
            for (int i = 0; i <= hash_table.Length - 1; i++)
            {
                // show me what inside of each hash element contains
                tree myTree = new tree();
                myTree = (tree)hash_table[i];
                if (myTree != null)
                {
                    foreach (Nodes nodes in myTree.list_tree())
                    {
                        listElements.Add(nodes.info);
                    }
                }
            }


            foreach(int elements in listElements)
            {
                Console.WriteLine("-------" + elements);
            }
        }
        /// <summary>
        /// well,... this is no necesary because is not into the points we have to do into our assessment
        /// </summary>
        /// <param name="data"></param>
        public void delete( int data)
        {

        }

        

    }
}
