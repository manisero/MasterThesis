using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeGeneration.Logic.DomainDeserialization._Impl
{
    public class DomainDeserializer : IDomainDeserializer
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IJsonDeserializer _jsonDeserializer;

        public DomainDeserializer(IFileSystemService fileSystemService, IJsonDeserializer jsonDeserializer)
        {
            _fileSystemService = fileSystemService;
            _jsonDeserializer = jsonDeserializer;
        }

        public TDomain Deserialize<TDomain>(string rootFolderPath)
            where TDomain : new()
        {
            var domain = GetDomainObject<TDomain>(rootFolderPath);
            FillDomainCollections(domain, rootFolderPath);

            return domain;
        }

        private TDomain GetDomainObject<TDomain>(string rootFolderPath)
            where TDomain : new()
        {
            var rootFiles = _fileSystemService.GetFilesInDirectory(rootFolderPath, false);

            if (rootFiles.Count == 0)
            {
                return new TDomain();
            }

            if (rootFiles.Count == 1)
            {
                return _jsonDeserializer.Deserialize<TDomain>(_fileSystemService.GetFileContent(rootFiles[0]));
            }

            throw new InvalidOperationException("Root folder contains more than one file.");
        }

        private void FillDomainCollections<TDomain>(TDomain domain, string rootFolderPath)
        {
            var directories = _fileSystemService.GetDirectoriresInDirectory(rootFolderPath);
            var enumerableProperties = typeof(TDomain).GetProperties()
                                                      .Where(x => typeof(IEnumerable).IsAssignableFrom(x.PropertyType))
                                                      .ToList();

            foreach (var directory in directories)
            {
                var directoryName = Path.GetFileName(directory);
                var property = enumerableProperties.SingleOrDefault(x => x.Name.Equals(directoryName, StringComparison.OrdinalIgnoreCase));

                if (property != null)
                {
                    var domainItemType = property.PropertyType.GenericTypeArguments[0];
                    var filesInDirectory = _fileSystemService.GetFilesInDirectory(directory, false);
                    var collectionItems = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(domainItemType));

                    foreach (var file in filesInDirectory)
                    {
                        var fileContent = _fileSystemService.GetFileContent(file);
                        var domainItem = _jsonDeserializer.Deserialize(domainItemType, fileContent);

                        collectionItems.Add(domainItem);
                    }

                    property.SetValue(domain, collectionItems);
                }
            }
        }
    }
}
