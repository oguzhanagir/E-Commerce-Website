using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace E_Commerce.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BlogSingle(int id)
        {

            var blog = _blogService.GetByIdList(id);
            foreach (var item in blog)
            {
                ViewBag.MinRead = CalculateReadingTime(item.Content!);

                var topWords = GetTopWords(item.Content!, 5);
                ViewBag.TopWords = topWords;
            }
            return View(blog);
        }


        public List<string> GetTopWords(string content, int count)
        {
            // Özel karakterleri, noktalama işaretlerini ve boşlukları temizleyin
            var cleanContent = Regex.Replace(content, @"[\W_]+", " ");

            // Tüm kelimeleri küçük harflere dönüştürün
            var words = cleanContent.ToLower().Split(' ');

            // Her kelimenin sayısını tutacak bir sözlük (dictionary) oluşturun
            var wordCounts = new Dictionary<string, int>();

            // Her kelimeyi döngü ile işleyin ve sözlüğe ekleyin veya sayısını artırın
            foreach (var word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
            }

            // Sözlüğü kelime sayısına göre azalan şekilde sıralayın
            var sortedWords = wordCounts.OrderByDescending(x => x.Value);

            // İstenen sayıda en çok geçen kelimeleri alın
            var topWords = sortedWords.Where(x => !string.IsNullOrEmpty(x.Key)).Take(count).Select(x => x.Key).ToList();

            return topWords;
        }


        private static int CalculateReadingTime(string content)
        {
            int wordsPerMinute = 200; // Ortalama kelime hızı
            int totalWords = content.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int readingTimeInMinutes = totalWords / wordsPerMinute;
            return readingTimeInMinutes;
        }
        public IActionResult BlogAdminList()
        {
            var blogList = _blogService.GetAll();
            return View(blogList);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog, IFormFile file)
        {
            if (blog != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/blog/" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    blog.Image = filePath;
                }
                _blogService.Create(blog);
            }

            return RedirectToAction("BlogAdminList", "Blog");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.GetById(id);
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog, IFormFile file)
        {
            if (blog != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/blog/" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    blog.Image = filePath;
                }
                _blogService.Update(blog);
            }

            return RedirectToAction("BlogAdminList", "Blog");
        }

        public IActionResult DeleteBlog(int id)
        {
            _blogService.Delete(id);
            return RedirectToAction("BlogAdminList", "Blog");
        }


    }
}
