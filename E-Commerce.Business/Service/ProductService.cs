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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LanguageTranslator _translator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(IUnitOfWork unitOfWork, LanguageTranslator translator, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _translator = translator;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GenerateUniqueId()
        {

            int lastUsedId = _unitOfWork.Products.GetLastUsedId();
            if (lastUsedId == null)
            {
                lastUsedId = 10;
            }

            // Yeni bir benzersiz ID oluşturun
            int newId = lastUsedId + 1;

            return newId;
        }
        public void Create(Product entity)
        {
            var translatedNameEN = _translator.TranslateTextAsync("en", entity.Name!).Result;
            var translatedSubTitleEN = _translator.TranslateTextAsync("en", entity.SubTitle!).Result;
            var translatedDescriptionEN = _translator.TranslateTextAsync("en", entity.Description!).Result;
            var translatedFeaturesEN = _translator.TranslateTextAsync("en", entity.Features!).Result;

            var translatedNameAR = _translator.TranslateTextAsync("ar", entity.Name!).Result;
            var translatedSubTitleAR = _translator.TranslateTextAsync("ar", entity.SubTitle!).Result;
            var translatedDescriptionAR = _translator.TranslateTextAsync("ar", entity.Description!).Result;
            var translatedFeaturesAR = _translator.TranslateTextAsync("ar", entity.Features!).Result;

            var translatedNameRU = _translator.TranslateTextAsync("ru", entity.Name!).Result;
            var translatedSubTitleRU = _translator.TranslateTextAsync("ru", entity.SubTitle!).Result;
            var translatedDescriptionRU = _translator.TranslateTextAsync("ru", entity.Description!).Result;
            var translatedFeaturesRU = _translator.TranslateTextAsync("ru", entity.Features!).Result;

            // Türkçe kategoriyi kaydedin ve otomatik olarak bir ID atayın
            entity.Id = GenerateUniqueId();
            // Türkçe ürünü kaydedin
            _unitOfWork.Products.Add(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce ürünü oluşturun ve kaydedin
            var productEN = new ProductEN
            {
                Id = entity.Id,
                Name = translatedNameEN,
                SubTitle = translatedSubTitleEN,
                Description = translatedDescriptionEN,
                Features = translatedFeaturesEN,
                Price = entity.Price,
                Quantity = entity.Quantity,
                SpecialProduct = entity.SpecialProduct,
                SubCategoryId = entity.SubCategoryId,
                CategoryId = entity.CategoryId,
                ProductImages = entity.ProductImages,
                OrderItems = entity.OrderItems,
                Comments = entity.Comments
            };
            _unitOfWork.ProductENs.Add(productEN);
            _unitOfWork.CompleteAsync();

            // Arapça ürünü oluşturun ve kaydedin
            var productAR = new ProductAR
            {
                Id = entity.Id,
                Name = translatedNameAR,
                SubTitle = translatedSubTitleAR,
                Description = translatedDescriptionAR,
                Features = translatedFeaturesAR,
                Price = entity.Price,
                Quantity = entity.Quantity,
                SpecialProduct = entity.SpecialProduct,
                SubCategoryId = entity.SubCategoryId,
                CategoryId = entity.CategoryId,
                ProductImages = entity.ProductImages,
                OrderItems = entity.OrderItems,
                Comments = entity.Comments
            };
            _unitOfWork.ProductARs.Add(productAR);
            _unitOfWork.CompleteAsync();

            // Rusça ürünü oluşturun ve kaydedin
            var productRU = new ProductRU
            {
                Id = entity.Id,
                Name = translatedNameRU,
                SubTitle = translatedSubTitleRU,
                Description = translatedDescriptionRU,
                Features = translatedFeaturesRU,
                Price = entity.Price,
                Quantity = entity.Quantity,
                SpecialProduct = entity.SpecialProduct,
                SubCategoryId = entity.SubCategoryId,
                CategoryId = entity.CategoryId,
                ProductImages = entity.ProductImages,
                OrderItems = entity.OrderItems,
                Comments = entity.Comments
            };
            _unitOfWork.ProductRUs.Add(productRU);
            _unitOfWork.CompleteAsync();
        }
        public void Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product != null)
            {
                _unitOfWork.Products.Remove(product);

                // Diğer dillerin modellerini de ilgili ürün ID'sine göre silin
                var productEN = _unitOfWork.ProductENs.GetById(id);
                if (productEN != null)
                {
                    _unitOfWork.ProductENs.Remove(productEN);
                }

                var productAR = _unitOfWork.ProductARs.GetById(id);
                if (productAR != null)
                {
                    _unitOfWork.ProductARs.Remove(productAR);
                }

                var productRU = _unitOfWork.ProductRUs.GetById(id);
                if (productRU != null)
                {
                    _unitOfWork.ProductRUs.Remove(productRU);
                }

                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<Product> GetBestSellers()
        {
            var bestSellersList =  _unitOfWork.Products.GetBestSellers().Take(3);
            return bestSellersList;
        }
        public IEnumerable<Product> GetNewArrivalsToThree()
        {
            var bestSellersList = _unitOfWork.Products.GetNewArrivalsToThree();
            return bestSellersList;
        }


        public IEnumerable<Product> GetAll()
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
                var enProducts = _unitOfWork.ProductENs.GetAll();
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ar-SA")
            {
                var enProducts = _unitOfWork.ProductARs.GetAll();
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ru-RU")
            {
                var enProducts = _unitOfWork.ProductRUs.GetAll();
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }


            return _unitOfWork.Products.GetAll(x => x.Category!);
        }
       
        public IEnumerable<Product> GetPopularProducts()
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
                var enProducts = _unitOfWork.ProductENs.GetAll(x => x.ProductImages, y => y.Category).Take(10);
                
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ar-SA")
            {
                var enProducts = _unitOfWork.ProductARs.GetAll(x => x.ProductImages, y => y.Category).Take(10);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ru-RU")
            {
                var enProducts = _unitOfWork.ProductRUs.GetAll(x=>x.ProductImages,y=>y.Category).Take(10);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }


        
            return _unitOfWork.Products.GetPopularProduct();
        }

        public IEnumerable<Product> GetAllWithCategory()
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
                var enProducts = _unitOfWork.ProductENs.GetAll(x => x.Category!, y => y.ProductImages!, z => z.SubCategory!);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ar-SA")
            {
                var enProducts = _unitOfWork.ProductARs.GetAll(x => x.Category!, y => y.ProductImages!, z => z.SubCategory!);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ru-RU")
            {
                var enProducts = _unitOfWork.ProductRUs.GetAll(x => x.Category!, y => y.ProductImages!, z => z.SubCategory!);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }


           
            return _unitOfWork.Products.GetAll(x => x.Category!, y => y.ProductImages!, z => z.SubCategory!);
        }

        public IEnumerable<Product> GetAllWithCategoryById(int id)
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
                var enProducts = _unitOfWork.ProductENs.GetAll(x => x.Category!, y => y.ProductImages!).Where(c => c.CategoryId == id);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ar-SA")
            {
                var enProducts = _unitOfWork.ProductARs.GetAll(x => x.Category!, y => y.ProductImages!).Where(c => c.CategoryId == id);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ru-RU")
            {
                var enProducts = _unitOfWork.ProductRUs.GetAll(x => x.Category!, y => y.ProductImages!).Where(c => c.CategoryId == id);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }


            var producList = _unitOfWork.Products.GetAll(x => x.Category!, y => y.ProductImages!).Where(c => c.CategoryId == id);
            return producList;
        }

        public IEnumerable<Product> GetAllWithSubCategoryById(int id)
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
                var enProducts = _unitOfWork.ProductENs.GetAll(x => x.Category!, y => y.ProductImages!, z => z.SubCategory!).Where(c => c.SubCategoryId == id);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ar-SA")
            {
                var enProducts = _unitOfWork.ProductARs.GetAll(x => x.Category!, y => y.ProductImages!, z => z.SubCategory!).Where(c => c.SubCategoryId == id);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ru-RU")
            {
                var enProducts = _unitOfWork.ProductRUs.GetAll(x => x.Category!, y => y.ProductImages!, z => z.SubCategory!).Where(c => c.SubCategoryId == id);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }

            var producList = _unitOfWork.Products.GetAll(x => x.Category!, y => y.ProductImages!,z=>z.SubCategory!).Where(c => c.SubCategoryId == id);
            return producList;
        }

        public IEnumerable<Product> GetSpecialProducts()
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
                var enProducts = _unitOfWork.ProductENs.GetAll().Where(product => product.SpecialProduct == true).Take(5);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ar-SA")
            {
                var enProducts = _unitOfWork.ProductARs.GetAll().Where(product => product.SpecialProduct == true).Take(5);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }
            else if (culture.Name == "ru-RU")
            {
                var enProducts = _unitOfWork.ProductRUs.GetAll().Where(product => product.SpecialProduct == true).Take(5);
                var products = enProducts.Select(enProducts => new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                });

                return products;
            }


  
            return _unitOfWork.Products.GetAll().Where(product => product.SpecialProduct == true).Take(5);
        }

        public Product GetById(int id)
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
                var enProducts = _unitOfWork.ProductENs.GetById(id, x => x.Category!, y => y.ProductImages!, z => z.SubCategory!);
                var products = new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                };

                return products;
            }
            else if (culture.Name == "ar-SA")
            {
                var enProducts = _unitOfWork.ProductARs.GetById(id, x => x.Category!, y => y.ProductImages!, z => z.SubCategory!);
                var products = new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                };

                return products;
            }
            else if (culture.Name == "ru-RU")
            {
                var enProducts = _unitOfWork.ProductRUs.GetById(id, x => x.Category!, y => y.ProductImages!, z => z.SubCategory!);
                var products = new Product
                {
                    Id = enProducts.Id,
                    Name = enProducts.Name,
                    SubTitle = enProducts.SubTitle,
                    Description = enProducts.Description,
                    Features = enProducts.Features,
                    Price = enProducts.Price,
                    Quantity = enProducts.Quantity,
                    SpecialProduct = enProducts.SpecialProduct,
                    SubCategoryId = enProducts.SubCategoryId,
                    CategoryId = enProducts.CategoryId,
                    ProductImages = enProducts.ProductImages,
                    OrderItems = enProducts.OrderItems,
                    Comments = enProducts.Comments,
                    Category = new Category
                    {
                        Name = enProducts.Category.Name,
                        Image = enProducts.Category.Image,
                        Products = enProducts.Category.Products,
                    }

                };

                return products;
            }


            return _unitOfWork.Products.GetById(id,x=>x.Category!,y=>y.ProductImages!,z=>z.SubCategory!);
        }




        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Categories.GetAll(x=>x.SubCategories!);
        }

        public void Update(Product entity)
        {


            var translatedNameEN = _translator.TranslateTextAsync("en", entity.Name!).Result;
            var translatedSubTitleEN = _translator.TranslateTextAsync("en", entity.SubTitle!).Result;
            var translatedDescriptionEN = _translator.TranslateTextAsync("en", entity.Description!).Result;
            var translatedFeaturesEN = _translator.TranslateTextAsync("en", entity.Features!).Result;

            var translatedNameAR = _translator.TranslateTextAsync("ar", entity.Name!).Result;
            var translatedSubTitleAR = _translator.TranslateTextAsync("ar", entity.SubTitle!).Result;
            var translatedDescriptionAR = _translator.TranslateTextAsync("ar", entity.Description!).Result;
            var translatedFeaturesAR = _translator.TranslateTextAsync("ar", entity.Features!).Result;

            var translatedNameRU = _translator.TranslateTextAsync("ru", entity.Name!).Result;
            var translatedSubTitleRU = _translator.TranslateTextAsync("ru", entity.SubTitle!).Result;
            var translatedDescriptionRU = _translator.TranslateTextAsync("ru", entity.Description!).Result;
            var translatedFeaturesRU = _translator.TranslateTextAsync("ru", entity.Features!).Result;

            // Türkçe ürünü kaydedin
            _unitOfWork.Products.Update(entity);
            _unitOfWork.CompleteAsync();

            // İngilizce ürünü oluşturun ve kaydedin
            var productEN = new ProductEN
            {
                Id = entity.Id,
                Name = translatedNameEN,
                SubTitle = translatedSubTitleEN,
                Description = translatedDescriptionEN,
                Features = translatedFeaturesEN,
                Price = entity.Price,
                Quantity = entity.Quantity,
                SpecialProduct = entity.SpecialProduct,
                SubCategoryId = entity.SubCategoryId,
                CategoryId = entity.CategoryId,
                ProductImages = entity.ProductImages,
                OrderItems = entity.OrderItems,
                Comments = entity.Comments
            };
            _unitOfWork.ProductENs.Update(productEN);
            _unitOfWork.CompleteAsync();

            // Arapça ürünü oluşturun ve kaydedin
            var productAR = new ProductAR
            {
                Id = entity.Id,
                Name = translatedNameAR,
                SubTitle = translatedSubTitleAR,
                Description = translatedDescriptionAR,
                Features = translatedFeaturesAR,
                Price = entity.Price,
                Quantity = entity.Quantity,
                SpecialProduct = entity.SpecialProduct,
                SubCategoryId = entity.SubCategoryId,
                CategoryId = entity.CategoryId,
                ProductImages = entity.ProductImages,
                OrderItems = entity.OrderItems,
                Comments = entity.Comments
            };
            _unitOfWork.ProductARs.Update(productAR);
            _unitOfWork.CompleteAsync();

            // Rusça ürünü oluşturun ve kaydedin
            var productRU = new ProductRU
            {
                Id = entity.Id,
                Name = translatedNameRU,
                SubTitle = translatedSubTitleRU,
                Description = translatedDescriptionRU,
                Features = translatedFeaturesRU,
                Price = entity.Price,
                Quantity = entity.Quantity,
                SpecialProduct = entity.SpecialProduct,
                SubCategoryId = entity.SubCategoryId,
                CategoryId = entity.CategoryId,
                ProductImages = entity.ProductImages,
                OrderItems = entity.OrderItems,
                Comments = entity.Comments
            };
            _unitOfWork.ProductRUs.Update(productRU);
            _unitOfWork.CompleteAsync();
        }
 
        public int GetPointByProductId(int id)
        {

            var commentsListByProduct = _unitOfWork.Comments.GetCommentByProductId(id);

            int averagePoint = commentsListByProduct.Any() ? (int)commentsListByProduct.Average(c => c.Star) : 0;
            return averagePoint;
        }
    
        public List<SearchResultViewModel> SearchProduct(string query)
        {
            var searchResults = _unitOfWork.Products.PerformSearch(query);

            // Sonuçları işleyerek görüntülenecek bir modele dönüştürün
            var viewModel = _unitOfWork.Products.ConvertToViewModel(searchResults);
            return viewModel;

        }


        public Product GetFirstProduct()
        {
            var product = _unitOfWork.Products.GetAll().OrderBy(p => p.Id).First();


            return product!;
        }
    }
}
