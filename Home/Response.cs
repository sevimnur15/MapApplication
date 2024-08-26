using BasarsoftFirst.congrate;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BasarsoftFirst.Service;

namespace BasarsoftFirst.Home

{
    public class Response
    {
        public object Data { get; set; } // İlgili veri
        public bool Success { get; set; }  // İşlem başarılı mı
        public string Message { get; set; } // Hata mesajı veya bilgi mesajı

          
    }
}
