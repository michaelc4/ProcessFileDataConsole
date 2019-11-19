using Raven.Client.Documents;

namespace ProcessFileDataConsole
{
    public class DesempenhoDao
    {
        private DocumentStore documentStore;

        public DesempenhoDao(DocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        public void Store(DesempenhoModel model)
        {
            using (var session = documentStore.OpenSession())
            {
                session.Store(model);
                session.SaveChanges();
            }
        }
    }
}
