using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System.Collections.Generic;

namespace OnlineTourismManagement.BL
{
    public interface IGiftCardTypeBL //Interface for Giftcardtype
    {
        void AddGiftCardType(GiftCardType giftCardType);
        void UpdateGiftCardType(GiftCardType giftCardType);
        void DeleteGiftCardType(int giftCardTypeId);
        GiftCardType GetGiftCardTypeById(int giftCardTypeId);
        IEnumerable<GiftCardType> GetGiftCardTypes();
    }
    public class GiftCardTypeBL: IGiftCardTypeBL
    {
        IGiftCardTypeDAL giftCardTypeDAL;
        public GiftCardTypeBL()
        {
            giftCardTypeDAL = new GiftCardTypeRepository();
        }
        
        public void AddGiftCardType(GiftCardType giftCardType)
        {
            giftCardTypeDAL.AddGiftCardType(giftCardType); //Call AddGiftCardType() method to add details
        }
        public void UpdateGiftCardType(GiftCardType giftCardType)
        {
            giftCardTypeDAL.UpdateGiftCardType(giftCardType);//Call UpdateGiftCardType() method to update giftcard types
        }
        public void DeleteGiftCardType(int giftCardTypeId)
        {
            giftCardTypeDAL.DeleteGiftCardType(giftCardTypeId); //Call DeleteGiftCardType() method to delete giftcard types
        }
        public GiftCardType GetGiftCardTypeById(int giftCardTypeId)
        {
            return giftCardTypeDAL.GetGiftCardTypeById(giftCardTypeId); //Call GetGiftCardTypeById() method to view giftcardtypes using id
        }
        public IEnumerable<GiftCardType> GetGiftCardTypes()
        {
            return giftCardTypeDAL.GetGiftCardTypes(); //View giftcardtypes 
        }
    }
}
