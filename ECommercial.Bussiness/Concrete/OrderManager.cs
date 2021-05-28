using ECommercial.Bussiness.Abstract;
using ECommercial.Core.Utilities.Business;
using ECommercial.Core.Utilities.Results;
using ECommercial.DataAccess.Abstract;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IOrderDetailService _orderDetailService;
        private IProductService _productService;
        private IUserService _userService;

        public OrderManager(IOrderDal orderDal, IOrderDetailService orderDetailService, IProductService productService, IUserService userService)
        {
            _orderDal = orderDal;
            _orderDetailService = orderDetailService;
            _productService = productService;
            _userService = userService;
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            BusinessRules.Run(AddDataOrderDetailsFromOrder(order));
            return new SuccessResult();
        }


        private IResult AddDataOrderDetailsFromOrder(Order order)
        {
            var product = _productService.GetById(order.ProductId);
            var user = _userService.GetById(order.UserId);
            var orderDetails = new OrderDetail
            {
                OrderId = order.OrderId,
                OrderQuantity = order.Quantity,
                ProductName = product.Data.Name,
                TotalPaymant = (product.Data.UnitPrice * order.Quantity),
                UserEmail = user.Data.Email,
                UserLastName = user.Data.LastName,
                UserName = user.Data.FirstName,
                OrderDate = order.OrderDate,
            };
            _orderDetailService.Add(orderDetails);
            return new SuccessResult();
        }
    }
}
