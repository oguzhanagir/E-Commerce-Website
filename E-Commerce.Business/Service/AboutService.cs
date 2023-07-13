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
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LanguageTranslator _translator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AboutService(IUnitOfWork unitOfWork, LanguageTranslator translator, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _translator = translator;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Create(About entity)
        {
            var translatedTitleEN = _translator.TranslateTextAsync("en", entity.Title!).Result;
            var translatedContentEN = _translator.TranslateTextAsync("en", entity.Content!).Result;

            var translatedTitleAR = _translator.TranslateTextAsync("ar", entity.Title!).Result;
            var translatedContentAR = _translator.TranslateTextAsync("ar", entity.Content!).Result;

            var translatedTitleRU = _translator.TranslateTextAsync("ru", entity.Title!).Result;
            var translatedContentRU = _translator.TranslateTextAsync("ru", entity.Content!).Result;

            // Türkçe about kaydedin
            _unitOfWork.Abouts.Add(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce about oluşturun ve kaydedin
            var aboutEN = new AboutEN
            {
                Title = translatedTitleEN,
                Content = translatedContentEN,
                ImagePath = entity.ImagePath,
                CompanyMail = entity.CompanyMail,
                CompanyAddress = entity.CompanyAddress,
                CompanyPhoneNumber = entity.CompanyPhoneNumber

            };
            _unitOfWork.AboutENs.Add(aboutEN);
            _unitOfWork.CompleteAsync();

            // Arapça about oluşturun ve kaydedin
            var aboutAR = new AboutAR
            {
                Title = translatedTitleAR,
                Content = translatedContentAR,
                ImagePath = entity.ImagePath,
                CompanyMail = entity.CompanyMail,
                CompanyAddress = entity.CompanyAddress,
                CompanyPhoneNumber = entity.CompanyPhoneNumber
            };
            _unitOfWork.AboutARs.Add(aboutAR);
            _unitOfWork.CompleteAsync();

            // Rusça about oluşturun ve kaydedin
            var aboutRU = new AboutRU
            {
                Title = translatedTitleRU,
                Content = translatedContentRU,
                ImagePath = entity.ImagePath,
                CompanyMail = entity.CompanyMail,
                CompanyAddress = entity.CompanyAddress,
                CompanyPhoneNumber = entity.CompanyPhoneNumber
            };
            _unitOfWork.AboutRUs.Add(aboutRU);
            _unitOfWork.CompleteAsync();
        }


        public void Delete(int id)
        {
            var about = _unitOfWork.Abouts.GetById(id);
            if (about != null)
            {
                _unitOfWork.Abouts.Remove(about);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<About> GetAll()
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
                var ruAbouts = _unitOfWork.AboutENs.GetAll();
                var abouts = ruAbouts.Select(ruAbouts => new About
                {
                    Id = ruAbouts.Id,
                    Title = ruAbouts.Title,
                    Content = ruAbouts.Content,
                    CompanyAddress = ruAbouts.CompanyAddress,
                    CompanyMail = ruAbouts.CompanyMail,
                    CompanyPhoneNumber = ruAbouts.CompanyPhoneNumber,
                    ImagePath = ruAbouts.ImagePath,

                });

                return abouts;
            }
            else if (culture.Name == "ar-SA")
            {
                var ruAbouts = _unitOfWork.AboutARs.GetAll();
                var abouts = ruAbouts.Select(ruAbouts => new About
                {
                    Id = ruAbouts.Id,
                    Title = ruAbouts.Title,
                    Content = ruAbouts.Content,
                    CompanyAddress = ruAbouts.CompanyAddress,
                    CompanyMail = ruAbouts.CompanyMail,
                    CompanyPhoneNumber = ruAbouts.CompanyPhoneNumber,
                    ImagePath = ruAbouts.ImagePath,

                });

                return abouts;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruAbouts = _unitOfWork.AboutRUs.GetAll();
                var abouts = ruAbouts.Select(ruAbouts => new About
                {
                    Id = ruAbouts.Id,
                    Title = ruAbouts.Title,
                    Content = ruAbouts.Content,
                    CompanyAddress = ruAbouts.CompanyAddress,
                    CompanyMail = ruAbouts.CompanyMail,
                    CompanyPhoneNumber = ruAbouts.CompanyPhoneNumber,
                    ImagePath = ruAbouts.ImagePath,

                });

                return abouts;
            }


            return _unitOfWork.Abouts.GetAll();
        }

        public About GetById(int id)
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
                var ruAbouts = _unitOfWork.AboutENs.GetById(id);
                var abouts = new About
                {
                    Id = ruAbouts.Id,
                    Title = ruAbouts.Title,
                    Content = ruAbouts.Content,
                    CompanyAddress = ruAbouts.CompanyAddress,
                    CompanyMail = ruAbouts.CompanyMail,
                    CompanyPhoneNumber = ruAbouts.CompanyPhoneNumber,
                    ImagePath = ruAbouts.ImagePath,

                };

                return abouts;
            }
            else if (culture.Name == "ar-SA")
            {
                var ruAbouts = _unitOfWork.AboutARs.GetById(id);
                var abouts = new About
                {
                    Id = ruAbouts.Id,
                    Title = ruAbouts.Title,
                    Content = ruAbouts.Content,
                    CompanyAddress = ruAbouts.CompanyAddress,
                    CompanyMail = ruAbouts.CompanyMail,
                    CompanyPhoneNumber = ruAbouts.CompanyPhoneNumber,
                    ImagePath = ruAbouts.ImagePath,

                };

                return abouts;
            }
            else if (culture.Name == "ru-RU")
            {
                var ruAbouts = _unitOfWork.AboutRUs.GetById(id);
                var abouts = new About
                {
                    Id = ruAbouts.Id,
                    Title = ruAbouts.Title,
                    Content = ruAbouts.Content,
                    CompanyAddress = ruAbouts.CompanyAddress,
                    CompanyMail = ruAbouts.CompanyMail,
                    CompanyPhoneNumber = ruAbouts.CompanyPhoneNumber,
                    ImagePath = ruAbouts.ImagePath,

                };

                return abouts;
            }


            return _unitOfWork.Abouts.GetById(id);

        }
        public void Update(About entity)
        {
            var translatedTitleEN = _translator.TranslateTextAsync("en", entity.Title!).Result;
            var translatedContentEN = _translator.TranslateTextAsync("en", entity.Content!).Result;

            var translatedTitleAR = _translator.TranslateTextAsync("ar", entity.Title!).Result;
            var translatedContentAR = _translator.TranslateTextAsync("ar", entity.Content!).Result;

            var translatedTitleRU = _translator.TranslateTextAsync("ru", entity.Title!).Result;
            var translatedContentRU = _translator.TranslateTextAsync("ru", entity.Content!).Result;

            _unitOfWork.Abouts.Update(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce about oluşturun ve kaydedin
            var aboutEN = new AboutEN
            {
                Title = translatedTitleEN,
                Content = translatedContentEN,
                ImagePath = entity.ImagePath,
                CompanyMail = entity.CompanyMail,
                CompanyAddress = entity.CompanyAddress,
                CompanyPhoneNumber = entity.CompanyPhoneNumber

            };
            _unitOfWork.AboutENs.Update(aboutEN);
            _unitOfWork.CompleteAsync();

            // Arapça about oluşturun ve kaydedin
            var aboutAR = new AboutAR
            {
                Title = translatedTitleAR,
                Content = translatedContentAR,
                ImagePath = entity.ImagePath,
                CompanyMail = entity.CompanyMail,
                CompanyAddress = entity.CompanyAddress,
                CompanyPhoneNumber = entity.CompanyPhoneNumber
            };
            _unitOfWork.AboutARs.Update(aboutAR);
            _unitOfWork.CompleteAsync();

            // Rusça about oluşturun ve kaydedin
            var aboutRU = new AboutRU
            {
                Title = translatedTitleRU,
                Content = translatedContentRU,
                ImagePath = entity.ImagePath,
                CompanyMail = entity.CompanyMail,
                CompanyAddress = entity.CompanyAddress,
                CompanyPhoneNumber = entity.CompanyPhoneNumber
            };
            _unitOfWork.AboutRUs.Update(aboutRU);
            _unitOfWork.CompleteAsync();
        }
    }
}
