using BasarsoftFirst.congrate;
using BasarsoftFirst.Service;

//IUnitOfWork arayüzü ve UnitOfWork sınıfı, veri erişim katmanında işlemlerin bir
//bütün olarak ele alınmasını sağlayan bir yapı sunar. UnitOfWork deseni,
//birden fazla repository ile çalışırken işlemleri tek bir yerde yönetmek için kullanılır.

namespace BasarsoftFirst.Service
{
    public interface IUnitOfWork : IDisposable //çöp toplayıcı
    {
        IRepository<Item> Repository { get; }
        // Diğer repository'ler için de özellikler eklenebilir.

        int Complete(); // Değişiklikleri kaydetmek için
    }
}

