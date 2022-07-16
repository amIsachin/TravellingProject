using Travelling.Business;
using Travelling.Database;

namespace Travelling.Service
{
    public class PlaceOrderService
    {
        #region SingleTon
        /*-------------------------------------- SingleTon START -----------------------------------------*/
        public static PlaceOrderService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlaceOrderService();
                }
                return instance;
            }
        }
        private static PlaceOrderService instance { get; set; }

        private PlaceOrderService()
        {
        }
        /*-------------------------------------- SingleTon END -------------------------------------------*/
        #endregion

        /*-------------------------------------- FindPlace START -----------------------------------------*/
        public bool SaveOrder(PlaceOrder placeOrder)
        {
            using (var context = new TravellingContext())
            {
                context.PlaceOrders.Add(placeOrder);
                return context.SaveChanges() > 0;
            }
        }
        /*-------------------------------------- FindPlace END -------------------------------------------*/
    }
}
