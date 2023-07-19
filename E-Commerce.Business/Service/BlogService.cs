using E_Commerce.Business.Translators;
using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using E_Commerce.Entity.Concrete.ar;
using E_Commerce.Entity.Concrete.en;
using E_Commerce.Entity.Concrete.ru;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LanguageTranslator _translator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlogService(IUnitOfWork unitOfWork, LanguageTranslator translator, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _translator = translator;
            _httpContextAccessor = httpContextAccessor;
        }


        private int GenerateUniqueId()
        {

            int lastUsedId = _unitOfWork.Blogs.GetLastUsedId();
            if (lastUsedId == null)
            {
                lastUsedId = 10;
            }

            // Yeni bir benzersiz ID oluşturun
            int newId = lastUsedId + 1;

            return newId;
        }
        public void Create(Blog entity)
        {
            var translatedTitleEN = _translator.TranslateTextAsync("en", entity.Title!).Result;
            var translatedContentEN = _translator.TranslateTextAsync("en", entity.Content!).Result;
            var translatedCategoryEN = _translator.TranslateTextAsync("en", entity.BlogCategory!).Result;

            var translatedTitleAR = _translator.TranslateTextAsync("ar", entity.Title!).Result;
            var translatedContentAR = _translator.TranslateTextAsync("ar", entity.Content!).Result;
            var translatedCategoryAR = _translator.TranslateTextAsync("ar", entity.BlogCategory!).Result;

            var translatedTitleRU = _translator.TranslateTextAsync("ru", entity.Title!).Result;
            var translatedContentRU = _translator.TranslateTextAsync("ru", entity.Content!).Result;
            var translatedCategoryRU = _translator.TranslateTextAsync("ru", entity.BlogCategory!).Result;

            // Türkçe kategoriyi kaydedin ve otomatik olarak bir ID atayın
            entity.Id = GenerateUniqueId();
            // Türkçe blogu kaydedin
            _unitOfWork.Blogs.Add(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce blogu oluşturun ve kaydedin
            var blogEN = new BlogEN
            {
                Id = entity.Id,
                Title = translatedTitleEN,
                Content = translatedContentEN,
                BlogCategory = translatedCategoryEN,
                Image = entity.Image
            };
            _unitOfWork.BlogENs.Add(blogEN);
            _unitOfWork.CompleteAsync();

            // Arapça blogu oluşturun ve kaydedin
            var blogAR = new BlogAR
            {
                Id = entity.Id,
                Title = translatedTitleAR,
                Content = translatedContentAR,
                BlogCategory = translatedCategoryAR,
                Image = entity.Image
            };
            _unitOfWork.BlogARs.Add(blogAR);
            _unitOfWork.CompleteAsync();

            // Rusça blogu oluşturun ve kaydedin
            var blogRU = new BlogRU
            {
                Id = entity.Id,
                Title = translatedTitleRU,
                Content = translatedContentRU,
                BlogCategory = translatedCategoryRU,
                Image = entity.Image
            };
            _unitOfWork.BlogRUs.Add(blogRU);
            _unitOfWork.CompleteAsync();
        }


        public void Delete(int id)
        {
            var blog = _unitOfWork.Blogs.GetById(id);
            if (blog != null)
            {
                _unitOfWork.Blogs.Remove(blog);

                // Diğer dillerin modellerini de ilgili blog ID'sine göre silin
                var blogEN = _unitOfWork.BlogENs.GetById(id);
                if (blogEN != null)
                {
                    _unitOfWork.BlogENs.Remove(blogEN);
                }

                var blogAR = _unitOfWork.BlogARs.GetById(id);
                if (blogAR != null)
                {
                    _unitOfWork.BlogARs.Remove(blogAR);
                }

                var blogRU = _unitOfWork.BlogRUs.GetById(id);
                if (blogRU != null)
                {
                    _unitOfWork.BlogRUs.Remove(blogRU);
                }

                _unitOfWork.CompleteAsync();
            }
        }






        public IEnumerable<Blog> GetAll()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Çerezden seçilen dili al (örnekte "SelectedLanguage" adında bir çerez kullanıldığını varsayalım)
            var selectedLanguage = httpContext.Request.Cookies["SelectedLanguage"];

            // Seçilen dilin culture bilgisini al
            CultureInfo culture;

            if (string.IsNullOrEmpty(selectedLanguage))
            {
                // Seçilen dil yok, varsayılan dil olarak "en-US" kullan
                culture = CultureInfo.GetCultureInfo("tr-TR");
            }
            else
            {
                culture = CultureInfo.GetCultureInfo(selectedLanguage);
            }

            // Diğer işlemler...
            if (culture.Name == "en-US")
            {
                var ruBlogs = _unitOfWork.BlogENs.GetAll();
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ar-SA")
            {
                var ruBlogs = _unitOfWork.BlogARs.GetAll();
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruBlogs = _unitOfWork.BlogRUs.GetAll();
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }


            return _unitOfWork.Blogs.GetAll();
        }

        public IEnumerable<Blog> GetAllNormal()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Çerezden seçilen dili al (örnekte "SelectedLanguage" adında bir çerez kullanıldığını varsayalım)
            var selectedLanguage = httpContext.Request.Cookies["SelectedLanguage"];

            // Seçilen dilin culture bilgisini al
            CultureInfo culture;

            if (string.IsNullOrEmpty(selectedLanguage))
            {
                // Seçilen dil yok, varsayılan dil olarak "en-US" kullan
                culture = CultureInfo.GetCultureInfo("tr-TR");
            }
            else
            {
                culture = CultureInfo.GetCultureInfo(selectedLanguage);
            }

            // Diğer işlemler...
            if (culture.Name == "en-US")
            {
                var ruBlogs = _unitOfWork.BlogENs.GetAll();
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ar-SA")
            {
                var ruBlogs = _unitOfWork.BlogARs.GetAll();
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruBlogs = _unitOfWork.BlogRUs.GetAll();
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }


            return _unitOfWork.Blogs.GetAll();
        }

        public IEnumerable<Blog> GetLatestBlogToThree()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Çerezden seçilen dili al (örnekte "SelectedLanguage" adında bir çerez kullanıldığını varsayalım)
            var selectedLanguage = httpContext.Request.Cookies["SelectedLanguage"];

            // Seçilen dilin culture bilgisini al
            CultureInfo culture;

            if (string.IsNullOrEmpty(selectedLanguage))
            {
                // Seçilen dil yok, varsayılan dil olarak "en-US" kullan
                culture = CultureInfo.GetCultureInfo("tr-TR");
            }
            else
            {
                culture = CultureInfo.GetCultureInfo(selectedLanguage);
            }

            // Diğer işlemler...
            if (culture.Name == "en-US")
            {
                var ruBlogs = _unitOfWork.BlogENs.GetAll().Take(3);
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ar-SA")
            {
                var ruBlogs = _unitOfWork.BlogARs.GetAll().Take(3);
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruBlogs = _unitOfWork.BlogRUs.GetAll().Take(3);
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }


            return _unitOfWork.Blogs.GetAll().Take(3);
        }

        public Blog GetById(int id)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Çerezden seçilen dili al (örnekte "SelectedLanguage" adında bir çerez kullanıldığını varsayalım)
            var selectedLanguage = httpContext.Request.Cookies["SelectedLanguage"];

            // Seçilen dilin culture bilgisini al
            CultureInfo culture;

            if (string.IsNullOrEmpty(selectedLanguage))
            {
                // Seçilen dil yok, varsayılan dil olarak "en-US" kullan
                culture = CultureInfo.GetCultureInfo("tr-TR");
            }
            else
            {
                culture = CultureInfo.GetCultureInfo(selectedLanguage);
            }

            // Diğer işlemler...
            if (culture.Name == "en-US")
            {
                var ruBlogs = _unitOfWork.BlogENs.GetById(id);
                var blogs = new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                };

                return blogs;
            }
            else if (culture.Name == "ar-SA")
            {
                var ruBlogs = _unitOfWork.BlogARs.GetById(id);
                var blogs = new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                };

                return blogs;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruBlogs = _unitOfWork.BlogRUs.GetById(id);
                var blogs = new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                };

                return blogs;
            }



            var blog = _unitOfWork.Blogs.GetById(id);
            return blog!;
        }

        public IEnumerable<Blog> GetByIdList(int id)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Çerezden seçilen dili al (örnekte "SelectedLanguage" adında bir çerez kullanıldığını varsayalım)
            var selectedLanguage = httpContext.Request.Cookies["SelectedLanguage"];

            // Seçilen dilin culture bilgisini al
            CultureInfo culture;

            if (string.IsNullOrEmpty(selectedLanguage))
            {
                // Seçilen dil yok, varsayılan dil olarak "en-US" kullan
                culture = CultureInfo.GetCultureInfo("tr-TR");
            }
            else
            {
                culture = CultureInfo.GetCultureInfo(selectedLanguage);
            }

            // Diğer işlemler...
            if (culture.Name == "en-US")
            {
                var ruBlogs = _unitOfWork.BlogENs.List(x => x.Id == id);
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ar-SA")
            {
                var ruBlogs = _unitOfWork.BlogARs.List(x => x.Id == id);
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruBlogs = _unitOfWork.BlogRUs.List(x => x.Id == id);
                var blogs = ruBlogs.Select(ruBlogs => new Blog
                {
                    Id = ruBlogs.Id,
                    Title = ruBlogs.Title,
                    Content = ruBlogs.Content,
                    Image = ruBlogs.Image,
                    BlogCategory = ruBlogs.BlogCategory,
                });

                return blogs;
            }


            var blog = _unitOfWork.Blogs.List(x => x.Id == id);
            return blog!;
        }





        public void Update(Blog entity)
        {
            var translatedTitleEN = _translator.TranslateTextAsync("en", entity.Title!).Result;
            var translatedContentEN = _translator.TranslateTextAsync("en", entity.Content!).Result;
            var translatedCategoryEN = _translator.TranslateTextAsync("en", entity.BlogCategory!).Result;

            var translatedTitleAR = _translator.TranslateTextAsync("ar", entity.Title!).Result;
            var translatedContentAR = _translator.TranslateTextAsync("ar", entity.Content!).Result;
            var translatedCategoryAR = _translator.TranslateTextAsync("ar", entity.BlogCategory!).Result;

            var translatedTitleRU = _translator.TranslateTextAsync("ru", entity.Title!).Result;
            var translatedContentRU = _translator.TranslateTextAsync("ru", entity.Content!).Result;
            var translatedCategoryRU = _translator.TranslateTextAsync("ru", entity.BlogCategory!).Result;

            // Türkçe blogu kaydedin
            _unitOfWork.Blogs.Update(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce blogu oluşturun ve kaydedin
            var blogEN = new BlogEN
            {
                Id = entity.Id,
                Title = translatedTitleEN,
                Content = translatedContentEN,
                BlogCategory = translatedCategoryEN,
                Image = entity.Image
            };
            _unitOfWork.BlogENs.Update(blogEN);
            _unitOfWork.CompleteAsync();

            // Arapça blogu oluşturun ve kaydedin
            var blogAR = new BlogAR
            {
                Id = entity.Id,
                Title = translatedTitleAR,
                Content = translatedContentAR,
                BlogCategory = translatedCategoryAR,
                Image = entity.Image
            };
            _unitOfWork.BlogARs.Update(blogAR);
            _unitOfWork.CompleteAsync();

            // Rusça blogu oluşturun ve kaydedin
            var blogRU = new BlogRU
            {
                Id = entity.Id,
                Title = translatedTitleRU,
                Content = translatedContentRU,
                BlogCategory = translatedCategoryRU,
                Image = entity.Image
            };
            _unitOfWork.BlogRUs.Update(blogRU);
            _unitOfWork.CompleteAsync();
        }

        public List<string> GetBlogCategoryList()
        {
            var blogList = _unitOfWork.Blogs.GetAll();
            var categoryList = blogList.Select(blog => blog.BlogCategory).Distinct().ToList();

            return categoryList;
        }

    }
}
