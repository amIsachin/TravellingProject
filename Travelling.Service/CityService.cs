using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Travelling.Business;
using Travelling.Database;

namespace Travelling.Service
{
    public class CityService
    {
        #region SingleTon
        /*-------------------------------------- SingleTon START ------------------------------------------*/
        public static CityService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CityService();
                }
                return instance;
            }
        }
        private static CityService instance { get; set; }

        private CityService()
        {
        }
        /*-------------------------------------- SingleTon END --------------------------------------------*/
        #endregion

        /*--------------------------------------- SaveCity START ------------------------------------------*/
        public bool SaveCity(City city)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(city.Country).State = System.Data.Entity.EntityState.Unchanged;
                context.Cities.Add(city);
                return context.SaveChanges() > 0;
            }
        }
        /*--------------------------------------- SaveCity END --------------------------------------------*/

        /*--------------------------------------- TotalCityCount START ------------------------------------*/
        public int TotalCityCount(string search)
        {
            using (var context = new TravellingContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Cities.Where(x => x.Name.ToLower().Contains(search.ToLower())).Include(x => x.Country).Count();
                }
                else
                {
                    return context.Cities.Include(x => x.Country).Count();
                }
            }
        }
        /*--------------------------------------- TotalCityCount END --------------------------------------*/

        /*--------------------------------------- AllCity START -------------------------------------------*/
        public List<City> AllCity()
        {
            using (var context = new TravellingContext())
            {
                return context.Cities.Include(x => x.Country).ToList();
            }
        }
        /*--------------------------------------- AllCity END ---------------------------------------------*/

        /*--------------------------------------- SearchCity START ----------------------------------------*/
        public List<City> SearchCity(string search, int pageNo)
        {
            int pageSize = 5;
            using (var context = new TravellingContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Cities.Where(x => x.Name.ToLower().Contains(search.ToLower()))
                        .OrderBy(x => x.ID).Skip((pageNo - 1) * pageSize)
                        .Take(pageSize).Include(x => x.Country)
                        .ToList();
                }
                else
                {
                    //return context.Cities.Include(x=>x.Country).ToList();
                    return context.Cities.OrderBy(x => x.ID).Skip((pageNo - 1) * pageSize)
                        .Take(pageSize).Include(x => x.Country)
                        .ToList();
                }
            }
        }
        /*--------------------------------------- SearchCity END ------------------------------------------*/

        /*--------------------------------------- FindCity START ------------------------------------------*/
        public City FindCity(int? ID)
        {
            using (var context = new TravellingContext())
            {
                //context.Entry(ID).State = System.Data.Entity.EntityState.Unchanged;
                return context.Cities.Include(x => x.Country).FirstOrDefault(x => x.ID == ID);
            }
        }
        /*--------------------------------------- FindCity END --------------------------------------------*/

        /*--------------------------------------- UpdateCity START ----------------------------------------*/
        public bool UpdateCity(City city)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(city).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }
        /*--------------------------------------- UpdateCity END ------------------------------------------*/

        /*--------------------------------------- DeleteCity START ----------------------------------------*/
        public bool DeleteCity(City city)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(city).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
        /*--------------------------------------- DeleteCity END ------------------------------------------*/
    }
}
