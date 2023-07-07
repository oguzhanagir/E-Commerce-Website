function showProductDetails() {
    var productData = {
        "@context": "http://schema.org",
        "@type": "Product",
        "name": "Ürün Adı",
        "description": "Ürün Açıklaması",
        "brand": {
            "@type": "Brand",
            "name": "Marka Adı"
        },
        "offers": {
            "@type": "Offer",
            "price": "19.99",
            "priceCurrency": "TRY",
            "availability": "InStock"
        }
    };

    var scriptTag = document.createElement('script');
    scriptTag.type = 'application/ld+json';
    scriptTag.innerHTML = JSON.stringify(productData);

    document.getElementsByTagName('head')[0].appendChild(scriptTag);
}

showProductDetails()