using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Countrofy.Configuration;
using Countrofy.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Countrofy.Services;

public class CountryMongoService : ICountryMongoService
{
    private readonly IMongoCollection<Country> _countryCollection;
    public CountryMongoService(IOptions<CountrofyMongoDbSettings> countryMongoDbSettings, IOptions<MongoCountrySettings> mongoCountrySettings)
    {
        var client = new MongoClient(countryMongoDbSettings.Value.ConnectionString);
        var database = client.GetDatabase(countryMongoDbSettings.Value.Database);
        _countryCollection = database.GetCollection<Country>(mongoCountrySettings.Value.Collection); 
    }

    public Task<List<Country>> GetAll() => _countryCollection.FindAsync<Country>(_ => true).Result.ToListAsync();
    public Task<Country> GetById(string id) => _countryCollection.FindAsync<Country>(a => a.Id == id).Result.FirstOrDefaultAsync();
    public Task Add(Country country) => _countryCollection.InsertOneAsync(country);
    public Task Delete(string id) => _countryCollection.DeleteOneAsync<Country>(a => a.Id == id);
    public Task Update(Country country) => _countryCollection.ReplaceOneAsync<Country>(a => a.Id == country.Id, country);
    
    // Dummy
    public Task AddAllCountries() => _countryCollection.InsertManyAsync(AllCountries);
    public List<Country> AllCountries { get; set; } = new()
    {
        new Country { Name = "Afghanistan"},
        new Country { Name = "Albania"},
        new Country { Name = "Algeria"},
        new Country { Name = "Andorra"},
        new Country { Name = "Angola"},
        new Country { Name = "Antigua and Barbuda"},
        new Country { Name = "Argentina"},
        new Country { Name = "Armenia"},
        new Country { Name = "Australia"},
        new Country { Name = "Austria"},
        new Country { Name = "Azerbaijan"},
        new Country { Name = "Bahamas"},
        new Country { Name = "Bahrain"},
        new Country { Name = "Bangladesh"},
        new Country { Name = "Barbados"},
        new Country { Name = "Belarus"},
        new Country { Name = "Belgium"},
        new Country { Name = "Belize"},
        new Country { Name = "Benin"},
        new Country { Name = "Bhutan"},
        new Country { Name = "Bolivia"},
        new Country { Name = "Bosnia and Herzegovina"},
        new Country { Name = "Botswana"},
        new Country { Name = "Brazil"},
        new Country { Name = "Brunei"},
        new Country { Name = "Bulgaria"},
        new Country { Name = "Burkina Faso"},
        new Country { Name = "Burundi"},
        new Country { Name = "Cabo Verde"},
        new Country { Name = "Cambodia"},
        new Country { Name = "Cameroon"},
        new Country { Name = "Canada"},
        new Country { Name = "Central African Republic"},
        new Country { Name = "Chad"},
        new Country { Name = "Chile"},
        new Country { Name = "China"},
        new Country { Name = "Colombia"},
        new Country { Name = "Comoros"},
        new Country { Name = "Congo, Democratic Republic of the"},
        new Country { Name = "Congo, Republic of the"},
        new Country { Name = "Costa Rica"},
        new Country { Name = "Cote dIvoire"},
        new Country { Name = "Croatia"},
        new Country { Name = "Cuba"},
        new Country { Name = "Cyprus"},
        new Country { Name = "Czechia"},
        new Country { Name = "Denmark"},
        new Country { Name = "Djibouti"},
        new Country { Name = "Dominica"},
        new Country { Name = "Dominican Republic"},
        new Country { Name = "Ecuador"},
        new Country { Name = "Egypt"},
        new Country { Name = "El Salvador"},
        new Country { Name = "Equatorial Guinea"},
        new Country { Name = "Eritrea"},
        new Country { Name = "Estonia"},
        new Country { Name = "Eswatini"},
        new Country { Name = "Ethiopia"},
        new Country { Name = "Fiji"},
        new Country { Name = "Finland"},
        new Country { Name = "France"},
        new Country { Name = "Gabon"},
        new Country { Name = "Gambia"},
        new Country { Name = "Georgia"},
        new Country { Name = "Germany"},
        new Country { Name = "Ghana"},
        new Country { Name = "Greece"},
        new Country { Name = "Grenada"},
        new Country { Name = "Guatemala"},
        new Country { Name = "Guinea"},
        new Country { Name = "Guinea-Bissau"},
        new Country { Name = "Guyana"},
        new Country { Name = "Haiti"},
        new Country { Name = "Honduras"},
        new Country { Name = "Hungary"},
        new Country { Name = "Iceland"},
        new Country { Name = "India"},
        new Country { Name = "Indonesia"},
        new Country { Name = "Iran"},
        new Country { Name = "Iraq"},
        new Country { Name = "Ireland"},
        new Country { Name = "Israel"},
        new Country { Name = "Italy"},
        new Country { Name = "Jamaica"},
        new Country { Name = "Japan"},
        new Country { Name = "Jordan"},
        new Country { Name = "Kazakhstan"},
        new Country { Name = "Kenya"},
        new Country { Name = "Kiribati"},
        new Country { Name = "Kosovo"},
        new Country { Name = "Kuwait"},
        new Country { Name = "Kyrgyzstan"},
        new Country { Name = "Laos"},
        new Country { Name = "Latvia"},
        new Country { Name = "Lebanon"},
        new Country { Name = "Lesotho"},
        new Country { Name = "Liberia"},
        new Country { Name = "Libya"},
        new Country { Name = "Liechtenstein"},
        new Country { Name = "Lithuania"},
        new Country { Name = "Luxembourg"},
        new Country { Name = "Madagascar"},
        new Country { Name = "Malawi"},
        new Country { Name = "Malaysia"},
        new Country { Name = "Maldives"},
        new Country { Name = "Mali"},
        new Country { Name = "Malta"},
        new Country { Name = "Marshall Islands"},
        new Country { Name = "Mauritania"},
        new Country { Name = "Mauritius"},
        new Country { Name = "Mexico"},
        new Country { Name = "Micronesia"},
        new Country { Name = "Moldova"},
        new Country { Name = "Monaco"},
        new Country { Name = "Mongolia"},
        new Country { Name = "Montenegro"},
        new Country { Name = "Morocco"},
        new Country { Name = "Mozambique"},
        new Country { Name = "Myanmar"},
        new Country { Name = "Namibia"},
        new Country { Name = "Nauru"},
        new Country { Name = "Nepal"},
        new Country { Name = "Netherlands"},
        new Country { Name = "New Zealand"},
        new Country { Name = "Nicaragua"},
        new Country { Name = "Niger"},
        new Country { Name = "Nigeria"},
        new Country { Name = "North Korea"},
        new Country { Name = "North Macedonia"},
        new Country { Name = "Norway"},
        new Country { Name = "Oman"},
        new Country { Name = "Pakistan"},
        new Country { Name = "Palau"},
        new Country { Name = "Palestine"},
        new Country { Name = "Panama"},
        new Country { Name = "Papua New Guinea"},
        new Country { Name = "Paraguay"},
        new Country { Name = "Peru"},
        new Country { Name = "Philippines"},
        new Country { Name = "Poland"},
        new Country { Name = "Portugal"},
    };    
    
}
