using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        //The definition for the delegate
        public delegate void MentionDiscount(decimal subTotal);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        //Func is a C# builit in delegate that takes (many - 16, arguments and returns a value - out)
        //in the use below, we pass in a List of ProductModel, the subTotal and we expect an out (return value).
        //and we name (give an alias - not too sure is saying alias is correct, but doing so for my understanding) so this Func<T> is easier to use.
        //I also use the type Action. Also a built in C# Delegate but an Action dosn't have a return type.
        //Tim Corey mentions that normally, Func and Action would not be used in this way, but this is a Delegate Demo App and so lets show C# Delegates in use.
        public decimal GenerateTotal(MentionDiscount mentionSubTotal, 
            Func<List<ProductModel>,decimal,decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)
        {
            //throw new NotImplementedException();

            //Use delegate. 
            decimal subTotal = Items.Sum(x => x.Price);
            mentionSubTotal(subTotal);
            tellUserWeAreDiscounting("We are applying your discount");

            ////Calculate Discount depending on amount of purchase
            ////These hard code values are bad practice. It leads to violating the Open Close Principal 
            //if(subTotal > 100)
            //{
            //    return subTotal * 0.80M;
            //}
            //else if(subTotal > 50)
            //{
            //    return subTotal * 0.85M;
            //}
            //else if(subTotal > 10)
            //{
            //    return subTotal * 0.90M;
            //}
            //else
            //{
            //    return subTotal;
            //}

            decimal total = calculateDiscountedTotal(Items, subTotal);

            return total;

        }
    }
}
