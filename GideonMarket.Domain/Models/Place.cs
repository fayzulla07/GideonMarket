using GideonMarket.Entities.Enums;
using GideonMarket.Entities.Shared;
using System.Collections.Generic;
using System.Linq;

namespace GideonMarket.Entities.Models
{
    public class Place : Entity, MainEntity
    {
        public string Name { get; private set; }
        public PlaceType PlaceType { get; private set; }
        public List<PlaceItem> PlaceItems { get; private set; }

        public Place()
        {

        }
        public Place(string name, PlaceType placeType)
        {
            Name = name;
            PlaceType = placeType;
        }

        #region for Order
        public void UpdateOrder(int productId, double oldCount, double count)
        {
            if (count > oldCount)
            {
                ReduceCount(productId, (oldCount - count));
            }
            else if (count < oldCount)
            {
                AddCount(productId, (count - oldCount));
            }
        }
        // Отменить заказ
        public void CancelOrder(int productId, double count)
        {
            AddCount(productId, count);
        }
        // Запустить отменённый заказ
        public void ReCancelOrder(int productId, double count)
        {
            ReduceCount(productId, count);
        }
        // Создать заказ
        public void MakeOrder(int productId, double count)
        {
            ReduceCount(productId, count);
        }

        // Удалить заказ
        public void DeleteOrder(int productId, double count)
        {
            AddCount(productId, count);
        }

        #endregion

        #region for income
        public void UpdateProductInPlace(int productId, double oldCount, double incomecount)
        {
            if (incomecount > oldCount) 
            {
                AddCount(productId, (incomecount - oldCount));
            }
            else if(incomecount < oldCount)
            {
                ReduceCount(productId, (oldCount - incomecount));
            }
        }

        public void AddProductToPlace(int productId, double count)
        {

             // Если товар есть на складе то просто увеличиваем количество
             if (PlaceItems != null && PlaceItems.Any())
             {
                 AddCount(productId, count);
             }
            else  // Если товар нет в складе то создаём и добавляем их
            {
                CreateItem(productId);
                AddCount(productId, count);
            }
        }

        public void RemoveProductFromPlace(int productId, double count)
        {
            ReduceCount(productId, count);
        }
        #endregion

        #region Shared Modules
        private void AddCount(int productId, double count)
        {
            foreach (var item in PlaceItems)
            {
                if (item.ProductId == productId)
                {
                    item.AddCount(count);
                    break;
                }
            }
        }
        private void ReduceCount(int productId, double count)
        {
            foreach (var item in PlaceItems)
            {
                if (item.ProductId == productId)
                {
                    item.ReduceCount(count);
                    break;
                }
            }
        }

        private void CreateItem(int productId)
        {
            var placeitem = new PlaceItem(Id, productId);
            if (PlaceItems == null)
            {
                PlaceItems = new List<PlaceItem>();
            }
            PlaceItems.Add(placeitem);
        }
        #endregion



    }
}
