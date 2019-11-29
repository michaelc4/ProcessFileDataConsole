using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Graficos
{
    public class DesempenhoDao
    {
        private DocumentStore documentStore;

        public DesempenhoDao(DocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        public IEnumerable<DesempenhoModel> GetDadosByFiltro(List<string> filtro)
        {
            using (var session = documentStore.OpenSession())
            {
                return session.Query<DesempenhoModel>()
                    .Where(x => x.NomeTeste.In(filtro))
                    .OrderBy(x => x.NomeTeste)
                    .OrderBy(x => x.Data)
                    .ToList();
            }
        }
    }
}
