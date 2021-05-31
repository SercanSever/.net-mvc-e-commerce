using ECommercial.Bussiness.Abstract;
using ECommercial.Bussiness.Concrete;
using ECommercial.Core.CrossCuttingConcerns.Caching;
using ECommercial.Core.CrossCuttingConcerns.Caching.Microsoft;
using ECommercial.DataAccess.Abstract;
using ECommercial.DataAccess.Concrete.EntityFramework;
using ECommercial.DataAccess.Context;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ECommercialContext>();

            Bind<ICacheManager>().To<MemoryCacheManager>();
            Bind<ICartService>().To<CartManager>();

            Bind<IProductService>().To<ProductManager>();
            Bind<IProductDal>().To<EfProductDal>();

            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICategoryDal>().To<EfCategoryDal>();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            Bind<IProductImageService>().To<ProductImageManager>();
            Bind<IProductImageDal>().To<EfProductImageDal>();

            Bind<IUserFavoriteService>().To<UserFavoriteManager>();
            Bind<IUserFavoriteDal>().To<EfUserFavoriteDal>();

            Bind<ICommentService>().To<CommentManager>();
            Bind<ICommentDal>().To<EfCommentDal>();

            Bind<IUserAddressService>().To<UserAddressManager>();
            Bind<IUserAddressDal>().To<EfUserAddressDal>();

            Bind<IOrderService>().To<OrderManager>();
            Bind<IOrderDal>().To<EfOrderDal>();

            Bind<IOrderDetailService>().To<OrderDetailManager>();
            Bind<IOrderDetailDal>().To<EfOrderDetailDal>();

            Bind<IContactService>().To<ContactManager>();
            Bind<IContactDal>().To<EfContactDal>();

            Bind<IEmailService>().To<EmailManager>();
            Bind<IEmailDal>().To<EfEmailDal>();
        }
    }
}
