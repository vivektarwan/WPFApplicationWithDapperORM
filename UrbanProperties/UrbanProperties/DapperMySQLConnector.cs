using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace UrbanProperties
{
    class DapperMySQLConnector : ISpaceRepository
    {
        public IDbConnection db = new MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=pass;Port=3306;Pooling=true;");
       
        public SpaceEntity Add(SpaceEntity space)
        {
            string query = @"Insert into space(Name,Type,No_of_floors,No_of_seats,No_of_rooms,No_of_kitchens" + 
                ",No_of_toilets,No_of_cabins,SquareFeet) values(@Name,@Type,@No_of_floors,@No_of_seats,@No_of_rooms,"+
                "@No_of_kitchens,@No_of_toilets,@No_of_cabins,@SquareFeet);select Cast(LAST_INSERT_ID() as int)";
            db.Query<int>(query,space).SingleOrDefault();
            return space;
        }       

        
        public System.Collections.Generic.List<SpaceEntity> GetAllSpaces()
        {
            string query = "select * from space order by Space_Id desc";
            return (List<SpaceEntity>)db.Query<SpaceEntity>(query);
        }

            
        public SpaceEntity Update(SpaceEntity space)
        {
            string query = "update space set Name = '" + space.Name  + "' , Type = " + space.Type +
                " , No_of_floors = " + space.No_of_floors +
                " ,No_of_seats = "+ space.No_of_seats +
                ",No_of_rooms = " + space.No_of_rooms +
                ", No_of_kitchens =" + space.No_of_kitchens +
                ",No_of_toilets = " + space.No_of_toilets +
                ", No_of_cabins =" + space.No_of_cabins +
                ",SquareFeet =" + space.SquareFeet +
                " where Space_Id = @Space_Id";
            int i = db.Execute(query, new { Space_Id = space.Space_Id });
            space.Space_Id = i;
            return space;
        }
        public void Remove(int Space_Id)
        {
            string query = "delete from space where Space_Id = @Space_Id";
            int i = db.Execute(query, new { Space_Id = Space_Id });
        }
    }
}

