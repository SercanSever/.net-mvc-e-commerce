using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommercial.UI.Models
{
    public class FavoriteCountViewModel
    {
        public List<UserFavorite> UserFavorites { get; set; }
    }
}