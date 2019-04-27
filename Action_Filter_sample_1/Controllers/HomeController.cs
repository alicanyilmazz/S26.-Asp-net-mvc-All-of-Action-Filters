using Action_Filter_sample_1.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Action_Filter_sample_1.Controllers
{
    [ActFilter, ResFilter, AuthFilter,ExcFilter]
    public class HomeController : Controller
    {
        // GET: Home
        //[ActFilter, ResFilter, AuthFilter]   //Butun hepsine bu Attribute 'ları yazmak yerine direkt Controllerin üstüne yazarsan tüm Action'larda gecerli olur otomatik olarak.
        public ActionResult Index()
        {
            return View();
        }

        //[ActFilter, ResFilter, AuthFilter] // Bazi Action'larda olmasını istedğiniz Attribute 'ları ise direkt Action ın basına yazarsanız sadece o Action 'larda o Attribute gecerli olur.
        public ActionResult Index2()
        {
            object sayi = 0;              //yapay hata olusturduk
            int değer = 100 / (int)sayi;  //yapay hata olusturduk (DivideByZero) hatası olusturduk.

            // throw new Exception("user authorisation is not valid."); sekliden sizde Exception yazabilirsiniz ama bunlar StackTrace olusturmadıgından ekrana basamayacaz o yuzden elle hata olusturduk üst kısımda.

            return View();
        }

        //[ActFilter, ResFilter, AuthFilter]
        public ActionResult Index3()
        {
            return View();
        }
    }
}

//NOT: DivideByZero hatasını normalde Server da canlıya atınca direkt yazdıgımız ExcFilter yakalar ve ekrana ilgili bilgiler basılır fakat geliştirme asamasında 
// ExcFilter dan önce hatayı VisualStudio yakalar ve bu hatayı yakalamasından sonra Debug modda Continue tusuna basarak hatanın kod çalışması devam ettirilerek
// ExcFilter tarafından yakanlanmasını sagladık zaten Debug yapmasak direkt Visual Studio hata verdirir.(Kısaca Debug + Continue )