using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.UseCases.Core
{
    public abstract record CommandResponse()
    {
        private List<string> _errors = [];

        public void AddError(string error)
        {
            _errors ??= [];
            _errors.Add(error);
        }

        public void AddError(List<string> errors)
        {   
            foreach (var error in errors)
            {
                this.AddError(error);
            }
        }

        public void ClearErrors()
        {
            _errors.Clear();
        }

        public bool IsValid()
        {
            return _errors.Count == 0;
        }

        public List<string> GetErrors()
        {
            return _errors;
        }
    }
}