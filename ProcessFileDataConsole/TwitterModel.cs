using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessFileDataConsole
{
    public class TwitterModel
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Mensagem { get; set; }
        public string Data { get; set; }
        public string Pais { get; set; }
        public List<string> HashTags { get; set; }
    }
}
