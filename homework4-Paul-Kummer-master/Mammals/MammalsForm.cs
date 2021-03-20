using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mammals
{
    public partial class MammalsForm : Form
    {
        // added a list to contain all species
        private List<Classification.Species> curSpecies = new List<Classification.Species> { };
        private IEnumerable<Classification.Order> orders;
        public MammalsForm()
        {
            InitializeComponent();
        }

        private void MammalsForm_Load(object sender, EventArgs e)
        {
            Classification.Order.ReadCsv("Classification\\Mammals.csv");
            this.orders = Classification.Order.GetOrders();

            StartTree(orders);
        }

        // creates the first parent nodes then starts recursion to determine children nodes
        private void StartTree(IEnumerable<Classification.IClassificationItem> tmpIClass)
        {
            if (tmpIClass.Count() > 0)
            {
                foreach (Classification.IClassificationItem tmp in tmpIClass)
                {
                    RecursiveTreePopulate(tmp);
                }
            }
        }

        private void RecursiveTreePopulate(Classification.IClassificationItem tmpIClass, TreeNode parentNode = null)
        {
            bool startNode = false;

            // indicates the starting node
            if (parentNode == null)
            {
                parentNode = mammalianTree.Nodes.Add(tmpIClass.Name.ToUpper(), tmpIClass.Name);
                startNode = true;
            }

            // node with more children
            if (tmpIClass.Children.Count() > 0)
            {
                TreeNode childNode = startNode ? parentNode : parentNode.Nodes.Add(tmpIClass.Name.ToUpper(), tmpIClass.Name);

                foreach (Classification.IClassificationItem tmp in tmpIClass.Children)
                {
                    RecursiveTreePopulate(tmp, childNode);
                }
            }

            // reached the end of the tree
            else
            {
                TreeNode childNode = parentNode.Nodes.Add(tmpIClass.Name.ToUpper(), tmpIClass.Name);

                // adds a reference to the node of the Iclassification
                childNode.Tag = tmpIClass;

                // add element to a species list for searching later on
                curSpecies.Add((Classification.Species)tmpIClass);
            }                 
        }

        private void mammalianTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine($"node key {e.Node.Text}");
            //check if it is a species, which have tags
            if (e.Node.Tag != null )
            {
                //convert the tag to a species class
                Classification.Species curSpecies = (Classification.Species)e.Node.Tag;

                //change gui info
                NameTextBox.Text = curSpecies.Name;
                commonNameTB.Text = curSpecies.CommonName;
                authorTB.Text = curSpecies.Author;
                dateTB.Text = curSpecies.Date;
            }
            
            //clear the entry boxes if species isn't selected
            else
            {
                NameTextBox.Text = "";
                commonNameTB.Text = "";
                authorTB.Text = "";
                dateTB.Text = "";
            }
        }

        #region delete me
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void searchButton_Click(object sender, EventArgs e)
        {
            string userEntry = searchTB.Text.ToUpper();

            // use linq to determine if the search matches any of the fields of the species
            var searchSpecies = (from tmpSpe in curSpecies
                                where tmpSpe.Author.ToUpper() == userEntry |
                                tmpSpe.CommonName.ToUpper() == userEntry |
                                tmpSpe.Date.ToUpper() == userEntry |
                                tmpSpe.Name.ToUpper() == userEntry
                                select tmpSpe.Name.ToUpper()).ToArray();

            // if linq found a result for the species pass it to the recursive search to find the node
            userEntry = searchSpecies.Length > 0 ? searchSpecies.First() : userEntry;

            TreeNode searchedNode = RecursiveSearchTree(mammalianTree.Nodes, userEntry);

            if (searchedNode != null)
            {
                mammalianTree.CollapseAll();

                foreach(TreeNode tmpNode in searchedNode.Nodes)
                {
                    if(tmpNode.Text.ToUpper() == userEntry)
                    {
                        tmpNode.EnsureVisible();
                        mammalianTree.SelectedNode = tmpNode;
                    }
                }
            }
        }
  
        private TreeNode RecursiveSearchTree (TreeNodeCollection tmpNodes, string keyword)
        {
            TreeNode nodeToReturn = null;

            foreach(TreeNode tmpNode in tmpNodes)
            {
                if (tmpNode.Nodes.ContainsKey(keyword))
                {
                    // stop the for loop and return the node
                    return tmpNode;
                }

                else
                {                  
                    nodeToReturn = RecursiveSearchTree(tmpNode.Nodes, keyword);

                    if (nodeToReturn != null)
                    {
                        // stop for loop and recursion to return the node
                        return nodeToReturn;
                    }    
                }
            }

            return nodeToReturn;
        }
    }
}
