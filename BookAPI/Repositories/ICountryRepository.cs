using BookAPI.Models;
using System.Collections.Generic;

namespace BookAPI.Services
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int countryId);

        Country GetCountryOfAnAuthor(int authorId);

        ICollection<Author> GetAuthorsFromACountry(int countryId);

        bool CountryExists(int countryId);
    }
}