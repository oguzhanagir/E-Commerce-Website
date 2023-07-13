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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LanguageTranslator _translator;


        public SubCategoryService(IUnitOfWork unitOfWork, LanguageTranslator translator, IHttpContextAccessor httpContextAccessor)
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


        public void Create(SubCategory entity)
        {
            var translatedNameEN = _translator.TranslateTextAsync("en", entity.Name!).Result;
            var translatedNameAR = _translator.TranslateTextAsync("ar", entity.Name!).Result;
            var translatedNameRU = _translator.TranslateTextAsync("ru", entity.Name!).Result;

            // Türkçe kategoriyi kaydedin ve otomatik olarak bir ID atayın
            entity.Id = GenerateUniqueId();
            _unitOfWork.SubCategories.Add(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce kategoriyi oluşturun ve Türkçe kategorinin ID'sini atayın
            var categoryEN = new SubCategoryEN
            {
                Id = entity.Id,
                Name = translatedNameEN,
                Product = entity.Product,
                CategoryId = entity.CategoryId,
                

            };
            _unitOfWork.SubCategoryENs.Add(categoryEN);
            _unitOfWork.CompleteAsync();

            // Arapça kategoriyi oluşturun ve Türkçe kategorinin ID'sini atayın
            var categoryAR = new SubCategoryAR
            {
                Id = entity.Id,
                Name = translatedNameAR,
                Product = entity.Product,
                CategoryId = entity.CategoryId,
            
            };
            _unitOfWork.SubCategoryARs.Add(categoryAR);
            _unitOfWork.CompleteAsync();

            // Rusça kategoriyi oluşturun ve Türkçe kategorinin ID'sini atayın
            var categoryRU = new SubCategoryRU
            {
                Id = entity.Id,
                Name = translatedNameRU,
                Product = entity.Product,
                CategoryId = entity.CategoryId,

            };
            _unitOfWork.SubCategoryRUs.Add(categoryRU);
            _unitOfWork.CompleteAsync();


        }



        public void Delete(int id)
        {
            var subCategory = _unitOfWork.SubCategories.GetById(id);
            if (subCategory != null)
            {
                // Türkçe kategoriyi silin
                _unitOfWork.SubCategories.Remove(subCategory);

                // Diğer dillerin modellerini de ilgili kategori ID'sine göre silin
                var categoryEN = _unitOfWork.SubCategoryENs.GetById(id);
                if (categoryEN != null)
                {
                    _unitOfWork.SubCategoryENs.Remove(categoryEN);
                }

                var categoryAR = _unitOfWork.SubCategoryARs.GetById(id);
                if (categoryAR != null)
                {
                    _unitOfWork.SubCategoryARs.Remove(categoryAR);
                }

                var categoryRU = _unitOfWork.SubCategoryRUs.GetById(id);
                if (categoryRU != null)
                {
                    _unitOfWork.SubCategoryRUs.Remove(categoryRU);
                }

                _unitOfWork.CompleteAsync();
            }
        }






        public IEnumerable<SubCategory> GetAll()
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
                var enCategories = _unitOfWork.SubCategoryENs.GetAll();
                var categories = enCategories.Select(enCategory => new SubCategory
                {
                    Id = enCategory.Id,
                    Name = enCategory.Name,
          
                    Product = enCategory.Product,
                    CategoryId = enCategory.CategoryId,
                });

                return categories;
            }
            else if (culture.Name == "ar-SA")
            {
                var arCategories = _unitOfWork.SubCategoryARs.GetAll();
                var categories = arCategories.Select(arCategory => new SubCategory
                {
                    Id = arCategory.Id,
                    Name = arCategory.Name,

                    Product = arCategory.Product,
                    CategoryId = arCategory.CategoryId,
                });

                return categories;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruCategories = _unitOfWork.SubCategoryRUs.GetAll();
                var categories = ruCategories.Select(ruCategory => new SubCategory
                {
                    Id = ruCategory.Id,
                    Name = ruCategory.Name,

                    Product = ruCategory.Product,
                    CategoryId = ruCategory.CategoryId,
                });

                return categories;
            }


            return  _unitOfWork.SubCategories.GetAll();
        }

        public IEnumerable<SubCategory> GetAllNormal()
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
                var enCategories = _unitOfWork.SubCategoryENs.GetAll(x => x.Category!);
                var categories = enCategories.Select(enCategory => new SubCategory
                {
                    Id = enCategory.Id,
                    Name = enCategory.Name,

                    Product = enCategory.Product,
                    CategoryId = enCategory.CategoryId,
                });

                return categories;
            }
            else if (culture.Name == "ar-SA")
            {
                var arCategories = _unitOfWork.SubCategoryARs.GetAll(x => x.Category!);
                var categories = arCategories.Select(arCategory => new SubCategory
                {
                    Id = arCategory.Id,
                    Name = arCategory.Name,

                    Product = arCategory.Product,
                    CategoryId = arCategory.CategoryId,
                });

                return categories;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruCategories = _unitOfWork.SubCategoryRUs.GetAll(x => x.Category!);
                var categories = ruCategories.Select(ruCategory => new SubCategory
                {
                    Id = ruCategory.Id,
                    Name = ruCategory.Name,

                    Product = ruCategory.Product,
                    CategoryId = ruCategory.CategoryId,
                });

                return categories;
            }


            return _unitOfWork.SubCategories.GetAll(x=>x.Category!);
        }

        public SubCategory GetById(int id)
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
                var enCategories = _unitOfWork.SubCategoryENs.GetById(id);
                var categories =  new SubCategory
                {
                    Id = enCategories.Id,
                    Name = enCategories.Name,

                    Product = enCategories.Product,
                    CategoryId = enCategories.CategoryId,
                };

                return categories;
            }
            else if (culture.Name == "ar-SA")
            {
                var arCategories = _unitOfWork.SubCategoryARs.GetById(id);
                var categories =new SubCategory
                {
                    Id = arCategories.Id,
                    Name = arCategories.Name,

                    Product = arCategories.Product,
                    CategoryId = arCategories.CategoryId,
                };

                return categories;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruCategories = _unitOfWork.SubCategoryRUs.GetById(id);
                var categories =  new SubCategory
                {
                    Id = ruCategories.Id,
                    Name = ruCategories.Name,

                    Product = ruCategories.Product,
                    CategoryId = ruCategories.CategoryId,
                    
                };

                return categories;
            }


            return _unitOfWork.SubCategories.GetById(id);
        }




        public void Update(SubCategory entity)
        {
            var translatedNameEN = _translator.TranslateTextAsync("en", entity.Name!).Result;
            var translatedNameAR = _translator.TranslateTextAsync("ar", entity.Name!).Result;
            var translatedNameRU = _translator.TranslateTextAsync("ru", entity.Name!).Result;

            // Türkçe kategoriyi kaydedin
            _unitOfWork.SubCategories.Update(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce kategoriyi oluşturun ve kaydedin
            var categoryEN = new SubCategoryEN
            {
                Id = entity.Id,
                Name = translatedNameEN,
                Product = entity.Product,
                CategoryId = entity.CategoryId,
            };
            _unitOfWork.SubCategoryENs.Update(categoryEN);
            _unitOfWork.CompleteAsync();

            // Arapça kategoriyi oluşturun ve kaydedin
            var categoryAR = new SubCategoryAR
            {
                Id = entity.Id,
                Name = translatedNameAR,
                Product = entity.Product,
                CategoryId = entity.CategoryId,
            };
            _unitOfWork.SubCategoryARs.Update(categoryAR);
            _unitOfWork.CompleteAsync();

            // Rusça kategoriyi oluşturun ve kaydedin
            var categoryRU = new SubCategoryRU
            {
                Id = entity.Id,
                Name = translatedNameRU,
                Product = entity.Product,
                CategoryId = entity.CategoryId,
            };
            _unitOfWork.SubCategoryRUs.Update(categoryRU);
            _unitOfWork.CompleteAsync();

        }
    }

}
