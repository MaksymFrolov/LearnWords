using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWords.Model.DBEntity.Clases
{
    internal abstract class Promotion
    {
        public int? CompletedENUA { get; set; }

        public int? FailedENUA { get; set; }

        public int? CompletedUAEN { get; set; }

        public int? FailedUAEN { get; set; }

        public int SuccesENUA()=> (CompletedENUA - FailedENUA) ?? default;
        public int SuccesUAEN() => (CompletedUAEN - FailedUAEN) ?? default;
    }
}
