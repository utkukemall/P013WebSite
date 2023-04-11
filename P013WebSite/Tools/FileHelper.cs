namespace P013WebSite.Tools
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string klasorYolu = "/wwwroot/Img/")
        {
            string dosyaAdi = "";
            dosyaAdi = formFile.FileName;
            string dizin = Directory.GetCurrentDirectory(); // Uygulamamızın pc de çalıştığı yeri bize getiriyor
            dizin += klasorYolu + dosyaAdi; // Yükleme dizinine uygulama içindeki klasörü ve dosya adını da ekledik.
            using var stream = new FileStream(dizin, FileMode.Create);  // Pc den server a dosya yükleme için bir akış başlattık
            await formFile.CopyToAsync(stream); // IFormFile içerisinden gelen ve asenkron çalışan CopyToAsync metoduna dosya yükleme akışımızı gönderdik ve dosyayı sunucuya kopyaladık.

            return dosyaAdi; // Sunucuya yüklenen dosyanın adını geri döndürdük.
        }
    }
}
