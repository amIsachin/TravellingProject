using System.Collections.Generic;
using System.Linq;
using Travelling.Business;
using Travelling.Database;

namespace Travelling.Service
{
    public class CountryService
    {
        #region SingleTon
        /*-------------------------------------- SingleTon START ----------------------------------------*/
        public static CountryService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CountryService();
                }
                return instance;
            }
        }
        private static CountryService instance { get; set; }

        private CountryService()
        {
        }

        /*-------------------------------------- SingleTon END ------------------------------------------*/
        #endregion

        /*------------------------------------- SaveCountry START ---------------------------------------*/
        public void SaveCountry(Country country)
        {
            using (var context = new TravellingContext())
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }
        }
        /*------------------------------------- SaveCountry END -----------------------------------------*/

        /*------------------------------------- AllCountry START ----------------------------------------*/
        public List<Country> AllCountry()
        {
            using (var context = new TravellingContext())
            {
                return context.Countries.ToList();
            }
        }
        /*------------------------------------- AllCountry END ------------------------------------------*/

        /*------------------------------------- Pagination START ----------------------------------------*/
        public List<Country> Pagination(int pageNo)
        {
            int pageSize = 5;
            using (var context = new TravellingContext())
            {
                return context.Countries.OrderBy(x => x.ID).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        /*------------------------------------- Pagination END ------------------------------------------*/

        /*------------------------------------- LastPage START ------------------------------------------*/
        public int LastPage()
        {
            using (var context = new TravellingContext())
            {
                return context.Countries.OrderByDescending(x => x.ID).Count();
            }
        }
        /*------------------------------------- LastPage END --------------------------------------------*/

        /*------------------------------------- SearchCountry START -------------------------------------*/
        public List<Country> SearchCountry(string search, int pageNo)
        {
            int pageSize = 5;
            using (var context = new TravellingContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Countries.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    return context.Countries.OrderBy(x => x.ID).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                }
            }
        }
        /*------------------------------------- SearchCountry END ---------------------------------------*/

        /*------------------------------------- FindCountry START ---------------------------------------*/
        public Country FindCountry(int? ID)
        {
            using (var context = new TravellingContext())
            {
                return context.Countries.FirstOrDefault(x => x.ID == ID);
            }
        }
        /*------------------------------------- FindCountry END -----------------------------------------*/

        /*------------------------------------- EditCountry START ---------------------------------------*/
        public void EditCountry(Country country)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(country).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        /*------------------------------------- EditCountry END -----------------------------------------*/

        /*------------------------------------- DeleteCountry START -------------------------------------*/
        public void DeleteCountry(Country country)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(country).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        /*------------------------------------- DeleteCountry END ---------------------------------------*/
    }
}
