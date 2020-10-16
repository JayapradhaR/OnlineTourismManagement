using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public interface IGiftCardTypeDAL //Interface for giftcard type
    {
        void AddGiftCardType(GiftCardType giftCardType);
        void UpdateGiftCardType(GiftCardType giftCardType);
        void DeleteGiftCardType(int GiftCardTypeId);
        IEnumerable<GiftCardType> GetGiftCardTypes();
        GiftCardType GetGiftCardTypeById(int giftCardTypeId);
    }
    public class GiftCardTypeRepository : IGiftCardTypeDAL
    {
        //Get GiftCardTypes
        public IEnumerable<GiftCardType> GetGiftCardTypes()
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                return context.GiftCardTypes.ToList();
            }
        }
        //Add giftcardtyes into database
        public void AddGiftCardType(GiftCardType giftCardType)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                context.GiftCardTypes.Add(giftCardType);
                context.SaveChanges();
            }
        }

        //GetGiftCardTypes using cardid
        public GiftCardType GetGiftCardTypeById(int giftCardTypeId)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                return context.GiftCardTypes.ToList().Where(id => id.GiftCardTypeId == giftCardTypeId).SingleOrDefault();
            }
        }
        //Update Giftcardtypes 
        public void UpdateGiftCardType(GiftCardType giftCardType)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext() )
            {
                context.Entry(giftCardType).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Delete giftcardtype from database 
        public void DeleteGiftCardType(int giftCardTypeId)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                GiftCardType giftCardType = GetGiftCardTypeById(giftCardTypeId);
                context.GiftCardTypes.Attach(giftCardType);
                context.GiftCardTypes.Remove(giftCardType);
                context.SaveChanges();
            }
        }
    }
}
