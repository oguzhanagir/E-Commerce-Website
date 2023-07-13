using GTranslate.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Translators
{
    public class LanguageTranslator
    {
        public AggregateTranslator Translator { get; set; }

        public LanguageTranslator()
        {
            Translator = new AggregateTranslator();
        }
        public async Task<string> TranslateTextAsync(string language, string text)
        {
            var result = await Translator.TranslateAsync(text, language);
            var translatedValue = result.Translation;
            return translatedValue;
        }
    }
}
