﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commons.Contracts
{
    public interface IDateTimeValidator
    {
        public bool Validate(DateTime date);
        public DateTimeOffset GenerateAlertDate(DateTime date);
    }
}