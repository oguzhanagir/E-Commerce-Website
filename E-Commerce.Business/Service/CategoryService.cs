using E_Commerce.Business.Translators;
using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using E_Commerce.Entity.Concrete.ar;
using E_Commerce.Entity.Concrete.en;
using E_Commerce.Entity.Concrete.ru;
using GTranslate.Translators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LanguageTranslator _translator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(IUnitOfWork unitOfWork, LanguageTranslator translator, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _translator = translator;
            _httpContextAccessor = httpContextAccessor;
        }
        private int GenerateUniqueId()
        {

            int lastUsedId = _unitOfWork.Categories.GetLastUsedId();
            if (lastUsedId == null)
            {
                lastUsedId = 5;
            }

            // Yeni bir benzersiz ID oluşturun
            int newId = lastUsedId + 1;

            return newId;
        }

        public void Create(Category entity)
        {
            var translatedNameEN = _translator.TranslateTextAsync("en", entity.Name!).Result;
            var translatedNameAR = _translator.TranslateTextAsync("ar", entity.Name!).Result;
            var translatedNameRU = _translator.TranslateTextAsync("ru", entity.Name!).Result;

            // Türkçe kategoriyi kaydedin ve otomatik olarak bir ID atayın
            entity.Id = GenerateUniqueId();
            _unitOfWork.Categories.Add(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce kategoriyi oluşturun ve Türkçe kategorinin ID'sini atayın
            var categoryEN = new CategoryEN
            {
                Id = entity.Id,
                Name = translatedNameEN,
                Image = entity.Image,
                Products = entity.Products,
                SubCategories = (ICollection<SubCategoryEN>)entity.SubCategories
                
            };
            _unitOfWork.CategoryENs.Add(categoryEN);
            _unitOfWork.CompleteAsync();

            // Arapça kategoriyi oluşturun ve Türkçe kategorinin ID'sini atayın
            var categoryAR = new CategoryAR
            {
                Id = entity.Id,
                Name = translatedNameAR,
                Image = entity.Image,
                Products = entity.Products,
                SubCategories = (ICollection<SubCategoryAR>)entity.SubCategories
            };
            _unitOfWork.CategoryARs.Add(categoryAR);
            _unitOfWork.CompleteAsync();

            // Rusça kategoriyi oluşturun ve Türkçe kategorinin ID'sini atayın
            var categoryRU = new CategoryRU
            {
                Id = entity.Id,
                Name = translatedNameRU,
                Image = entity.Image,
                Products = entity.Products,
                SubCategories = (ICollection<SubCategoryRU>)entity.SubCategories
            };
            _unitOfWork.CategoryRUs.Add(categoryRU);
            _unitOfWork.CompleteAsync();
        }


        public void Delete(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category != null)
            {
                // Türkçe kategoriyi silin
                _unitOfWork.Categories.Remove(category);

                // Diğer dillerin modellerini de ilgili kategori ID'sine göre silin
                var categoryEN = _unitOfWork.CategoryENs.GetById(id);
                if (categoryEN != null)
                {
                    _unitOfWork.CategoryENs.Remove(categoryEN);
                }

                var categoryAR = _unitOfWork.CategoryARs.GetById(id);
                if (categoryAR != null)
                {
                    _unitOfWork.CategoryARs.Remove(categoryAR);
                }

                var categoryRU = _unitOfWork.CategoryRUs.GetById(id);
                if (categoryRU != null)
                {
                    _unitOfWork.CategoryRUs.Remove(categoryRU);
                }

                _unitOfWork.CompleteAsync();
            }
        }



        public IEnumerable<Category> GetAll()
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
                var enCategories = _unitOfWork.CategoryENs.GetAll(x => x.SubCategories!);
                var categories = enCategories.Select(enCategory => new Category
                {
                    Id = enCategory.Id,
                    Name = enCategory.Name,
                    Products = enCategory.Products,
                    SubCategories = (ICollection<SubCategory>)enCategory.SubCategories
                });

                return categories;
            }
            else if (culture.Name == "ar-SA")
            {
                var arCategories = _unitOfWork.CategoryARs.GetAll(x => x.SubCategories!);
                var categories = arCategories.Select(arCategory => new Category
                {
                    Id = arCategory.Id,
                    Name = arCategory.Name,
                    Products = arCategory.Products,
                    SubCategories = (ICollection<SubCategory>)arCategory.SubCategories
                });

                return categories;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruCategories = _unitOfWork.CategoryRUs.GetAll(x => x.SubCategories!);
                var categories = ruCategories.Select(ruCategory => new Category
                {
                    Id = ruCategory.Id,
                    Name = ruCategory.Name,
                    Products = ruCategory.Products,
                    SubCategories = (ICollection<SubCategory>)ruCategory.SubCategories
                });

                return categories;
            }


            return _unitOfWork.Categories.GetAll(x => x.SubCategories!);
        }

        public IEnumerable<Category> GetAllNormal()
        {
            var httpContext = _httpContextAccessor.HttpContext;

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
                var enCategories = _unitOfWork.CategoryENs.GetAll(x => x.SubCategories);
                var categories = enCategories.Select(enCategory => new Category
                {
                    Id = enCategory.Id,
                    Name = enCategory.Name,
                    Products = enCategory.Products,
                    SubCategories = enCategory.SubCategories!.Select(enSubCategory => new SubCategory
                    {
                        Id = enSubCategory.Id,
                        Name = enSubCategory.Name,
                        // Diğer özellikleri de buraya ekleyin
                    }).ToList()
                });

                return categories;
            }

            else if (culture.Name == "ar-SA")
            {
                var arCategories = _unitOfWork.CategoryARs.GetAll(x => x.SubCategories);
                var categories = arCategories.Select(arCategory => new Category
                {
                    Id = arCategory.Id,
                    Name = arCategory.Name,
                    Products = arCategory.Products,
                    SubCategories = arCategory.SubCategories.Select(arSubCategory => new SubCategory
                    {
                        Id = arSubCategory.Id,
                        Name = arSubCategory.Name,
                        // Diğer özellikleri de buraya ekleyin
                    }).ToList()
                });

                return categories;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruCategories = _unitOfWork.CategoryRUs.GetAll(x => x.SubCategories);
                var categories = ruCategories.Select(ruCategory => new Category
                {
                    Id = ruCategory.Id,
                    Name = ruCategory.Name,
                    Products = ruCategory.Products,
                    SubCategories = ruCategory.SubCategories.Select(ruSubCategory => new SubCategory
                    {
                        Id = ruSubCategory.Id,
                        Name = ruSubCategory.Name,
                        // Diğer özellikleri de buraya ekleyin
                    }).ToList()
                });

                return categories;
            }



            return _unitOfWork.Categories.GetAll(x => x.SubCategories!);
        }

        public IEnumerable<Category> GetAllNormalWithFive()
        {
            var httpContext = _httpContextAccessor.HttpContext;

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
                var enCategories = _unitOfWork.CategoryENs.GetAll(x => x.SubCategories).Take(5);
                var categories = enCategories.Select(enCategory => new Category
                {
                    Id = enCategory.Id,
                    Name = enCategory.Name,
                    Products = enCategory.Products,
                    SubCategories = enCategory.SubCategories!.Select(enSubCategory => new SubCategory
                    {
                        Id = enSubCategory.Id,
                        Name = enSubCategory.Name,
                        // Diğer özellikleri de buraya ekleyin
                    }).ToList()
                });

                return categories;
            }

            else if (culture.Name == "ar-SA")
            {
                var arCategories = _unitOfWork.CategoryARs.GetAll(x => x.SubCategories).Take(5);
                var categories = arCategories.Select(arCategory => new Category
                {
                    Id = arCategory.Id,
                    Name = arCategory.Name,
                    Products = arCategory.Products,
                    SubCategories = arCategory.SubCategories.Select(arSubCategory => new SubCategory
                    {
                        Id = arSubCategory.Id,
                        Name = arSubCategory.Name,
                        // Diğer özellikleri de buraya ekleyin
                    }).ToList()
                });

                return categories;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruCategories = _unitOfWork.CategoryRUs.GetAll(x => x.SubCategories).Take(5);
                var categories = ruCategories.Select(ruCategory => new Category
                {
                    Id = ruCategory.Id,
                    Name = ruCategory.Name,
                    Products = ruCategory.Products,
                    SubCategories = ruCategory.SubCategories.Select(ruSubCategory => new SubCategory
                    {
                        Id = ruSubCategory.Id,
                        Name = ruSubCategory.Name,
                        // Diğer özellikleri de buraya ekleyin
                    }).ToList()
                });

                return categories;
            }



            return _unitOfWork.Categories.GetAll(x => x.SubCategories!).Take(5);
        }

        public Task<int> GetProductCountWithCategory(int id)
        {
            var countProduct = _unitOfWork.Products.GetCountByCategoryId(id);
            return countProduct;
        }

        public Category GetById(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public void Update(Category entity)
        {
            var translatedNameEN = _translator.TranslateTextAsync("en", entity.Name!).Result;
            var translatedNameAR = _translator.TranslateTextAsync("ar", entity.Name!).Result;
            var translatedNameRU = _translator.TranslateTextAsync("ru", entity.Name!).Result;

            // Türkçe kategoriyi kaydedin
            _unitOfWork.Categories.Update(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce kategoriyi oluşturun ve kaydedin
            var categoryEN = new CategoryEN
            {
                Id = entity.Id,
                Name = translatedNameEN,
                Image = entity.Image,
                Products = entity.Products,
                SubCategories = (ICollection<SubCategoryEN>)entity.SubCategories
            };
            _unitOfWork.CategoryENs.Update(categoryEN);
            _unitOfWork.CompleteAsync();

            // Arapça kategoriyi oluşturun ve kaydedin
            var categoryAR = new CategoryAR
            {
                Id = entity.Id,
                Name = translatedNameAR,
                Image = entity.Image,
                Products = entity.Products,
                SubCategories = (ICollection<SubCategoryAR>)entity.SubCategories
            };
            _unitOfWork.CategoryARs.Update(categoryAR);
            _unitOfWork.CompleteAsync();

            // Rusça kategoriyi oluşturun ve kaydedin
            var categoryRU = new CategoryRU
            {
                Id = entity.Id,
                Name = translatedNameRU,
                Image = entity.Image,
                Products = entity.Products,
                SubCategories = (ICollection<SubCategoryRU>)entity.SubCategories
            };
            _unitOfWork.CategoryRUs.Update(categoryRU);
            _unitOfWork.CompleteAsync();
        }
    
    
    }

}
