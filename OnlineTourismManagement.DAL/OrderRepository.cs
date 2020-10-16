using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.DAL
{
    public interface IOrderDAL
    {
        void AddOrderDetails(Order orderDetails);
        void CancelOrderDetails(int id);
        Order ViewOrdersById(int OrderId);
    }
    public class OrderRepository: IOrderDAL
    {
        public void AddOrderDetails(Order orderDetails)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.OrderDetails.Add(orderDetails);
                context.SaveChanges();
            }
        }

        public void CancelOrderDetails(int id)
        {
            
        }

        public Order ViewOrdersById(int OrderId)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                return context.OrderDetails.Where(id => id.BookingId == OrderId).SingleOrDefault();
            }
        }
    }
}
