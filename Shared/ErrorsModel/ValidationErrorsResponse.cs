using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ErrorsModel
{
    public class ValidationErrorsResponse
    {
        public int StatusCcode { get; set; }
        public string MsgErrors { get; set; }
        public IEnumerable<ValidationErrors> Errors { get; set; }
    }

    public class ValidationErrors
    {
        public string Field { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
