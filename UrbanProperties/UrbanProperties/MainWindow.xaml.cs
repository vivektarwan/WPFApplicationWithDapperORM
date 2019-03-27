using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using wf=System.Windows.Forms;
namespace UrbanProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }



        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            DataContext = new DataBaseOperations();
            TotalPriceTextBlock.Visibility = Visibility.Hidden ;
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            //Add logic
            AddUpdateSpaceWindow window = new AddUpdateSpaceWindow();
            window.ShowDialog();
            RefreshDataGrid();
        }

        private void CalculatePrice_Button_Click(object sender, RoutedEventArgs e)
        {
            int Sum = 0;
            //Calculator logic
            if (((SpaceEntity)SpaceDataGrid.SelectedItem) != null)
            {
                if (SpaceDataGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < SpaceDataGrid.SelectedItems.Count; i++)
                    {
                        Sum += ((SpaceEntity)SpaceDataGrid.SelectedItems[0]).Price;

                    }
                }
                else
                {
                    MessageBox.Show("Please select one space and try again.", "Info:");
                }
            }
            else
            {
                MessageBox.Show("Please select one space and try again.", "Info:");
            }

            if(Sum != 0)
            {
                TotalPriceTextBlock.Visibility = Visibility.Visible;
                TotalPriceTextBlock.Text = "Total price of selected space is  ₹ " + Sum + ".";
            }
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            //Update logic
            if (((SpaceEntity)SpaceDataGrid.SelectedItem) != null)
            {
                if (SpaceDataGrid.SelectedItems.Count == 1)
                {
                    for (int i = 0; i < SpaceDataGrid.SelectedItems.Count; i++)
                    {
                        AddUpdateSpaceWindow window = new AddUpdateSpaceWindow((SpaceEntity)SpaceDataGrid.SelectedItems[i]);
                        window.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show("Please select one space and try again.", "Info:");
                }
            }
            else
            {
                MessageBox.Show("Please select one space and try again.", "Info:");
            }

            RefreshDataGrid();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (((SpaceEntity)SpaceDataGrid.SelectedItem) != null)
            {
                if (SpaceDataGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < SpaceDataGrid.SelectedItems.Count; i++)
                    {
                        //Delete logic
                        wf.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete all selected space?", "Delete Confirmation", wf.MessageBoxButtons.YesNo);

                        if (dialogResult == wf.DialogResult.Yes)  
                        {
                            MainWindow.RemoveSpaceDetails(((SpaceEntity)SpaceDataGrid.SelectedItems[i]).Space_Id);
                        }
                        else
                        {

                        }
                    }
                }
            }
            RefreshDataGrid();
        }

    }

    public class DataBaseOperations
    {
        public ICollectionView Spaces { get; private set; }


        public DataBaseOperations()
        {
            List<SpaceEntity> tempListWithPrice = new List<SpaceEntity>();
            List<SpaceEntity> List = MainWindow.GetAllSpaceDetails();
            
            foreach(SpaceEntity temp in List)
            {
                switch(temp.Type)
                {
                    case 0:
                        Space space = new Space();
                        space.Name = temp.Name;
                        space.SquareFeet = temp.SquareFeet;
                        space.Type = temp.Type;
                        temp.Price = space.CalculatePrice();
                        tempListWithPrice.Add(temp);
                        break;
                    case 1:
                        CommercialSpace cspace = new CommercialSpace();
                        cspace.Name = temp.Name;
                        cspace.SquareFeet = temp.SquareFeet;
                        cspace.Type = temp.Type;
                        cspace.No_of_cabins = temp.No_of_cabins;
                        cspace.No_of_seats = temp.No_of_seats;
                        cspace.No_of_floors = temp.No_of_floors;
                        cspace.No_of_toilets = temp.No_of_toilets;
                        temp.Price = cspace.CalculatePrice();
                        tempListWithPrice.Add(temp);
                        break;
                    case 2:
                        ResidentialSpace rspace = new ResidentialSpace();
                        rspace.Name = temp.Name;
                        rspace.SquareFeet = temp.SquareFeet;
                        rspace.Type = temp.Type;
                        rspace.No_of_rooms = temp.No_of_rooms;
                        rspace.No_of_kitchens = temp.No_of_kitchens;
                        rspace.No_of_floors = temp.No_of_floors;
                        rspace.No_of_toilets = temp.No_of_toilets;
                        temp.Price = rspace.CalculatePrice();
                        tempListWithPrice.Add(temp);
                        break;
                    default:
                        Space dspace = new Space();
                        dspace.Name = temp.Name;
                        dspace.SquareFeet = temp.SquareFeet;
                        dspace.Type = temp.Type;
                        temp.Price = dspace.CalculatePrice();
                        tempListWithPrice.Add(temp);
                        break;

                }

            }           

            Spaces = CollectionViewSource.GetDefaultView(tempListWithPrice);
        }
       
    }
}
