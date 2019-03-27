
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanProperties
{
    public interface ISpaceRepository
    {
        List<SpaceEntity> GetAllSpaces();
        SpaceEntity Add(SpaceEntity space);
        SpaceEntity Update(SpaceEntity space);
        void Remove(int id);
    }
    

    public class SpaceEntity : SpaceEntityAdd
    {
        public SpaceEntity()
        {
        }

        public int Space_Id { get; set; }        
        public int Price { get; set; }

        public bool IsNew
        {
            get
            {
                return this.Space_Id == default(int);
            }
        }
    }

    public class SpaceEntityAdd
    {
        public SpaceEntityAdd()
        {
        }

        public string  Name { get; set; }
        public int  Type { get; set; }
        public int  SquareFeet { get; set; }
        public int  No_of_floors  { get; set; }
        public int  No_of_seats  { get; set; }
        public int  No_of_cabins { get; set; }
        public int  No_of_toilets { get; set; }
        public int  No_of_rooms  { get; set; }
        public int No_of_kitchens { get; set; }
    }

}