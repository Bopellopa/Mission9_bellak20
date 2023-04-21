// Import necessary libraries
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WaterProject.infrastructure;

namespace WaterProject.Models
{
    // SessionBasket inherits from Basket
    public class SessionBasket : Basket
    {
 
        // Static method to retrieve basket from session
        public static Basket GetBasket(IServiceProvider services)
        {
            // Retrieve session object from HttpContextAccessor service
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            // Deserialize session object to SessionBasket, or create a new SessionBasket if it's null
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            basket.Session = session;
            return basket;
        }
        // Ignored property for Session object
        [JsonIgnore]
        public ISession Session { get; set; }

        // Override method to add an item to basket, and serialize it back to session
        public override void AddItem(Books book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Basket", this);
        }

        // Override method to remove an item from basket, and serialize it back to session
        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }

        internal static SessionBasket GetBasket(IHttpContextAccessor httpContextAccessor)
        {
            throw new NotImplementedException();
        }

        // Override method to clear basket, and remove it from session
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }

}
