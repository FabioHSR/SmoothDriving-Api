using System;
using System.Collections.Generic;

namespace SmoothDrivingAPI.Services
{
    public class ServiceUtils
    {
        public static Tuple<List<string>, bool> ValidateInvalidFields(List<string> invalidFields)
        {
            if(invalidFields.Count > 0){
                return Tuple.Create(invalidFields, false);
            }
            return Tuple.Create(invalidFields, true);
        }
    }
}