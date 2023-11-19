using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.Questionnaire
{
    internal class QuestionnaireEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }
        public decimal Amount { get; set; }
    }
}
