using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;

namespace UrbanProperties
{
    public partial class MainWindow: MetroWindow
    {
        public static string DatabaseconnStringPoolingTrue = @"Server=" + "localhost" + ";Port=3306;Database='test';Uid=root;Pwd=" +
                "pass" + ";Pooling=true;";


        public static void AddSpaceDetails(SpaceEntity space)
        {
            DapperMySQLConnector p = new DapperMySQLConnector();
            p.db = new MySqlConnection(MainWindow.DatabaseconnStringPoolingTrue);
            StringBuilder sb = new StringBuilder();
            p.Add(space);
            p.db.Close();
        }

        public static void RemoveSpaceDetails(int space_Id)
        {
            DapperMySQLConnector p = new DapperMySQLConnector();
            p.db = new MySqlConnection(MainWindow.DatabaseconnStringPoolingTrue);
            StringBuilder sb = new StringBuilder();
            p.Remove(space_Id);
            p.db.Close();
        }

        public static void UpdateSpaceDetails(SpaceEntity space)
        {
            DapperMySQLConnector p = new DapperMySQLConnector();
            p.db = new MySqlConnection(MainWindow.DatabaseconnStringPoolingTrue);
            StringBuilder sb = new StringBuilder();
            var temp = p.Update(space);
            p.db.Close();
        }

        public static List<SpaceEntity> GetAllSpaceDetails()
        {
            List<Space> resultList = new List<Space>();
            DapperMySQLConnector p = new DapperMySQLConnector();
            p.db = new MySqlConnection(MainWindow.DatabaseconnStringPoolingTrue);
            StringBuilder sb = new StringBuilder();           
            var temp = p.GetAllSpaces();
            p.db.Close();
            return temp;
        }

        public static List<SpaceEntity> GetAllSpaceDetailsWithFilter()
        {
            List<SpaceEntity> resultList = new List<SpaceEntity>();
            DapperMySQLConnector p = new DapperMySQLConnector();
            p.db = new MySqlConnection(MainWindow.DatabaseconnStringPoolingTrue);
            StringBuilder sb = new StringBuilder();
            var temp = p.GetAllSpaces();
            p.db.Close();

            //Alarm to select space with Filters
            var queryFilterSpaces = from space in temp
                                 where space.Name == "Space Name" ||
                                 space.Type == 0
                                 select space;

            //To display alarms
            foreach (var spaceVar in queryFilterSpaces)
            {
                SpaceEntity _space = (SpaceEntity)spaceVar;
                resultList.Add(_space);
            }

            return resultList;
        }



    }
}
