using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Travelling.Business;
using Travelling.Database;

namespace Travelling.Service
{
    public class PlaceService
    {
        #region SingleTon
        /*-------------------------------------- SingleTon START -----------------------------------------*/
        public static PlaceService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlaceService();
                }
                return instance;
            }
        }
        private static PlaceService instance { get; set; }

        private PlaceService()
        {
        }
        /*-------------------------------------- SingleTon END -------------------------------------------*/
        #endregion

        /*-------------------------------------- FindPlace START -----------------------------------------*/
        public Place FindPlace(int? ID)
        {
            using (var context = new TravellingContext())
            {
                //--> return context.Places.Find(ID);
                return context.Places.Include(x => x.City).FirstOrDefault(x => x.ID == ID);
            }
        }
        /*-------------------------------------- FindPlace END -------------------------------------------*/

        /*-------------------------------------- AllPlaces START -----------------------------------------*/
        public List<Place> AllPlaces()
        {
            using (var context = new TravellingContext())
            {
                return context.Places.Include(x => x.City).ToList();
            }
        }
        /*-------------------------------------- AllPlaces END -------------------------------------------*/

        /*-------------------------------------- AllNewPlaces START --------------------------------------*/
        public List<Place> AllNewPlaces()
        {
            using (var context = new TravellingContext())
            {
                return context.Places.OrderByDescending(x=>x.ID).Include(x => x.City).ToList();
            }
        }
        /*-------------------------------------- AllNewPlaces END ----------------------------------------*/

        /*-------------------------------------- SavePlace START -----------------------------------------*/
        public bool SavePlace(Place place)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(place.City).State = System.Data.Entity.EntityState.Unchanged;
                context.Places.Add(place);
                return context.SaveChanges() > 0;
            }
        }
        /*-------------------------------------- SavePlace END -------------------------------------------*/

        /*-------------------------------------- UpdatePlace START ---------------------------------------*/
        public bool UpdatePlace(Place place)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(place.City).State = System.Data.Entity.EntityState.Modified;
                context.Entry(place).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }
        /*-------------------------------------- UpdatePlace END -----------------------------------------*/

        /*-------------------------------------- DeletePlace START ---------------------------------------*/
        public void DeletePlace(Place place)
        {
            using (var context = new TravellingContext())
            {
                context.Entry(place).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        /*-------------------------------------- DeletePlace END -----------------------------------------*/

        /*-------------------------------------- SearchPlace START ---------------------------------------*/
        public IEnumerable<Place> SearchPlace(string search)
        {
            using (var context = new TravellingContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Places.Include(x => x.City).Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    return context.Places.Include(x => x.City).ToList();
                }
            }
        }
        /*-------------------------------------- SearchPlace END -----------------------------------------*/
    }
}
