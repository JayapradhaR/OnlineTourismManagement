using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.BL
{
    public interface IOrderBL
    {
        void AddOrderDetails(Order orderDetails);
        Order ViewOrderDetails(int OrderId);
    }
    public class OrderBL : IOrderBL
    {
        IOrderDAL orderDAL;
        public OrderBL()
        {
            orderDAL = new OrderRepository();
        }
        public void AddOrderDetails(Order orderDetails)
        {

            orderDAL.AddOrderDetails(orderDetails); //Call AddOrderDetails() to store order details
        }
        public Order ViewOrderDetails(int OrderId)
        {
            return orderDAL.ViewOrdersById(OrderId); //Call ViewOrderDetails() to view details
        }
    }
}
