using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data.Provider
{
    [ExcludeFromCodeCoverage]
    public class FileCsvContentProvider : ICsvContentProvider
    {
        private readonly string _fileName;

        public FileCsvContentProvider(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<IEnumerable<string>> GetCsvLines()
        {
            try
            {
                return await Task.Run(() => System.IO.File.ReadAllLines(_fileName).AsEnumerable());
            }
            catch (Exception exception)
            {
                throw new DataProviderException(exception.Message);
            }
        }
    }
}