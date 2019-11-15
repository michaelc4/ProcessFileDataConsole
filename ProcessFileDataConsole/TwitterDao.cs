using Raven.Client.Documents;
using System.Collections.Generic;
using System.Linq;

namespace ProcessFileDataConsole
{
    public class TwitterDao
    {
        private DocumentStore documentStore;

        public TwitterDao(DocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        public void Store(TwitterModel model)
        {
            using (var session = documentStore.OpenSession())
            {
                session.Store(model);
                session.SaveChanges();
            }
        }

        public void Delete(TwitterModel model)
        {
            using (var session = documentStore.OpenSession())
            {
                session.Delete(model.Id);
                session.SaveChanges();
            }
        }

        public List<TwitterModel> GetList()
        {
            using (var session = documentStore.OpenSession())
            {
                return session.Query<TwitterModel>()
                    .Customize(p => p.WaitForNonStaleResults())
                    .ToList();
            }
        }

        public TwitterModel GetData(string id)
        {
            using (var session = documentStore.OpenSession())
            {
                return session.Load<TwitterModel>(id);
            }
        }

        public int GetBuscaBanda(string nome)
        {
            Criptografia cript = new Criptografia();
            cript.Key = "Teste";

            string hashTag = nome;
            if (nome.Length > 0 && nome.Substring(0, 1) != "#")
                hashTag = "#" + nome;

            using (var session = documentStore.OpenSession())
            {
                int qtdHash = 0;
                List<TwitterModel> resultadosHash = session.Query<TwitterModel>()
                     .Customize(p => p.WaitForNonStaleResults())
                     .Search(x => x.HashTags, "*" + cript.Encrypt(hashTag) + "*")
                     .Search(x => x.HashTags, "*" + cript.Encrypt(hashTag.ToLower()) + "*")
                     .Search(x => x.HashTags, "*" + cript.Encrypt(hashTag.ToUpper()) + "*")
                     .ToList();

                List<string> ids = new List<string>();
                if (resultadosHash != null && resultadosHash.Count > 0)
                {
                    qtdHash = resultadosHash.Count;
                    foreach (TwitterModel tm in resultadosHash)
                    {
                        ids.Add(tm.Id);
                    }
                }

                int qtdNome = 0;
                List<TwitterModel> resultadosMensagem = session.Query<TwitterModel>()
                     .Customize(p => p.WaitForNonStaleResults())
                     .Search(x => x.Mensagem, "*" + nome + "*")
                     .ToList();

                if (resultadosMensagem != null && resultadosMensagem.Count > 0)
                {
                    foreach (TwitterModel tm in resultadosMensagem)
                    {
                        if (!ids.Exists(x => x == tm.Id) && tm.Mensagem.ToLower().Contains(nome.ToLower()))
                        {
                            qtdNome += 1;
                        }
                    }
                }

                return qtdHash + qtdNome;
            }
        }
    }
}
