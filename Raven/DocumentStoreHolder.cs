using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Documents;

namespace crudRavendb.Raven
{
    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
           new Lazy<IDocumentStore>(() =>
           {
               IDocumentStore store = new DocumentStore
               {
                   Urls = new[] { "http://127.0.0.1:8080" },
                   Database = "crud_Ab2"
               };

               store.Initialize();

               return store;
           });

        public static IDocumentStore Store => LazyStore.Value;
     }
}
