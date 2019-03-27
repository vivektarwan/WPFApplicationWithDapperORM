using System;
using System.Collections.Generic;
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

namespace UrbanProperties
{
    /// <summary>
    /// Interaction logic for AddSpaceWindow.xaml
    /// </summary>
    public partial class AddUpdateSpaceWindow : MetroWindow
    {
        SpaceEntity localSpace = null;
        bool UpdateWindow = false;
        public AddUpdateSpaceWindow()
        {
            InitializeComponent();
        }

        public AddUpdateSpaceWindow(SpaceEntity space)
        {
            InitializeComponent();
            localSpace = space;
            this.Title = "Update Space";
            UpdateWindow = true;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(localSpace !=null)
            {
                SpaceNameTextBox.Text = localSpace.Name;
                AreaTextBox.Text = localSpace.SquareFeet.ToString();
                TypeCombobox.SelectedIndex = localSpace.Type;
                NumericUpDownCabins.Value = localSpace.No_of_cabins;
                NumericUpDownFloors.Value = localSpace.No_of_floors;
                NumericUpDownKitchens.Value = localSpace.No_of_kitchens;
                NumericUpDownRooms.Value = localSpace.No_of_rooms;
                NumericUpDownSeats.Value = localSpace.No_of_seats;
                NumericUpDownToilets.Value = localSpace.No_of_toilets;
            }
               

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(SpaceNameTextBox.Text) ||
               string.IsNullOrEmpty(AreaTextBox.Text))
            {
                MessageBox.Show("Please enter required details and try again.");
                return;
            }
            int areaVal = 0;
            if(!int.TryParse(AreaTextBox.Text, out areaVal))
            {
                MessageBox.Show("Please enter area details as number and try again.");
                return;
            }

            SpaceEntity temp = new SpaceEntity();
            temp.Name = SpaceNameTextBox.Text;
            temp.SquareFeet = areaVal;
            temp.Type = TypeCombobox.SelectedIndex;
            temp.No_of_cabins = (int)NumericUpDownCabins.Value;
            temp.No_of_floors = (int)NumericUpDownFloors.Value;
            temp.No_of_kitchens = (int)NumericUpDownKitchens.Value;
            temp.No_of_rooms = (int)NumericUpDownRooms.Value;
            temp.No_of_seats = (int)NumericUpDownSeats.Value;
            temp.No_of_toilets = (int)NumericUpDownToilets.Value;

            if (!UpdateWindow)
            {
                MainWindow.AddSpaceDetails(temp);
            }
            else
            {
                temp.Space_Id = localSpace.Space_Id;
                MainWindow.UpdateSpaceDetails(temp);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TypeCombobox == null)
            {
                return;
            }
            try
            {
                switch (TypeCombobox.SelectedIndex)
                {
                    case 0:
                        NumericUpDownFloors.Visibility = Visibility.Hidden;
                        NumericUpDownFloors.Value = 0;
                        TextBlock_Floor.Visibility = Visibility.Hidden;

                        NumericUpDownCabins.Visibility = Visibility.Hidden;
                        NumericUpDownCabins.Value = 0;
                        TextBlock_Cabin.Visibility = Visibility.Hidden;

                        NumericUpDownSeats.Visibility = Visibility.Hidden;
                        NumericUpDownSeats.Value = 0;
                        TextBlock_Seat.Visibility = Visibility.Hidden;

                        NumericUpDownToilets.Visibility = Visibility.Hidden;
                        NumericUpDownToilets.Value = 0;
                        TextBlock_Toilet.Visibility = Visibility.Hidden;

                        NumericUpDownRooms.Visibility = Visibility.Hidden;
                        NumericUpDownRooms.Value = 0;
                        TextBlock_Room.Visibility = Visibility.Hidden;

                        NumericUpDownKitchens.Visibility = Visibility.Hidden;
                        NumericUpDownKitchens.Value = 0;
                        TextBlock_Kitchen.Visibility = Visibility.Hidden;

                        break;
                    case 1:
                        NumericUpDownFloors.Visibility = Visibility.Visible;
                        TextBlock_Floor.Visibility = Visibility.Visible;

                        NumericUpDownCabins.Visibility = Visibility.Visible;
                        TextBlock_Cabin.Visibility = Visibility.Visible;

                        NumericUpDownSeats.Visibility = Visibility.Visible;
                        TextBlock_Seat.Visibility = Visibility.Visible;

                        NumericUpDownToilets.Visibility = Visibility.Visible;
                        TextBlock_Toilet.Visibility = Visibility.Visible;

                        NumericUpDownKitchens.Visibility = Visibility.Hidden;
                        TextBlock_Kitchen.Visibility = Visibility.Hidden;
                        NumericUpDownKitchens.Value = 0;
                        NumericUpDownRooms.Visibility = Visibility.Hidden;
                        TextBlock_Room.Visibility = Visibility.Hidden;
                        NumericUpDownRooms.Value = 0;

                        break;
                    case 2:
                        NumericUpDownFloors.Visibility = Visibility.Visible;
                        TextBlock_Floor.Visibility = Visibility.Visible;

                        NumericUpDownKitchens.Visibility = Visibility.Visible;
                        TextBlock_Kitchen.Visibility = Visibility.Visible;

                        NumericUpDownRooms.Visibility = Visibility.Visible;
                        TextBlock_Room.Visibility = Visibility.Visible;

                        NumericUpDownToilets.Visibility = Visibility.Visible;
                        TextBlock_Toilet.Visibility = Visibility.Visible;

                        NumericUpDownCabins.Visibility = Visibility.Hidden;
                        TextBlock_Cabin.Visibility = Visibility.Hidden;
                        NumericUpDownCabins.Value = 0;
                        NumericUpDownSeats.Visibility = Visibility.Hidden;
                        TextBlock_Seat.Visibility = Visibility.Hidden;
                        NumericUpDownSeats.Value = 0;
                        break;
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
