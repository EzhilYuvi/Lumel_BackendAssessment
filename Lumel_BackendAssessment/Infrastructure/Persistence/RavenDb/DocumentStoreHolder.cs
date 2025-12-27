using Raven.Client.Documents;

namespace Lumel_BackendAssessment.Infrastructure.Persistence.RavenDb
{
    public static class DocumentStoreHolder
    {
        private static IDocumentStore? _store;

        public static IDocumentStore Store =>
            _store ??= new DocumentStore
            {
                Urls = ["http://localhost:8085"],
                Database = "lumel_assignment_db"
            }.Initialize();
    }
}
