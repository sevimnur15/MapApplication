//using BasarsoftFirst.Home;
//using System.Security.Cryptography;
//using System.Xml.Linq;
//using BasarsoftFirst.Service;
//using BasarsoftFirst.congrate;
//using BasarsoftFirst.data;

//public class ItemDbService<T> : IItemManager<Items> where T : class
//{
//    private readonly ItemDb _context;

//    public ItemDbService(ItemDb context)
//    {
//        _context = context;
//    }

//    // İlgili metotları implement edin
//    public Response GetAll()
//    {
//        // Örnek implementasyon
//        return new Response(_context.Items.ToList(), true, "Tüm veriler başarıyla alındı.");
//    }

//    public Response GetById(int id)
//    {
//        var item = _context.Items.Find(id);
//        if (item == null)
//        {
//            return new Response(null, false, "Item bulunamadı.");
//        }
//        return new Response(item, true, "Item başarıyla alındı.");
//    }

//    public Response Add(Items entity)
//    {
//        _context.Items.Add(entity);
//        var result = _context.SaveChanges();
//        if (result > 0)
//        {
//            return new Response(entity, true, "Item başarıyla eklendi.");
//        }
//        return new Response(null, false, "Item eklenemedi.");
//    }

//    public Response Update(Items entity)
//    {
//        _context.Items.Update(entity);
//        var result = _context.SaveChanges();
//        if (result > 0)
//        {
//            return new Response(entity, true, "Item başarıyla güncellendi.");
//        }
//        return new Response(null, false, "Item güncellenemedi.");
//    }

//    public Response Delete(int id)
//    {
//        var item = _context.Items.Find(id);
//        if (item == null)
//        {
//            return new Response(null, false, "Item bulunamadı.");
//        }

//        _context.Items.Remove(item);
//        var result = _context.SaveChanges();
//        if (result > 0)
//        {
//            return new Response(null, true, "Item başarıyla silindi.");
//        }
//        return new Response(null, false, "Item silinemedi.");
//    }
//}
